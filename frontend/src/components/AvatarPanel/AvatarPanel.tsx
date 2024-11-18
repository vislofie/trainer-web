import React from 'react'
import './AvatarPanel.css'

interface Props {
    onLogout: () => void;
}

const AvatarPanel = React.forwardRef<HTMLUListElement, Props>(({onLogout}, ref) => {
  return (
    <div className="avatar-panel-container">
        <ul ref={ref}>
            <li onClick={onLogout} style={{cursor: 'pointer'}}>
                Sign out
            </li>
        </ul>
    </div>
    
  );
})

export default AvatarPanel
