import "./Navbar.css"
import logo from '../../assets/icons/dumbbell.svg'
import avatar from "../../assets/icons/avatar.svg"
import { Link, useNavigate } from "react-router-dom"
import { useAuth } from "../../context/useAuth";
import { useEffect, useState } from "react";
import AvatarPanel from "../AvatarPanel/AvatarPanel";
import { useOutsideClick } from "outsideclick-react";

interface Props {
  showNavigationLabels: boolean;
}

const Navbar = ({ showNavigationLabels }: Props) => {
  const navigate = useNavigate();

  const { isLoggedIn, logout } = useAuth();
  const [loggedIn, setLoggedIn] = useState(false);
  const [avatarMenuVisible, setAvatarMenuVisible] = useState(false);

  const ref = useOutsideClick((e) => setAvatarMenuVisible(false));

  useEffect(() => {
    setLoggedIn(isLoggedIn());
  }, [])

  const onHandleLogout = () => {
    logout();
    setLoggedIn(false);
  }

  return (
    <>
    <div className="header">
      <div className="header-item first-item">
        <img alt="logo" src={logo} className="logo" onClick={(e) => navigate("/")} style={{cursor: 'pointer'}}/>
      </div>
      <div className="navigation-labels header-item">
        {showNavigationLabels && (
          <>
          <Link to={""}>
            <h2 className="navigation-header">
              Training programs
            </h2>
          </Link>
          <Link to={""}>
            <h2 className="navigation-header">
              About us
            </h2>
          </Link>
          <Link to={""}>
            <h2 className="navigation-header">
              Pricing
            </h2>
          </Link>
          <Link to={""}>
            <h2 className="navigation-header">
              Support
            </h2>
          </Link>
          </>
        )}
        
      </div>
      {loggedIn ?
      (
        <>
        <div className="avatar-container">
          <a className="header-item last-item" onClick={() => setAvatarMenuVisible(true)} ref={ref} style={{cursor: 'pointer'}}>
            <img src={avatar}/>
          </a> 
          <div className="below-avatar">
            {avatarMenuVisible && <AvatarPanel ref={ref} onLogout={onHandleLogout}/>}
          </div>
        </div>
        </>
     ) 
       :
       (<div className="header-item last-item">
       <button className="login-btn" onClick={(e) => navigate("/signin")}>
         Login
       </button>
      </div>)}
    </div>

    <div className="header-mobile">
      <Link to={""} className="mobile-header-item mobile-first-item">
        <button className="header-menu-btn">
          ---
        </button>
      </Link>
      <Link to={"/"} className="mobile-header-item">
        <img alt="logo" src={logo} className="mobile-logo"/>
      </Link>

      {loggedIn ?
      (<a className="mobile-header-item mobile-last-item" ref={ref}>
        <img src={avatar}/>
       </a>) 
       :
       (<Link to={"/signin"} className="mobile-header-item mobile-last-item">
       <button className="header-login-btn">
         Login
       </button>
      </Link>)
    }
      </div>
</>
  )
}

export default Navbar