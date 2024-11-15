import "./Navbar.css"
import logo from '../../assets/icons/dumbbell.svg'
import { Link } from "react-router-dom"

const Navbar = () => {
  return (
    <>
    <div className="header">
      <Link to={""} className="header-item first-item">
        <img alt="logo" src={logo} className="logo"/>
      </Link>
      <div className="navigation-labels header-item">
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
      </div>
      <Link to={"/auth"} className="header-item last-item">
        <button className="login-btn">
          Login
        </button>
      </Link>
    </div>

    <div className="header-mobile">
      <Link to={""} className="mobile-header-item mobile-first-item">
        <button className="header-menu-btn">
          ---
        </button>
      </Link>
      <Link to={""} className="mobile-header-item">
        <img alt="logo" src={logo} className="mobile-logo"/>
      </Link>
      <Link to={""} className="mobile-header-item mobile-last-item">
        <button className="header-login-btn">
          Login
        </button>
      </Link>
      </div>
</>
  )
}

export default Navbar