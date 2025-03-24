import { Outlet } from "react-router";
import { UserProvider } from "./context/useAuth";
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
