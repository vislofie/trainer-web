import './SideNavbar.css'
import lineChartIcon from "../../../assets/icons/personal cabient/line-chart.svg"
import calendarIcon from "../../../assets/icons/personal cabient/calendar-range.svg"
import exerciseIcon from "../../../assets/icons/personal cabient/person-standing.svg"
import workoutIcon from "../../../assets/icons/personal cabient/hand-metal.svg"
import { useNavigate } from 'react-router'

type Props = {
    selectedIndex: number;
    onPageChanged: (index: number) => void;
}

const selectedIconClassName = 'active-icon';
const regularIconClassName = 'inactive-icon'

const SideNavbar = ({selectedIndex, onPageChanged}: Props) => {
  return (
    <div className="sidebar">
        <img src={lineChartIcon} 
             style={{cursor: 'pointer'}} 
             className={selectedIndex == 0 ? selectedIconClassName : regularIconClassName} 
             onClick={(e) => onPageChanged(0)}/>
        <img src={calendarIcon} 
             style={{cursor: 'pointer'}} 
             className={selectedIndex == 1 ? selectedIconClassName : regularIconClassName}
             onClick={(e) => onPageChanged(1)}/>
        <img src={exerciseIcon} 
             style={{cursor: 'pointer'}} 
             className={selectedIndex == 2 ? selectedIconClassName : regularIconClassName}
             onClick={(e) => onPageChanged(2)}/>
        <img src={workoutIcon} 
             style={{cursor: 'pointer'}} 
             className={selectedIndex == 3 ? selectedIconClassName : regularIconClassName}
             onClick={(e) => onPageChanged(3)}/>
    </div>
  )
}

export default SideNavbar