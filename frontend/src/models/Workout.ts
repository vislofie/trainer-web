export type WorkoutSetItem = {
    id: number;
    weight: number;
    repetitions: number;
    itemNumber: number;
}

export type WorkoutSet = {
    id: number;
    exerciseId: number;
    
    items: WorkoutSetItem[];
}

export type Workout = {
    id: number;
    workoutName: string;
    createdById: string;
    isApproved: boolean;
    
    sets: WorkoutSet[];
}