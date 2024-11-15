import TextField from '../TextField/TextField';
import './LoginPanel.css'
import mailicon from "../../assets/icons/mail.svg"
import passwordIcon from "../../assets/icons/lock.svg"
import Checkbox from '../Checkbox/Checkbox';
import { Link } from 'react-router-dom';

interface Props {

}

const LoginPanel = (props: Props) => {

  return (
    <>
    <div className="panel-container">
        <h1>Login</h1>
        <TextField icon={mailicon} placeholder='Email' inputType='text'/>
        <TextField icon={passwordIcon} placeholder='Password' inputType='password'/>
        <div className="control-underfield">
          <Checkbox label='Remember me'/>
          <a>
            Forgot password?
          </a>
        </div>
        <button className='panel-login-btn'>
          Login
        </button>
        <p className='signup-label'>Don't have an account?
          <Link to="/signup">Sign up</Link>
        </p>
    </div>
    </>
  )
}

export default LoginPanel