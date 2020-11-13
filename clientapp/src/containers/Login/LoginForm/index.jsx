import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { useHistory } from "react-router-dom";
import LoginFormUI from "../../../components/LoginFormUI";
import RegistrationForm from "../../RegistrationForm";
import { loginUser } from "./../../../actions/user";
import "./index.scss";

function LoginForm() {
  const history = useHistory();
  const dispatch = useDispatch();
  const [loginData, setloginData] = useState([]);
  const [isHiddenModal, setHiddenModal] = useState(true);

  const handleModal = () => {
    setHiddenModal(!isHiddenModal);
  };

  const handleChange = (fieldName) => (e) => {
    setloginData({
      ...loginData,
      [fieldName]: e.target.value,
    });
  };

  const handleSubmitLogin = (e) => {
    e.preventDefault();
    dispatch(loginUser(loginData));
    history.push(`/`);
  };

  return (
    <div className="login-wrap">
      <LoginFormUI
        loginData={loginData}
        handleChange={handleChange}
        handleSubmitLogin={handleSubmitLogin}
        handleModal={handleModal}
      />
      {!isHiddenModal ? <RegistrationForm handleModal={handleModal} /> : ""}
    </div>
  );
}

export default LoginForm;
