import React from 'react'
import './index.css'

function RegistrationUI(props) {
    const {
        registrationData,
        handleChange,
        handleSubmit,
        } = props;

    const {
        email,
        password,
        username
    } = registrationData

    return ( 
        <form action="#" className="sign-up-form" id="form"> 
        <h2 className="title">Sign up</h2>
        <div className="input-field">
          <i className="fas fa-user"></i>
          <input 
            type="text"
            name="username"
            value={username || ''}
            onChange={handleChange("username")}
            placeholder="Username"
          />
        </div>
        <div className="input-field">
          <i className="fas fa-envelope"></i>
          <input
            type="text"
            name="email"
            value={email || ''}
            onChange={handleChange("email")}
            placeholder="Email"
          /> 
        </div>
        <div className="input-field">
          <i className="fas fa-lock"></i>          
          <input
            type="text"
            name="password"
            value={password || ''}
            onChange={handleChange("password")}
            placeholder="Password"
          />   
        </div>
        <input type="submit" on onClick={handleSubmit} className="btn" value="Sign up" />
      </form>       
    )
}

export default RegistrationUI

