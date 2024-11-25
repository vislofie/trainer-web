import { getArrayOfDatesFrom } from '../../../helpers/DateHelper';
import CalendarCard from '../CalendarCard/CalendarCard';
import './CalendarPanel.css'

type Props = {}

const currentDate = new Date();

const CalendarPanel = (props: Props) => {
  return (
    <>
    <div className="calendar-container">
      <h1>February, 2024</h1>
      <div className="days-container">
        {getArrayOfDatesFrom(currentDate)}
      </div>      
    </div>
    <div className="cards">
      <div className="card-item">
        <CalendarCard title='Last workout' subtitle='Chest & Back' underText='5 February, 2024'/>
      </div>
      <div className="card-item">
        <CalendarCard title='Next workout' subtitle='Arms & Shoulders' underText='10 February, 2024'/> 
      </div>
      <div className="card-item">
        <CalendarCard title='PRs beat' subtitle='4 new PRs' underText="You're doing well!"/> 
      </div>
      <div className="card-item">
        <CalendarCard title='This month' subtitle='3 workouts' underText="Nice!"/> 
      </div>
    </div>
    
    </>
    
    
  )
}

export default CalendarPanel
