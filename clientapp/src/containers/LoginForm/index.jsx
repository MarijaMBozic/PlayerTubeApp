import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { useHistory } from "react-router-dom";
import LoginFormUI from "./../../components/LoginFormUI";
import { loginUser } from "../../actions/user";
import "./index.css";

function LoginForm({ handleModal }) {
  const history = useHistory();
  const dispatch = useDispatch();
  const [loginData, setloginData] = useState([]);

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
    handleModal();
  };

  return (
    <LoginFormUI
      handleSubmitLogin={handleSubmitLogin}
      handleChange={handleChange}
      loginData={loginData}
    />
  );
}

export default LoginForm;
