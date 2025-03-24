import './PersonalPage.css'
import Navbar from '../../components/Navbar/Navbar'
import SideNavbar from '../../components/Personal/SideNavbar/SideNavbar'
import { useState } from 'react'
import StatisticsPanel from '../../components/Personal/StatisticsPanel/StatisticsPanel'
import CalendarPanel from '../../components/Personal/CalendarPanel/CalendarPanel'
import ExercisePanel from '../../components/Personal/ExercisePanel/ExercisePanel'
import WorkoutPanel from '../../components/Personal/WorkoutPanel/WorkoutPanel'

const PersonalPage = () => {
    
    const [pageIndex, setPageIndex] = useState(0);

    const pageComponents = [
        <StatisticsPanel />,
        <CalendarPanel />,
        <ExercisePanel />,
        <WorkoutPanel />
    ]
    

  return (
    <>
    <Navbar showNavigationLabels={false}/>
    <SideNavbar selectedIndex={pageIndex} onPageChanged={(i) => setPageIndex(i)}/>
    <div className="personal-panel-container">
        {pageComponents[pageIndex]}
    </div>
    </>
  )
}

export default PersonalPage