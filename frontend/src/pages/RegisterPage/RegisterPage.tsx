import RegisterPanel from '../../components/AuthPanels/RegisterPanel/RegisterPanel'
import Navbar from '../../components/Navbar/Navbar'
import "./RegisterPage.css"

const RegisterPage = () => {
  return (
    <>
    <div className="content-box">
        <Navbar showNavigationLabels={false}/>
        <div className="login-body">
            <RegisterPanel/>
        </div>
    </div>
    
    </>
  )
}

export default RegisterPage