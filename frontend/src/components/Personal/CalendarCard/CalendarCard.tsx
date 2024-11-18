import './CalendarCard.css'

interface Props {
    title: string;
    subtitle: string;
    underText: string;
}

const CalendarCard = ({title, subtitle, underText}: Props) => {
  return (
    <>
    <h1 className='card-title'>{title}</h1>
    <h3 className='card-subtitle' style={{cursor: 'pointer'}}>{subtitle}</h3>
    <div className="undertext">
        <p>
        {underText}
        </p>
    </div>
    </>
  )
}

export default CalendarCard