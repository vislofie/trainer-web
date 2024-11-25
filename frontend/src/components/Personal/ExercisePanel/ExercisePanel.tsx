import './ExercisePanel.css'
import searchIcon from '../../../assets/icons/personal cabient/search.svg'
import ExerciseCard from '../ExerciseCard/ExerciseCard';
import AddExercisePopup from '../AddExercisePopup/AddExercisePopup';
import { useEffect, useState } from 'react';
import { getExercises } from '../../../services/ExerciseService';
import { Exercise } from '../../../models/Exercise';
import { getFileUrl } from '../../../services/FileService';

interface Props {

}

const ExercisePanel = (props: Props) => {

  const [isPopupActive, setPopupActive] = useState<boolean>(false);
  const [exercises, setExercises] = useState<Exercise[]>([]);
  const [refresh, setRefresh] = useState(0);

  useEffect(() => {
    const getExercisesInit = async () => {
      const ex = await getExercises();
      setExercises(ex!);
    }

    getExercisesInit();
  }, [refresh])

  const handlePopupVisibility = (visible: boolean) => {
    setPopupActive(visible);
    setTimeout(() => setRefresh(refresh + 1), 300);
  }

  return (
    <>
    {isPopupActive && (<AddExercisePopup onClose={() => handlePopupVisibility(false)}/>)}
    <div className="exercise-container">
      <div className="search-container">
        <div className="searchbar">
          <input type="text" placeholder='Search for exercises'/>
          <img src={searchIcon} style={{cursor: 'pointer'}}/>
        </div>
        <div className="search-container-underline"/>
      </div>
      
      <div className="exercise-menu">
        <div className="button-row">
          <div className="left-buttons">
            <button onClick={() => handlePopupVisibility(true)}>
              Add exercise
            </button>
            <button>
              All exercises
            </button>
          </div>
          <div className="right-buttons">
            <button>
              Approved exercises
            </button>
            <button>
              My exercises
            </button>
          </div>
        </div>
        <div className="exercise-list">
          <h1>
            Your exercises
          </h1>
          <div className="exercise-cards">
            {exercises.filter(ex => !ex.isApproved).map((exercise, index) => (
              <ExerciseCard key={index} name={exercise.title} muscleGroups={exercise.muscleGroups} lastPR={'-'} imageUrl={getFileUrl(exercise.pictureId)}/>
            ))}
          </div>
          <h1>
            Approved exercises
          </h1>
          <div className="exercise-cards">
            {exercises.filter(ex => ex.isApproved).map((exercise, index) =>(
              <ExerciseCard key={index} name={exercise.title} muscleGroups={exercise.muscleGroups} lastPR={'-'} imageUrl={getFileUrl(exercise.pictureId)}/>
            ))}
          </div>
        </div> 
      </div>
    </div>
    </>
    
    
  )
}

export default ExercisePanel