import axios from "axios";

const api = import.meta.env.VITE_API_ADDRESS;
const subDomain = "file";

export const getFile = async(fileId: number) => {
    try {
        const data = await axios.get(getFileUrl(fileId));
        return data.data[0];
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.log("error message: " + error.message);
        }
    }
}

export const getFileUrl = (fileId: number) => {
    return `${api}/${subDomain}?fileId=${fileId}`;
}