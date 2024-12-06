using api.Context;
using api.DTOs.Exercise;
using api.DTOs.ExerciseLevel;
using api.Mappers;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IFileHandlerRepository _fileHandlerRepository;
    public ExerciseRepository(ApplicationDbContext context, IFileHandlerRepository fileHandlerRepository)
    {
        _context = context;
        _fileHandlerRepository = fileHandlerRepository;
    }

    public async Task<List<Exercise>> GetAllAsync()
    {
        return await _context.Exercises
            .Include(e => e.MuscleGroups)
            .Include(e => e.ExerciseLevel)
            .ToListAsync();
    }

    public async Task<Exercise?> GetByIdAsync(int id)
    {
        var exercise = await _context.Exercises
            .Include(e => e.MuscleGroups)
            .Include(e => e.ExerciseLevel)
            .FirstOrDefaultAsync(ex => ex.Id == id);

        return exercise;
    }

    public async Task<Exercise> CreateAsync(CreateExerciseRequestDto dto)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var exercise = dto.ToExerciseFromCreateDTO();
                var maxId = _context.Exercises.Max(table => table.Id);
                exercise.Id = maxId + 1;

                if (dto.MuscleGroupIDs != null && dto.MuscleGroupIDs.Any())
                {
                    var muscleGroups = await _context.MuscleGroup
                        .Where(mg => dto.MuscleGroupIDs.Contains(mg.Id))
                        .ToListAsync();

                    exercise.MuscleGroups = muscleGroups;
                }

                var exerciseLevel = await _context.ExerciseLevels.FirstOrDefaultAsync(el => el.Id == dto.ExerciseLevelID);
                if (exerciseLevel == null)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("No exercise level with this ID");
                }
                
                exercise.ExerciseLevel = exerciseLevel;

                exercise = await UploadPicture(dto.Picture, exercise);
                exercise = await UploadVideo(dto.Video, exercise);
                
                await _context.Exercises.AddAsync(exercise);
                await _context.SaveChangesAsync();

                await _fileHandlerRepository.CleanUnusedFilesAsync();

                await transaction.CommitAsync();
                return exercise;
            } catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public async Task<Exercise?> UpdateByIdAsync(int id, UpdateExerciseRequestDto updateDto)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var exercise = await _context.Exercises
                                        .Include(e => e.MuscleGroups)
                                        .Include(e => e.ExerciseLevel)
                                        .FirstOrDefaultAsync(ex => ex.Id == id);

                if (exercise == null)
                    return null;

                if (updateDto.Title != null)
                {
                    exercise.Title = updateDto.Title;
                }
                if (updateDto.Description != null)
                {
                    exercise.Description = updateDto.Description;
                }
                if (updateDto.Picture != null)
                {
                    exercise = await UploadPicture(updateDto.Picture, exercise);   
                }
                if (updateDto.Video != null)
                {
                    exercise = await UploadVideo(updateDto.Video, exercise);
                }
                if (updateDto.ExerciseLevelID != null)
                {
                    var exerciseLevel = await _context.ExerciseLevels.FirstOrDefaultAsync(exl => exl.Id == updateDto.ExerciseLevelID);

                    if (exerciseLevel != null)
                        exercise.ExerciseLevel = exerciseLevel;
                }
                if (updateDto.MuscleGroupIDs != null && updateDto.MuscleGroupIDs.Any())
                {
                    var currentMuscleGroupIds = exercise.MuscleGroups.Select(mg => mg.Id).ToList();
                    var muscleGroupsToAdd = updateDto.MuscleGroupIDs.Except(currentMuscleGroupIds);
                    var muscleGroupsToRemove = currentMuscleGroupIds.Except(updateDto.MuscleGroupIDs);

                    foreach (var idToAdd in muscleGroupsToAdd)
                    {
                        var muscleGroup = await _context.MuscleGroup.FindAsync(idToAdd);
                        if (muscleGroup != null)
                            exercise.MuscleGroups.Add(muscleGroup);
                    }

                    foreach (var idToRemove in muscleGroupsToRemove)
                    {
                        var muscleGroupToRemove = exercise.MuscleGroups.FirstOrDefault(mg => mg.Id == idToRemove);
                        if (muscleGroupToRemove != null)
                            exercise.MuscleGroups.Remove(muscleGroupToRemove);
                    }
                }

                await _context.SaveChangesAsync();

                await _fileHandlerRepository.CleanUnusedFilesAsync();

                await transaction.CommitAsync();
                return exercise;
            } catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        
    }

    private async Task<Exercise> UploadPicture(IFormFile picture, Exercise exercise)
    {
        try
        {
            var pictureFile = picture;

            string pictureName = Guid.NewGuid().ToString() + Path.GetExtension(pictureFile.FileName);
            string picturePath = $"exercises/media/{exercise.Id}/{pictureName}";

            var pictureStream = new MemoryStream();
            await pictureFile.CopyToAsync(pictureStream);
            await _fileHandlerRepository.UploadFileAsync(picturePath, pictureStream);

            var pictureInfo = new Models.FileInfo { Name = pictureName, Size = pictureFile.Length, Type = "Picture", Path = picturePath };
            await _context.FileInfos.AddAsync(pictureInfo);

            exercise.Picture = pictureInfo;

            return exercise;
        } catch
        {
            throw;
        }
    }

    private async Task<Exercise> UploadVideo(IFormFile video, Exercise exercise)
    {
        try
        {
            var videoFile = video;
            
            string videoName = Guid.NewGuid().ToString() + Path.GetExtension(videoFile.FileName);
            string videoPath = $"exercises/media/{exercise.Id}/{videoName}";
            
            var videoStream = new MemoryStream();
            await videoFile.CopyToAsync(videoStream);
            await _fileHandlerRepository.UploadFileAsync(videoPath, videoStream);

            var videoInfo = new Models.FileInfo { Name = videoName, Size = videoFile.Length, Type = "Video", Path = videoPath };
            await _context.FileInfos.AddAsync(videoInfo);

            exercise.Video = videoInfo;

            return exercise;
        } catch
        {
            throw;
        }
    }


    public async Task<List<ExerciseLevel>> GetAllExerciseLevelsAsync()
    {
        return await _context.ExerciseLevels.OrderBy(item => item.Id).ToListAsync();
    }

    public async Task<ExerciseLevel?> CreateExerciseLevelAsync(CreateExerciseLevelRequestDto createDto)
    {
        if (await _context.ExerciseLevels.FirstOrDefaultAsync(el => el.Name == createDto.Name) != null)
            return null;
        
        var exerciseLevel = createDto.ToExerciseLevel();

        await _context.ExerciseLevels.AddAsync(exerciseLevel);
        await _context.SaveChangesAsync();

        return exerciseLevel;
    }
}
