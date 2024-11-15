import '../AuthPanel.css'
import mailicon from "../../../assets/icons/mail.svg"
import passwordIcon from "../../../assets/icons/lock.svg"
import { Link } from 'react-router-dom';
import Checkbox from '../../Checkbox/Checkbox';
import TextField from '../../TextField/TextField';
import * as Yup from "yup"
import { useAuth } from '../../../context/useAuth';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';

interface Props {

}

type LoginFormInputs = {
  email: string;
  password: string;
}

const validation = Yup.object().shape({
  email: Yup.string().email("Pass an actual email").required("Email is required"),
  password: Yup.string().required("Password is required")
})

const LoginPanel = (props: Props) => {
  const { loginUser } = useAuth();
  const { register, handleSubmit, formState: {errors}} = useForm<LoginFormInputs>({resolver: yupResolver(validation)})

  const handleLogin = ( form: LoginFormInputs ) => {
    loginUser(form.email, form.password);
  }

  return (
    <>
    <form onSubmit={handleSubmit(handleLogin)} className='panel-container'>
        <h1>Login</h1>
        <TextField icon={mailicon} placeholder='Email' inputType='text' {...register('email')}/>
        {errors.email && <p className="error">{errors.email.message}</p>}
        <TextField icon={passwordIcon} placeholder='Password' inputType='password' {...register('password')}/>
        {errors.password && <p className="error">{errors.password.message}</p>}
        <div className="control-underfield">
          <Checkbox label='Remember me'/>
          <a>
            Forgot password?
          </a>
        </div>
        <button type="submit" className='panel-login-btn'>
          Login
        </button>
        <p className='signup-label'>Don't have an account?
          <Link to="/signup">Sign up</Link>
        </p>
    </form>
    
    </>
  )
}

export default LoginPanel
