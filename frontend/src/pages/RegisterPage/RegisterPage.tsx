import RegisterPanel from '../../components/AuthPanels/RegisterPanel/RegisterPanel'
import Navbar from '../../components/Navbar/Navbar'
import "./RegisterPage.css"
 
type Props = {}

const RegisterPage = (props: Props) => {
  return (
    <>
    <div className="content-box">
        <Navbar/>
        <div className="login-body">
            <RegisterPanel/>
        </div>
    </div>
    
    </>
  )
}

export default RegisterPage