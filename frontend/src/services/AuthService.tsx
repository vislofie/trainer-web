import axios from "axios";

const api = import.meta.env.VITE_API_ADDRESS;
const subDomain = "auth"

export const loginApi = async (email: string, password: string) => {
    try {
        const response = await axios.post(`${api}/${subDomain}/login`, {
            email: email,
            password: password
        });

        console.log(response.statusText);
        return response;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
        }
        else {
            console.log("unexpected error");
        }
    }
}

export const registerApi = async (email: string, username: string, password: string) => {
    try {
        console.log(email + ' ' + username + ' ' + password);

        const response = await axios.post(`${api}/${subDomain}/register`, {
            email: email,
            username: username,
            password: password
        });

        console.log(response.statusText);
        return response;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: ", error.message);
        }
        else {
            console.log("unexpected error");
        }
    }
}