import React,{useState} from 'react';
import LoginFormUI from '../LoginFormUI';
import './index.scss';
import Login from './../../service/ApiCall/login.js';
import RegistrationForm from './../RegistrationForm/index';

function LoginForm(){
  const [loginData, setloginData] = useState([]);
  const [isHiddenModal, setHiddenModal]=useState(true);

  const handleModal=()=>{
    setHiddenModal(!isHiddenModal)
}

  const handleChange = (fieldName) => (e) => {
    setloginData({
        ...loginData,
        [fieldName]: e.target.value
    })
  };

  const handleSubmitLogin = (e) => {
    e.preventDefault();
    Login(loginData)
  }

  return(
      <div className="login-wrap">
        <LoginFormUI
          loginData={loginData}
          handleChange={handleChange}
          handleSubmitLogin={handleSubmitLogin}
          handleModal={handleModal}
          />
          {
            !isHiddenModal?(
            <RegistrationForm
              handleModal={handleModal}
            />):''
          }
      </div>
  )
}

export default LoginForm;