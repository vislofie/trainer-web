import './WorkoutCard.module.css';
import playIcon from "../../../assets/icons/personal cabient/play.svg";
import deleteIcon from "../../../assets/icons/personal cabient/delete.svg"

import styles from './WorkoutCard.module.css'

interface Props {
    name: string;
    avgLength: string;
    onWorkoutClick: () => void;
}

const WorkoutCard = ({name, avgLength, onWorkoutClick}: Props) => {
    return (
        <div className={styles["card-container"]}>
            <div className={styles["title-row"]}>
                <h4 style={{cursor: 'pointer'}} onClick={onWorkoutClick}>
                    {name}
                </h4>
                <img src={deleteIcon} style={{cursor: 'pointer'}}/>
            </div>
    
            <div className={styles["subtitle-container"]}>
                <div className={styles["subtitle-values"]}>
                    <p className={styles['value-left']}>
                        <p>Avg length:</p>
                        <p>{avgLength}</p>
                    </p>
                    <div className={styles['value-right']}>
                        <img src={playIcon} style={{cursor: 'pointer'}}/>
                    </div>
                </div>
            </div>
        </div>
    )
};

export default WorkoutCard;