import React, { useState } from "react";
import { useDispatch } from "react-redux";
import ReactDOM from "react-dom";
import { registrationUser } from "../../actions/user";
import RegistrationUI from "./../../components/RegistrationUI";

function RegistrationForm(props) {
  const { handleModal } = props;
  const dispatch = useDispatch();
  const [registrationData, setRegistrationData] = useState({});

  const handleChange = (fieldname) => (e) => {
    setRegistrationData({
      ...registrationData,
      [fieldname]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    dispatch(registrationUser(registrationData));
    handleModal();
  };

  return ReactDOM.createPortal(
    <>
      <RegistrationUI
        registrationData={registrationData}
        handleChange={handleChange}
        handleSubmit={handleSubmit}
        handleModal={handleModal}
      />
    </>,
    document.getElementById("modal")
  );
}

export default RegistrationForm;
