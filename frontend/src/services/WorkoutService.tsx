import axios from 'axios';
import {Workout} from "../models/Workout.ts";

const api = import.meta.env.VITE_API_ADDRESS;
const subDomain = 'workouts';

export const getWorkouts = async () =>
{
    try {
        const data = await axios.get<Workout[]>(`${api}/${subDomain}`);
        return data.data;
    } catch (error) {
        handleError(error);
    }
}

export const handleError = (error: unknown) => {
    if (axios.isAxiosError(error)) {
        console.log("error message: ", error.message);
    } else {
        console.log("unexpected error");
    }
}