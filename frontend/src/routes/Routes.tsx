import { createBrowserRouter } from "react-router-dom";
import Landing from "../pages/Landing/Landing";
import LoginPage from "../pages/LoginPage/LoginPage";
import RegisterPage from "../pages/RegisterPage/RegisterPage";

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
        path: "signin",
        element: <LoginPage />    
    },
    {
        path: "signup",
        element: <RegisterPage />
    }
])