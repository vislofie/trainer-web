import React from 'react';
import './TextField.css';

type TextFieldProps = {
  icon?: string;
  inputType: string;
  placeholder: string;
  value?: string;
  onChange?: React.ChangeEventHandler<HTMLInputElement>;
  [key: string]: any;
};

const TextField = React.forwardRef<HTMLInputElement, TextFieldProps>(
  ({ icon, placeholder, inputType, onChange, value, ...rest }, ref) => {
    return (
      <div className="input-filler">
        <input {...rest} placeholder={placeholder} type={inputType} ref={ref} onChange={onChange} value={value}/>
        {icon && <img src={icon} alt="" />}
      </div>
    );
  }
);

export default TextField
