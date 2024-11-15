import TextField from '../TextField/TextField';
import './LoginPanel.css'
import mailicon from "../../assets/icons/mail.svg"
import userIcon from "../../assets/icons/user.svg"
import passwordIcon from "../../assets/icons/lock.svg"
import Checkbox from '../Checkbox/Checkbox';
import { useState } from 'react';

interface Props {

}

const LoginPanel = (props: Props) => {
  const [authMode, setAuthMode] = useState("login");

  return (
    <>
    <div className="panel-container">
        {authMode == "login" ?
        (
          <>
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
            <a onClick={() => setAuthMode("register")}>Sign up</a>
          </p>
          </>
          
        ) :
        (
          <>
          <h1>Sign up</h1>
          <TextField icon={mailicon} placeholder='Email' inputType='email'/>
          <TextField icon={userIcon} placeholder='Username' inputType='text'/>
          <TextField icon={passwordIcon} placeholder='Password' inputType='password'/>
          <TextField icon={passwordIcon} placeholder='Confirm Password' inputType='password'/>
          <button className='panel-signup-btn'>
            Sign up
          </button>
          <p className='signup-label'>Aldready have an account?
            <a onClick={() => setAuthMode("login")}>Sign in</a>
          </p>
          </>
        )
        }
        
    </div>
    
    </>
    
  )
}

export default LoginPanel