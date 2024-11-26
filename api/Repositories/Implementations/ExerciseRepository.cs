using System.Diagnostics;
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

                if (dto.ExerciseLevelID != null)
                {
                    var exerciseLevel = await _context.ExerciseLevels.FirstOrDefaultAsync(el => el.Id == dto.ExerciseLevelID);
                    exercise.ExerciseLevel = exerciseLevel;
                }

                exercise = await UploadMediaFiles(dto.Picture, dto.Video, exercise);
                
                await _context.Exercises.AddAsync(exercise);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return exercise;
            } catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    private async Task<Exercise> UploadMediaFiles(IFormFile picture, IFormFile video, Exercise exercise)
    {
        try
        {
            var pictureFile = picture;
            var videoFile = video;

            string pictureName = Guid.NewGuid().ToString() + Path.GetExtension(pictureFile.FileName);
            string videoName = Guid.NewGuid().ToString() + Path.GetExtension(videoFile.FileName);
            string picturePath = $"exercises/media/{exercise.Id}/{pictureName}";
            string videoPath = $"exercises/media/{exercise.Id}/{videoName}";
            
            var pictureStream = new MemoryStream();
            await pictureFile.CopyToAsync(pictureStream);
            await _fileHandlerRepository.UploadFileAsync(picturePath, pictureStream);
            
            var pictureInfo = new Models.FileInfo { Name = pictureName, Size = pictureFile.Length, Type = "Picture", Path = picturePath };
            await _context.FileInfos.AddAsync(pictureInfo);

            var videoStream = new MemoryStream();
            await videoFile.CopyToAsync(videoStream);
            await _fileHandlerRepository.UploadFileAsync(videoPath, videoStream);

            var videoInfo = new Models.FileInfo { Name = videoName, Size = videoFile.Length, Type = "Video", Path = videoPath };
            await _context.FileInfos.AddAsync(videoInfo);

            exercise.Picture = pictureInfo;
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
