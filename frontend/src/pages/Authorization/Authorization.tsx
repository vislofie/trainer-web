import Navbar from '../../components/Navbar/Navbar'
import "./Authorization.css"
import LoginPanel from '../../components/LoginPanel/LoginPanel'
 
type Props = {}

const Authorization = (props: Props) => {
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

export default Authorization