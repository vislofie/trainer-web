import {Exercise} from "./Exercise";

export type WorkoutSetItem = {
    id: number;
    weight: number;
    repetitions: number;
    itemNumber: number;
}

export type WorkoutSet = {
    id: number;
    
    exercise: Exercise;
    items: WorkoutSetItem[];
}

export type Workout = {
    id: number;
    workoutName: string;
    sets: WorkoutSet[];
}