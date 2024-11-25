import './ExerciseCard.css'
import plusIcon from '../../../assets/icons/personal cabient/plus.svg'
import { MuscleGroup } from '../../../models/Exercise';

interface Props {
    name: string;
    imageUrl: string;
    muscleGroups: MuscleGroup[];
    lastPR: string;
}

const ExerciseCard = ({name, muscleGroups, lastPR, imageUrl}: Props) => {
  return (
    <div className="card-container" style={{backgroundImage: "url(" + imageUrl + ")"}}>
        <div className="title-row">
            <h2>
                {name}
            </h2>
            <img src={plusIcon} style={{cursor: 'pointer'}}/>
        </div>
        
        <div className="subtitle-container">
            <div className="subtitle-headers">
                <p className='header-left'>Targeted muscle groups:</p>
                <p className='header-right'>Last PR:</p>
            </div>
            <div className="subtitle-values">
                <p className='value-left'>
                    {muscleGroups.map(mg => mg.name).join(', ')}
                </p>
                <p className='value-right'>
                    {lastPR}
                </p>
            </div>
        </div>
        
    </div>
  )
}

export default ExerciseCard