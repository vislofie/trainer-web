import './Alert.css'

export enum AlertType {
    Notification,
    Action
}

type AlertProps = {
    alertType: AlertType;
    alertState: boolean;
    title: string;
    description: string;

    onConfirm: () => void;
    onCancel: () => void;
}

const Alert = ({alertType, alertState, title, description, onConfirm, onCancel} : AlertProps) => {
  return alertState ?
    <div className="popup-overlay">
        <div className="alert-panel">
            <h1>
                {title}
            </h1>
            <p>
                {description}
            </p>

            <div className="buttons-panel">
                {alertType === AlertType.Notification && 
                <>
                    <button onClick={onConfirm}>
                        Ok
                    </button>
                </>
                }
                {alertType === AlertType.Action &&
                <>
                    <button onClick={onConfirm}>
                        Yes
                    </button>
                    <button onClick={onCancel}>
                        No
                    </button>
                </>}
            </div>
        </div>    
    </div>
    
  : 
  null;
}

export default Alert