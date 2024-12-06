import './ExercisePopup.css'
import { Exercise } from '../../../models/Exercise';
import { getFileUrl } from '../../../services/FileService';
import AddExercisePopup from '../AddExercisePopup/AddExercisePopup';
import { useRef, useState } from 'react';
import { getExerciseById } from '../../../services/ExerciseService';

interface Props {
    onClose: () => void;
    exercise: Exercise;
}

const ExercisePopup = ({onClose, exercise}: Props) => {
    const [editExercise, setEditExercise] = useState<boolean>();
    const [exerciseCached, setExercise] = useState<Exercise>(exercise);
    const playerRef = useRef<HTMLVideoElement>(null);

    const handleClosingPopup = () => {
        const handleAsync = async() => {
            const responseExercise = await getExerciseById(exerciseCached.id);
            if (responseExercise) {
                setExercise(responseExercise);
            }

            setEditExercise(false);
        }

        handleAsync();
    }
  return (
    <div className="popup-overlay">
        {editExercise && (<AddExercisePopup onClose={() => handleClosingPopup()} loadedExercise={exerciseCached}/>)}
        <div className="popup-container">
            <h1>
                {exerciseCached.title}
            </h1>
            <video src={getFileUrl(exerciseCached.videoId)} controls className='popup-player' ref={playerRef}/>
            <h2 className='info-category'>
                Exercise instructions
            </h2>
            <p className='info-value'>
                {exerciseCached.description}
            </p>
            <h2 className='info-category'>
                Involved muscle groups
            </h2>
            <p className='info-value'>
                {exerciseCached.muscleGroups.map(mg => mg.name).join(', ')}
            </p>
            <h2 className='info-category'>
                Exercise level
            </h2>
            <p className='info-value'>
                {exerciseCached.exerciseLevel.name}
            </p>

            <div className="button-container">
                <button>
                    Add to workout
                </button>
                {!exerciseCached.isApproved && (
                <button onClick={() => { setEditExercise(true); playerRef.current?.pause(); }}>
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
