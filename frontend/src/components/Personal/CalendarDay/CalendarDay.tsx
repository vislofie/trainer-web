import './CalendarDay.css'
import penIcon from '../../../assets/icons/personal cabient/pencil.svg'

interface Props {
    day: number;
    dayOfWeek: string;
    isToday?: boolean;
}

const CalendarDay = ({day, dayOfWeek, isToday}: Props) => {
  return (
    <div className="day-container">
        <div className="filler">
        </div>
        <div className="date">
            <h4>{dayOfWeek}</h4>
            {isToday ? <p className='today-day'>{day}</p> : <p>{day}</p>}    
        </div>
        <div className="edit-container">
            <img src={penIcon} style={{cursor: 'pointer'}}/>
        </div>
    </div>
  )
}

export default CalendarDay