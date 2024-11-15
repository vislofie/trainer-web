import Navbar from '../../components/Navbar/Navbar'
import "./LoginPage.css"
import LoginPanel from '../../components/LoginPanel/LoginPanel'
 
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