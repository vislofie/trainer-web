import '../AuthPanel.css'
import mailicon from "../../../assets/icons/mail.svg"
import userIcon from "../../../assets/icons/user.svg"
import passwordIcon from "../../../assets/icons/lock.svg"
import { Link } from 'react-router-dom'
import TextField from '../../TextField/TextField'

interface Props {

}

const RegisterPanel = (props: Props) => {

  return (
    <>
    <div className="panel-container">
        <h1>Sign up</h1>
        <TextField icon={mailicon} placeholder='Email' inputType='text'/>
        <TextField icon={userIcon} placeholder='Username' inputType='text'/>
        <TextField icon={passwordIcon} placeholder='Password' inputType='password'/>
        <TextField icon={passwordIcon} placeholder='Confirm password' inputType='password'/>
        <button className='panel-login-btn'>
          Sign up
        </button>
        <p className='signup-label'>Already have an account?
          <Link to="/signin">Sign in</Link>
        </p>
    </div>
    
    </>
    
  )
}

export default RegisterPanel