import axios from "axios";
import { Exercise, ExerciseLevel, ExerciseUpload, MuscleGroup } from "../models/Exercise";

const api = import.meta.env.VITE_API_ADDRESS;
const subDomain = "exercises";
const levelsSubDomain = "levels";
const muscleGroupsSubDomain = "muscle-groups";

export const getExercises = async () => {
    try {
        const data = await axios.get<Exercise[]>(`${api}/${subDomain}`);
        return data.data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
        }
        else {
            console.log("unexpected error");
        }
    }
}

export const getExerciseById = async (id: number) => {
    try {
        const data = await axios.get<Exercise>(`${api}/${subDomain}/${id}`);
        return data.data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
        }
        else {
            console.log("unexpected error");
        }
    }
}

export const getExerciseLevels = async () => {
    try {
        const data = await axios.get<ExerciseLevel[]>(`${api}/${subDomain}/${levelsSubDomain}`);
        return data.data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
        }
        else
        {
            console.log("unexpected error");
        }
    }
}

export const getMuscleGroups = async () => {
    try {
        const data = await axios.get<MuscleGroup[]>(`${api}/${muscleGroupsSubDomain}`);
        return data.data;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log('error message: ', error.message);
        } else {
            console.log("unexpected error");
        }
    }
}

export const addExercise = async (exercise: ExerciseUpload) => {
    try {
        const data = new FormData();
        data.append("title", exercise.title);
        data.append("description", exercise.description);
        data.append("picture", exercise.picture);
        data.append("video", exercise.video);
        data.append("exerciseLevelId", exercise.exerciseLevelId.toString());
        data.append("muscleGroupIds", exercise.muscleGroupIds.join(','))
        

        await axios.postForm(`${api}/${subDomain}`, data, {
            headers: {
                'Content-Type': 'multipart/form-data'
            }
        });
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
        }
        else {
            console.log("unexpected error");
        }
    }
}

