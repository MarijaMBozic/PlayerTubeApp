import React, { useState } from 'react'
import ReactDOM from "react-dom";
import Registration from './../../service/ApiCall/registration.js'
import RegistrationUI from './../../components/RegistrationUI'

function RegistrationForm(props) {
    const {handleModal}=props;
    const [registrationData, setRegistrationData] = useState({});


    const handleChange = (fieldname) => (e) => {
        setRegistrationData({
            ...registrationData,
            [fieldname]: e.target.value
        })
    };

    const handleSubmit = (e) => {
        e.preventDefault();
            Registration(registrationData)        
    }

    return ReactDOM.createPortal(
        <>
            <RegistrationUI
                registrationData={registrationData}
                handleChange={handleChange}
                handleSubmit={handleSubmit}
                handleModal={handleModal}
            />
        </>,
         document.getElementById('modal')
    )
}

export default RegistrationForm;