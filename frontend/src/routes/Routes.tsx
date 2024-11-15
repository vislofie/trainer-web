import { createBrowserRouter } from "react-router-dom";
import Landing from "../pages/Landing/Landing";
import LoginPage from "../pages/LoginPage/LoginPage";
import RegisterPage from "../pages/RegisterPage/RegisterPage";
import App from "../App";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            {
                path: "",
                element: <Landing />
            },
            {
                path: "signin",
                element: <LoginPage />    
            },
            {
                path: "signup",
                element: <RegisterPage />
            }
        ]
    },
])