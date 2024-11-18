import './CalendarDay.css'
import penIcon from '../../../assets/icons/personal cabient/pencil.svg'

interface Props {
    day: number;
    dayOfWeek: string;
    isToday?: boolean;
    trainingName?: string;
}

const CalendarDay = ({day, dayOfWeek, isToday, trainingName}: Props) => {
  return (
    <div className="main-container">
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
        {trainingName && (
            <div className="training-name" style={{cursor: 'pointer'}}>
                {trainingName}
            </div>
        )}
    </div>
    
  )
}

export default CalendarDay