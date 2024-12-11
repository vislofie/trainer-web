import { Outlet } from "react-router";
import { UserProvider } from "./context/useAuth";
import { createContext } from "react";
import Alert from "./components/Global/Alert/Alert";
import { useState } from "react";
import { AlertProvider } from "./context/useAlert";


function App() {
  
  

  return (
   <>
   <UserProvider>
    <AlertProvider>
      <Outlet />
    </AlertProvider>
   </UserProvider>
   </> 
  );
}

export default App;
