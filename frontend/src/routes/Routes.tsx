import { createBrowserRouter } from "react-router-dom";
import Landing from "../pages/Landing/Landing";
import Authorization from "../pages/Authorization/Authorization";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <Landing />,
        children: [
            {
                
            }
        ]
    },
    {
        path: "auth",
        element: <Authorization />
    }
])