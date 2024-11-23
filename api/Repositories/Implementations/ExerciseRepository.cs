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

    public async Task<Exercise> CreateAsync(CreateExerciseRequestDto dto)
    {
        var exercise = dto.ToExerciseFromCreateDTO();
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var pictureFile = dto.Picture;
                var videoFile = dto.Video;

                var pictureStream = new MemoryStream();
                await pictureFile.CopyToAsync(pictureStream);
                await _fileHandlerRepository.UploadFileAsync($"exercises/{exercise.Id}/media/{pictureFile.FileName}", pictureStream);

                var pictureInfo = new Models.FileInfo { Name = pictureFile.FileName, Size = pictureFile.Length, Type = "Picture" };
                await _context.FileInfos.AddAsync(pictureInfo);

                var videoStream = new MemoryStream();
                await videoFile.CopyToAsync(videoStream);
                await _fileHandlerRepository.UploadFileAsync($"exercises/{exercise.Id}/media/{videoFile.FileName}", videoStream);

                var videoInfo = new Models.FileInfo { Name = videoFile.FileName, Size = videoFile.Length, Type = "Video" };
                await _context.FileInfos.AddAsync(videoInfo);

                exercise.Picture = pictureInfo;
                exercise.Video = videoInfo;

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

                _context.Exercises.Add(exercise);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            } catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    
        return exercise;
    }

    public async Task<List<ExerciseLevel>> GetAllExerciseLevelsAsync()
    {
        return await _context.ExerciseLevels.ToListAsync();
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
