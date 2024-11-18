import { createContext, useEffect, useState } from "react";
import { useNavigate } from "react-router";
import axios from "axios";
import { loginApi, registerApi } from "../services/AuthService";
import { UserProfile } from "../models/User";
import React from "react";

type UserContextType = {
    user: UserProfile | null;
    token: string | null;
    registerUser: (email: string, username: string, password: string) => void;
    loginUser: (email: string, password: string) => void;
    logout: () => void;
    isLoggedIn: () => boolean;
}

type Props = { children: React.ReactNode };

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({ children } : Props) => {
    const navigate = useNavigate();
    const [token, setToken] = useState<string | null>(null);
    const [user, setUser] = useState<UserProfile | null>(null);
    const [isAuthorized, setAuthorized] = useState(false);

    useEffect(() => {
        const user = localStorage.getItem("user");
        const token = localStorage.getItem("token");
        if (user && token) {
            setUser(JSON.parse(user));
            setToken(token);
            axios.defaults.headers.common["Authorization"] = "Bearer " + token;
        }

        setAuthorized(true);
    }, []);

    const registerUser = async (email: string, username: string, password: string) => {
        await registerApi(email, username, password).then((res) => {
            if (res) {
                localStorage.setItem("token", res?.data.token);
                
                const userObject = {
                    email: email
                }

                localStorage.setItem("user", JSON.stringify(userObject));
                setToken(res?.data.token!);
                setUser(userObject!);
                navigate("/personal");
                axios.defaults.headers.common["Authorization"] = "Bearer " + token;
            }
        });
    }

    const loginUser = async (email: string, password: string) => {
        await loginApi(email, password).then((res) => {
            if (res) {
                localStorage.setItem("token", res?.data.token);
                const userObject = {
                    email: email
                }

                localStorage.setItem("user", JSON.stringify(userObject));
                setToken(res?.data.token!);
                setUser(userObject!);
                navigate("/personal");
                axios.defaults.headers.common["Authorization"] = "Bearer " + token;
            }
        })
    }

    const isLoggedIn = () => {
        console.log(!!user);
        return !!user;
    }

    const logout = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("user");

        setUser(null);
        setToken("");
        navigate("/signin");
    }

    return (
        <UserContext.Provider value={{user, token, logout, isLoggedIn, registerUser, loginUser}}>
            {isAuthorized ? children : null}
        </UserContext.Provider>
    )
}

export const useAuth = () => React.useContext(UserContext);