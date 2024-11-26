import './ExercisePanel.css'
import searchIcon from '../../../assets/icons/personal cabient/search.svg'
import ExerciseCard from '../ExerciseCard/ExerciseCard';
import AddExercisePopup from '../AddExercisePopup/AddExercisePopup';
import { useEffect, useState } from 'react';
import { getExercises } from '../../../services/ExerciseService';
import { Exercise } from '../../../models/Exercise';
import { getFileUrl } from '../../../services/FileService';
import ExercisePopup from '../ExercisePopup/ExercisePopup';

interface Props {

}

const ExercisePanel = (props: Props) => {

  const [isCreatePopupActive, setCreatePopupActive] = useState<boolean>(false);
  const [isExercisePopupActive, setExercisePopupActive] = useState<boolean>(false);
  const [exercises, setExercises] = useState<Exercise[]>([]);
  const [filteredExercises, setFilteredExercises] = useState<Exercise[]>([]);
  const [filterTypes, setFilterTypes] = useState<number>(6);
  const [refresh, setRefresh] = useState(0);
  const [selectedExerciseId, setExerciseId] = useState(-1);

  useEffect(() => {
    const getExercisesInit = async () => {
      const ex = await getExercises();
      setExercises(ex!);
      setFilteredExercises(ex!);
    }

    getExercisesInit();
  }, [refresh])

  const handlePopupVisibility = (visible: boolean) => {
    setCreatePopupActive(visible);
    setTimeout(() => setRefresh(refresh + 1), 300);
  }

  const handleExercisePopupVisibility = (visible: boolean) => {
    setExercisePopupActive(visible);
  }

  const handleSearchExercise = (e: React.ChangeEvent<HTMLInputElement>) => {
    const searchTerm = e.target.value.toLowerCase();
    if (searchTerm === '') {
      setFilteredExercises(exercises);
    }
    else {
      setFilteredExercises(exercises.filter(ex => ex.title.startsWith(searchTerm)));
    }
  }

  const handleExerciseTypeChange = (type: number) => {
    setFilterTypes(type);
  }

  return (
    <>
    {isCreatePopupActive && (<AddExercisePopup onClose={() => handlePopupVisibility(false)}/>)}
    {isExercisePopupActive && (<ExercisePopup onClose={() => handleExercisePopupVisibility(false)} exercise={exercises.find(ex => ex.id == selectedExerciseId)!}/>)}
    <div className="exercise-container">
      <div className="search-container">
        <div className="searchbar">
          <input type="text" placeholder='Search for exercises' onChange={handleSearchExercise}/>
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
            <button className={filterTypes === 6 ? 'selected' : ''} onClick={() => handleExerciseTypeChange(6)}>
              All exercises
            </button>
          </div>
          <div className="right-buttons">
            <button className={filterTypes === 3 ? 'selected' : ''} onClick={() => handleExerciseTypeChange(3)}>
              Approved exercises
            </button>
            <button className={filterTypes === 2 ? 'selected' : ''} onClick={() => handleExerciseTypeChange(2)}>
              My exercises
            </button>
          </div>
        </div>
        <div className="exercise-list">
          {filterTypes % 2 === 0 &&
          (
            <>
             <h1>
              Your exercises
            </h1>
            <div className="exercise-cards">
              {filteredExercises.filter(ex => !ex.isApproved).map((exercise, index) => (
                <ExerciseCard 
                key={index} 
                name={exercise.title} 
                muscleGroups={exercise.muscleGroups} 
                lastPR={'-'} 
                imageUrl={getFileUrl(exercise.pictureId)}
                onExerciseClick={() => {handleExercisePopupVisibility(true); setExerciseId(exercise.id);}}/>
              ))}
            </div>
            </>
          )}
         
          {filterTypes % 3 === 0 && 
          (
            <>
            <h1>
              Approved exercises
            </h1>
            <div className="exercise-cards">
              {filteredExercises.filter(ex => ex.isApproved).map((exercise, index) =>(
                <ExerciseCard 
                  key={index} 
                  name={exercise.title} 
                  muscleGroups={exercise.muscleGroups} 
                  lastPR={'-'} 
                  imageUrl={getFileUrl(exercise.pictureId)}
                  onExerciseClick={() => {handleExercisePopupVisibility(true); setExerciseId(exercise.id);}}/>
              ))}
            </div>
            </>
          )}
          
        </div> 
      </div>
    </div>
    </>
    
    
  )
}

export default ExercisePanel
