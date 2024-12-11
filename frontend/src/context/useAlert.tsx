import { createContext, useState } from "react";
import Alert, { AlertType } from "../components/Global/Alert/Alert";
import React from "react";

type AlertContextType = {
    alert: (
        alertType: AlertType,
        title: string,
        description: string,
        onConfirm?: () => void,
        onCancel?: () => void
    ) => void;
}

type Props = { children: React.ReactNode };

const AlertContext = createContext<AlertContextType>({} as AlertContextType);

export const AlertProvider = ({children} : Props) => {

    const [alertState, setAlertState] = useState(false);

    const [alertType, setAlertType] = useState<AlertType>();
    const [title, setTitle] = useState<string>();
    const [description, setDescription] = useState<string>();
    const [onConfirm, setOnConfirm] = useState<() => void>();
    const [onCancel, setOnCancel] = useState<() => void>();

    const alert = (
        alertType: AlertType,
        title: string,
        description: string,
        onConfirm?: () => void,
        onCancel?: () => void
    ) => {
        setAlertState(true);

        setAlertType(alertType);
        setTitle(title);
        setDescription(description)
        setOnConfirm(onConfirm);
        setOnCancel(onCancel);
    }

    return (
        <AlertContext.Provider value={{alert}}>
            {children}
            {alertState ? 
            <Alert 
                alertType={alertType!}
                alertState={alertState}
                title={title!} 
                description={description!}
                onConfirm={() => {onConfirm?.(); setAlertState(false);}}
                onCancel={() => {onCancel?.(); setAlertState(false);}}
            /> : null}
            
        </AlertContext.Provider>
    )
}

export const useAlert = () => React.useContext(AlertContext);