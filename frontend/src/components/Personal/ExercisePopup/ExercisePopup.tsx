import './ExercisePopup.css'
import { Exercise } from '../../../models/Exercise';
import { getFileUrl } from '../../../services/FileService';

interface Props {
    onClose: () => void;
    exercise: Exercise;
}

const ExercisePopup = ({onClose, exercise}: Props) => {

  return (
    <div className="popup-overlay">
        <div className="popup-container">
            <h1>
                {exercise.title}
            </h1>
            <video src={getFileUrl(exercise.videoId)} controls className='popup-player'/>
            <h2 className='info-category'>
                Exercise instructions
            </h2>
            <p className='info-value'>
                {exercise.description}
            </p>
            <h2 className='info-category'>
                Involved muscle groups
            </h2>
            <p className='info-value'>
                {exercise.muscleGroups.map(mg => mg.name).join(', ')}
            </p>
            <h2 className='info-category'>
                Exercise level
            </h2>
            <p className='info-value'>
                {exercise.exerciseLevel.name}
            </p>

            <div className="button-container">
                <button>
                    Add to workout
                </button>
                {!exercise.isApproved && (
                <button>
                    Edit exercise
                </button>
                )}
            </div>
        </div>
        <div className="popup-click-container" style={{cursor: 'pointer'}} onClick={onClose}/>
    </div>
  )
}

export default ExercisePopup