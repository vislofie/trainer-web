import styles from './ExerciseCard.module.css'
import plusIcon from '../../../assets/icons/personal cabient/plus.svg'
import { MuscleGroup } from '../../../models/Exercise';

interface Props {
    name: string;
    imageUrl: string;
    muscleGroups: MuscleGroup[];
    lastPR: string;
    onExerciseClick: () => void;
}

const ExerciseCard = ({name, muscleGroups, lastPR, imageUrl, onExerciseClick}: Props) => {
  return (
    <div className={styles["card-container"]} style={{backgroundImage: "url(" + imageUrl + ")"}}>
        <div className={styles["title-row"]}>
            <h2 style={{cursor: 'pointer'}} onClick={onExerciseClick}>
                {name}
            </h2>
            <img src={plusIcon} style={{cursor: 'pointer'}}/>
        </div>
        
        <div className={styles["subtitle-container"]}>
            <div className={styles["subtitle-headers"]}>
                <p className={styles['header-left']}>Targeted muscle groups:</p>
                <p className={styles['header-right']}>Last PR:</p>
            </div>
            <div className={styles["subtitle-values"]}>
                <p className={styles['value-left']}>
                    {muscleGroups.map(mg => mg.name).join(', ')}
                </p>
                <p className={styles['value-right']}>
                    {lastPR}
                </p>
            </div>
        </div>
        
    </div>
  )
}

export default ExerciseCard