import { createBrowserRouter } from "react-router-dom";
import Landing from "../pages/Landing/Landing";
import LoginPage from "../pages/LoginPage/LoginPage";
import RegisterPage from "../pages/RegisterPage/RegisterPage";
import App from "../App";
import ProtectedRoute from "./ProtectedRoute";
import PersonalPage from "../pages/PersonalPage/PersonalPage";
import StatisticsPanel from "../components/Personal/StatisticsPanel/StatisticsPanel";
import CalendarPanel from "../components/Personal/CalendarPanel/CalendarPanel";
import ExercisePanel from "../components/Personal/ExercisePanel/ExercisePanel";
import WorkoutPanel from "../components/Personal/WorkoutPanel/WorkoutPanel";

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
            },
            {
                path: "personal",
                children: [
                    {
                        path: 'statistics',
                        element: <StatisticsPanel />
                    },
                    {
                        path: 'calendar',
                        element: <CalendarPanel />
                    },
                    {
                        path: 'exercise',
                        element: <ExercisePanel />
                    },
                    {
                        path: 'workout',
                        element: <WorkoutPanel />
                    }
                ],
                element: <ProtectedRoute><PersonalPage /></ProtectedRoute>
            }
        ]
    },
])