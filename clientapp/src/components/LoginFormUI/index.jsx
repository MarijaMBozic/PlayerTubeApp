import React from 'react';


function LoginFormUI(props) {
    const {
        loginData,
        handleChange,
        handleSubmitLogin, 
        handleModal
    }=props

    const {
        email, 
        password
    }=loginData

    return (
        <div>
            <form onSubmit={handleSubmitLogin}>
                <ul>
                    <li>
                    <input
                        type="text"
                        name="email"   
                        value={email || ''}                                                  
                        placeholder="Email"
                        className="in-text large"
                        onChange={handleChange("email")}
                        />
                    </li>
                    <li>
                    <input
                        type="password"
                        name="password"
                        value={password || ''}                                                    
                        placeholder="Password"
                        className="in-pass large"
                        onChange={handleChange("password")}
                    />
                    </li>
                
                    <li className="last">
                        <button className="btn orange" type="submit">Login</button>  
                        <button type="button" className="btn orange" onClick={handleModal}>Registration</button> 
                    </li>                 
                </ul>                                                                                             
            </form>            
        </div>
    )
}

export default LoginFormUI
