import './TextField.css'

type Props = {
    icon: string;
    inputType: string;
    placeholder: string;
}

const TextField = ({icon, placeholder, inputType}: Props) => {
  return (
    <>
        <div className="input-filler">
            <input placeholder={placeholder} type={inputType}/>
            <img src={icon}/>
        </div>
    </>
    
  )
}

export default TextField