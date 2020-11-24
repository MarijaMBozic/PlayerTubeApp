import React, { useState } from "react";
import ReactDOM from "react-dom";
import SignInSignUpUI from "./../../components/SignInSignUpUI";

function SignInSignUp({ handleModal }) {
  const [signUp, setSignUp] = useState(false);

  const hanldeSignUp = () => {
    setSignUp(!signUp);
  };

  return ReactDOM.createPortal(
    <SignInSignUpUI hanldeSignUp={hanldeSignUp} handleModal={handleModal} />,
    document.getElementById("modal")
  );
}

export default SignInSignUp;
