import BigSearchablePanel from '../BigSearchablePanel/BigSearchablePanel'
import { useEffect, useState } from "react";
import { Workout } from "../../../models/Workout";
import { getWorkouts } from "../../../services/WorkoutService.tsx";
import ExerciseCard from "../ExerciseCard/ExerciseCard.tsx";
import { getFileUrl } from "../../../services/FileService.tsx";

const WorkoutPanel = () => {
  const [isCreatePopupActive, setCreatePopupActive] = useState<boolean>(false);
  const [workouts, setWorkouts] = useState<Workout[]>([]);
  const [filteredWorkouts, setFilteredWorkouts] = useState<Workout[]>([])
  const [filterTypes, setFilterTypes] = useState<number>(6);
  const [refresh, setRefresh] = useState(0);
  
  const handleSearchWorkout = (searchTerm: string) => {
    if (searchTerm === '') {
      setFilteredWorkouts(workouts);
    }
    else {
      setFilteredWorkouts(workouts.filter(wrk => wrk.workoutName.toLowerCase().includes(searchTerm.toLowerCase())));
    }
  }
  
  const handleWorkoutTypeChange = (type: number) => {
    setFilterTypes(type);
  }
  
  const handlePopupVisibility = (visible: boolean) => {
    setCreatePopupActive(visible);
    setRefresh(val => val + 1);
  }
  
  useEffect(() => {
    const getWorkoutsInit = async() => {
      const workouts = await getWorkouts();
      setWorkouts(workouts!);
      setFilteredWorkouts(workouts!);
    }
    
    getWorkoutsInit();
  }, [refresh])
  
  return (
    <BigSearchablePanel 
        onSearch={(searchText) => handleSearchWorkout(searchText)}
        
        button0Text="Add workouts"
        button0Selected={true}
        button1Text="All workouts"
        button1Selected={filterTypes !== 6}
        button1Clicked={() => handleWorkoutTypeChange(6)}
        button2Text="Approved workouts"
        button2Selected={filterTypes !== 3}
        button2Clicked={() => handleWorkoutTypeChange(3)}
        button3Text="My workouts"
        button3Selected={filterTypes !== 2}
        button3Clicked={() => handleWorkoutTypeChange(2)}
        
        firstSectionContent={filterTypes % 2 === 0 &&
        (
          <>
          <h1>
            Your workouts
          </h1>
          <div className="workout-cards">
            {filteredWorkouts && filteredWorkouts.filter(wrk => !wrk.isApproved).map((workout, index) => (
                <ExerciseCard
                  key={index}
                  name={workout.workoutName}
                  muscleGroups={[{id: 0, name: "Doesn't matter"}]}
                  lastPR={'-'}
                  imageUrl={getFileUrl(0)}
                  onExerciseClick={() => console.log("hey!")}
                />
            ))}
          </div>
          </>      
        )}
        secondSectionContent={filterTypes % 3 === 0 &&
        (
          <>
          <h1>
            Approved workouts
          </h1>
          <div className="workout-cards">
            
          </div>
          </>        
        )}
    />
  )
}

export default WorkoutPanel