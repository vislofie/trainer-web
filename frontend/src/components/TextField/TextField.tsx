import React from 'react';
import './TextField.css';

type TextFieldProps = {
  icon: string;
  inputType: string;
  placeholder: string;
  [key: string]: any;
};

const TextField = React.forwardRef<HTMLInputElement, TextFieldProps>(
  ({ icon, placeholder, inputType, ...rest }, ref) => {
    return (
      <div className="input-filler">
        <input {...rest} placeholder={placeholder} type={inputType} ref={ref} />
        <img src={icon} alt="" />
      </div>
    );
  }
);

export default TextField
