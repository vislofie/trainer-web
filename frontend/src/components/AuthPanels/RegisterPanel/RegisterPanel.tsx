import '../AuthPanel.css'
import mailicon from "../../../assets/icons/mail.svg"
import userIcon from "../../../assets/icons/user.svg"
import passwordIcon from "../../../assets/icons/lock.svg"
import { Link } from 'react-router-dom'
import TextField from '../../TextField/TextField'
import * as Yup from "yup"
import { yupResolver } from '@hookform/resolvers/yup'
import { useForm } from 'react-hook-form'
import { useAuth } from '../../../context/useAuth'

interface Props {

}

type RegisterFormInputs = {
  email: string;
  username: string;
  password: string;
  confirmPassword?: string;
}

const validation = Yup.object().shape({
  email: Yup.string().email("Pass an actual email").required("Email is required"),
  username: Yup.string().required("Username is required"),
  password: Yup.string().min(8, "Password is supposed to have at least 8 digits").required("Password is required"),
  confirmPassword: Yup.string().oneOf([Yup.ref("password")], "Passwords must be the same!"),
})

const RegisterPanel = (props: Props) => {
  const { registerUser } = useAuth();
  const { register, handleSubmit, formState: {errors}} = useForm<RegisterFormInputs>({resolver: yupResolver(validation)})
  const handleRegister = ( form: RegisterFormInputs ) => {
    registerUser(form.email, form.username, form.password);
  }

  return (
    <>
    <form className="panel-container" onSubmit={handleSubmit(handleRegister)}>
        <h1>Sign up</h1>
        <TextField icon={mailicon} placeholder='Email' inputType='text' {...register('email')}/>
        {errors.email && <p className="error">{errors.email.message}</p>}
        <TextField icon={userIcon} placeholder='Username' inputType='text' {...register('username')}/>
        {errors.username && <p className="error">{errors.username.message}</p>}
        <TextField icon={passwordIcon} placeholder='Password' inputType='password' {...register('password')}/>
        {errors.password && <p className="error">{errors.password.message}</p>}
        <TextField icon={passwordIcon} placeholder='Confirm password' inputType='password' {...register('confirmPassword')}/>
        {errors.confirmPassword && <p className="error">{errors.confirmPassword.message}</p>}
        <button className='panel-login-btn' type="submit">
          Sign up
        </button>
        <p className='signup-label'>Already have an account?
          <Link to="/signin">Sign in</Link>
        </p>
    </form>
    
    </>
    
  )
}

export default RegisterPanel