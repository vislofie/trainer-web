import BigSearchablePanel from '../BigSearchablePanel/BigSearchablePanel'
import {useEffect, useState} from 'react';

const WorkoutPanel = () => {
  
  const [myWorkouts, setMyWorkouts] = useState<React.ReactNode[]>([]);
  const [approvedWorkouts, setApprovedWorkouts] = useState<React.ReactNode[]>([]);
  useEffect(() => {
    
    setMyWorkouts([]);
    setApprovedWorkouts([]);
  }, [myWorkouts, approvedWorkouts])
  return (
    <BigSearchablePanel 
        onSearch={(searchText) => {console.log(searchText)}}
        
        button0Text="Add workouts"
        button0Selected={true}
        button1Text="All workouts"
        button1Selected={false}
        button2Text="Approved workouts"
        button2Selected={true}
        button3Text="My workouts"
        button3Selected={true}
        
        firstSectionContent={myWorkouts}
        secondSectionContent={approvedWorkouts}
    />
  )
}

export default WorkoutPanel