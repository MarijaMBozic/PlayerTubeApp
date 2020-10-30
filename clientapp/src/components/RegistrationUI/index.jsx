import React from 'react'
import './index.scss'

function RegistrationUI(props) {
    const {
        registrationData,
        handleChange,
        handleSubmit,
        handleModal
        } = props;

    const {
        email,
        password,
        username
    } = registrationData

    return (
        <div className="registrationForm">            
            < form onSubmit={handleSubmit} >            
                <div className="modal-container">
                    <div className="modalAdd-item">
                    <h2>Registration</h2>
                    <label className="regLabel-item">
                        Email:
                        <input
                            type="text"
                            name="email"
                            value={email || ''}
                            onChange={handleChange("email")}
                            placeholder="Email"
                        />                        
                    </label>              
                
                    <label className="regLabel-item">
                        Passworde:
                        <input
                            type="text"
                            name="password"
                            value={password || ''}
                            onChange={handleChange("password")}
                            placeholder="Password"
                        />                       
                    </label>              
                
                    <label className="regLabel-item">
                            Username:
                    <input
                            type="text"
                            name="username"
                            value={username || ''}
                            onChange={handleChange("username")}
                            placeholder="username"
                        />                       
                    </label>
                    <label className="regLabel-item">                                   
                    <button className="btn" type="button" onClick={handleModal}>Quit</button>
                    <button className="btn" type="submit">Register</button>
                    </label>
                </div>
                </div>
            </form >
        </div >
    )
}

export default RegistrationUI

