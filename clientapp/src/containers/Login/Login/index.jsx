import React from "react";
import isAuthenticated from "../../../service/Authentication/isAuthenticates.js";
import LoginForm from "./../LoginForm";
import UserInfo from "./../../UserInfo";
import "./index.css";

function Login() {
  const isAuth = isAuthenticated();
  return (
  <>
    <a href="#">
      <img src="images/1200px-Logo_of_YouTube_(2015-2017).svg.png" alt="Youtube" className="logo"/>
    </a>
    <form className="search-bar">
      <input type="search" className="search-input" placeholder="Search"/>
        <button className="search-btn">
          <i className="fas fa-search"></i>   
        </button>
    </form>
    <div className="menu-icon">
      <a href="#">
        <i className="fas fa-video"></i>
      </a>
      {isAuth ? (
      <div>
        <UserInfo />
      </div>
      ) :  (
      <a href="#" className="btn-singin">
        <i className="fas fa-user-circle"></i> 
          SIGN IN
      </a>)
      }
    </div>
  </>
  )
}


export default Login;
