import React, { useState } from "react";
import LoginForm from "./../../containers/LoginForm";
import RegistrationForm from "./../../containers/RegistrationForm";
import "./index.css";

function SignInSignUpUI({ handleModal }) {
  const [signUp, setSignUp] = useState(false);

  const hanldeSignUp = () => {
    setSignUp(!signUp);
  };

  return (
    <div className="modal-wrap-container">
      <div className={`container ${signUp ? " sign-up-mode" : ""}`}>
        <i
          className="far fa-times-circle fa-3x"
          id="btn-close-modal"
          onClick={handleModal}
        ></i>
        <div className="forms-container">
          <div className="signin-signup">
            <LoginForm handleModal={handleModal} />
            <RegistrationForm handleModal={handleModal} />
          </div>
        </div>
        <div className="panels-container">
          <div className="panel left-panel">
            <div className="content">
              <h3>New here ?</h3>
              <p>
                Lorem ipsum, dolor sit amet consectetur adipisicing elit.
                Debitis, ex ratione. Aliquid!
              </p>
              <button onClick={hanldeSignUp} className="btn transparent">
                Sign up
              </button>
            </div>
            <img
              src="./../../../resource/images/log.svg"
              className="image"
              alt=""
            />
          </div>
          <div className="panel right-panel">
            <div className="content">
              <h3>One of us ?</h3>
              <p>
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Nostrum
                laboriosam ad deleniti.
              </p>
              <button onClick={hanldeSignUp} className="btn transparent">
                Sign in
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default SignInSignUpUI;
