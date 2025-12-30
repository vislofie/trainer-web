import './ExercisePanel.css'
import ExerciseCard from '../ExerciseCard/ExerciseCard';
import AddExercisePopup from '../AddExercisePopup/AddExercisePopup';
import { useEffect, useState } from 'react';
import { getExercises } from '../../../services/ExerciseService';
import { Exercise } from '../../../models/Exercise';
import { getFileUrl } from '../../../services/FileService';
import ExercisePopup from '../ExercisePopup/ExercisePopup';
import BigSearchablePanel from "../BigSearchablePanel/BigSearchablePanel.tsx";

const ExercisePanel = () => {
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
    setRefresh(val => val + 1);
  }

  const handleExercisePopupVisibility = (visible: boolean) => {
    setExercisePopupActive(visible);
    setRefresh(val => val + 1);
  }

  const handleSearchExercise = (searchTerm: string) => {
    if (searchTerm === '') {
      setFilteredExercises(exercises);
    }
    else {
      setFilteredExercises(exercises.filter(ex => ex.title.toLowerCase().startsWith(searchTerm.toLowerCase())));
    }
  }

  const handleExerciseTypeChange = (type: number) => {
    setFilterTypes(type);
  }

  return (
    <>
    {isCreatePopupActive && (<AddExercisePopup onClose={() => handlePopupVisibility(false)}/>)}
    {isExercisePopupActive && (<ExercisePopup onClose={() => handleExercisePopupVisibility(false)} exercise={exercises.find(ex => ex.id == selectedExerciseId)!}/>)}
    <BigSearchablePanel 
        onSearch={handleSearchExercise}
        firstSectionContent={filterTypes % 2 === 0 &&
        (
          <>
          <h1>
            Your exercises
          </h1>
          <div className="exercise-cards">
            {filteredExercises && filteredExercises.filter(ex => !ex.isApproved).map((exercise, index) => (
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
        
        secondSectionContent={filterTypes % 3 === 0 && 
        (
          <>
          <h1>
            Approved exercises
          </h1>
          <div className="exercise-cards">
            {filteredExercises && filteredExercises.filter(ex => ex.isApproved).map((exercise, index) =>(
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
        
        button0Text={"Add exercise"} 
        button0Selected={true} 
        button0Clicked={() => handlePopupVisibility(true)}
        button1Text={"All exercises"}
        button1Selected={filterTypes !== 6}
        button1Clicked={() => handleExerciseTypeChange(6)}
        button2Text={"Approved exercises"}
        button2Selected={filterTypes !== 3} 
        button2Clicked={() => handleExerciseTypeChange(3)}
        button3Text={"My exercises"}
        button3Selected={filterTypes !== 2}
        button3Clicked={() => handleExerciseTypeChange(2)}
    />
    </>
  )
}

export default ExercisePanel
