import { getArrayOfDatesFrom, getDateIn, getDayOfWeek, getDayOfWeekByID } from '../../../helpers/DateHelper';
import './CalendarPanel.css'

type Props = {}

const currentDate = new Date();

const CalendarPanel = (props: Props) => {
  return (
    <div className="calendar-container">
      <h1>February, 2024</h1>
      <div className="days-container">
        {getArrayOfDatesFrom(currentDate)}
      </div>      
    </div>
    
  )
}

export default CalendarPanel
