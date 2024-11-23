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
    public ExerciseRepository(ApplicationDbContext context)
    {
        _context = context;
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

        foreach (var muscleGroupId in dto.MuscleGroupIDs)
        {
            var muscleGroup = await _context.MuscleGroup.FindAsync(muscleGroupId);
            if (muscleGroup != null)
                exercise.MuscleGroups.Add(muscleGroup);
        }

        var exerciseLevel = await _context.ExerciseLevels.FindAsync(dto.ExerciseLevelID);
        if (exerciseLevel != null)
        {
            exercise.ExerciseLevel = exerciseLevel;
        }

        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync();

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
