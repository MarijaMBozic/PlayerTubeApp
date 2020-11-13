import React from "react";
import isAuthenticated from "../../../service/Authentication/isAuthenticates.js";
import LoginForm from "./../LoginForm";
import UserInfo from "./../../UserInfo";
import "./index.scss";

function Login() {
  const isAuth = isAuthenticated();
  return (
    <div className="login-item">
      {isAuth ? (
        <div>
          <UserInfo />
        </div>
      ) : (
        <div>
          <LoginForm />
        </div>
      )}
    </div>
  );
}

export default Login;
