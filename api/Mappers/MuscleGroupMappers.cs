using api.DTOs.MuscleGroups;
using api.Models;

namespace api.Mappers;

public static class MuscleGroupMappers
{
    public static MuscleGroupDto ToMuscleGroupDTO(this MuscleGroup muscleGroup)
    {
        return new MuscleGroupDto 
        {
            Id = muscleGroup.Id,
            Name = muscleGroup.Name
        };
    }

    public static MuscleGroup ToMuscleGroupFromCreateDTO(this CreateMuscleGroupRequestDto dto)
    {
        return new MuscleGroup 
        {
            Name = dto.Name
        };
    }
}
