import React from "react";
import "./index.css";

function LoginFormUI(props) {
  const { loginData, handleChange, handleSubmitLogin, handleModal } = props;
  const { email, password } = loginData;

  return (
    <form action="#" className="sign-in-form" id="form">
    <h2 className="title">Sign in</h2>
    <div className="input-field">
      <i className="fas fa-envelope"></i>
      <input
              type="text"
              name="email"
              value={email || ""}
              placeholder="Email"
              className="in-text large"
              onChange={handleChange("email")}
            />
    </div>
    <div className="input-field">
      <i className="fas fa-lock"></i>
      <input
              type="password"
              name="password"
              value={password || ""}
              placeholder="Password"
              className="in-pass large"
              onChange={handleChange("password")}
            />
    </div>
    <input type="submit" onClick={handleSubmitLogin} value="Login" className="btn solid" />
  </form>
  );
}

export default LoginFormUI;
