import styles from './WorkoutCard.module.css'

interface Props {
    name: string;
    level: string;
    length: string;
    isYours: boolean;
}

const WorkoutCard = (props: Props) => {
    return (
        <div className={styles["card-container"]}>
            <div className={styles["title-row"]}>
                <h2>{props.name}</h2>
            </div>
        </div>
    )
} 

export default WorkoutCard