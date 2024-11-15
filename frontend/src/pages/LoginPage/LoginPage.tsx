import LoginPanel from '../../components/AuthPanels/LoginPanel/LoginPanel'
import Navbar from '../../components/Navbar/Navbar'
import "./LoginPage.css"
 
type Props = {}

const LoginPage = (props: Props) => {
  return (
    <>
    <div className="content-box">
        <Navbar/>
        <div className="login-body">
            <LoginPanel/>
        </div>
    </div>
    
    </>
  )
}

export default LoginPage