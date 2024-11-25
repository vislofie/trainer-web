export type ExerciseLevel = {
    id: number,
    name: string
}

export type MuscleGroup = {
    id: number,
    name: string
}

export type Exercise = {
    id: number,
    title: string,
    description: string,
    pictureId: number,
    videoId: number,
    exerciseLevel: ExerciseLevel,
    muscleGroups: MuscleGroup[],
    isApproved: boolean
}

export type ExerciseUpload = {
    title: string;
    description: string;
    picture: File;
    video: File;
    exerciseLevelId: number;
    muscleGroupIds: number[];
}