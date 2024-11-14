import { createBrowserRouter } from "react-router-dom";
import Landing from "../components/Landing/Landing";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <Landing />,
        children: [
        ]
    }
])