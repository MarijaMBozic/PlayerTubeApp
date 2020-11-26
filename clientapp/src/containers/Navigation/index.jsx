import React, { useState } from "react";
import isAuthenticated from "../../service/Authentication/isAuthenticates.js";
import UserInfo from "../UserInfo";
import SignInSignUp from "../../page/SignInSignUp";
import "./index.css";

function Navigation() {
  const [isHiddenModal, setIsHiddenModal] = useState(true);
  const isAuth = isAuthenticated();

  const handleModal = () => {
    setIsHiddenModal(!isHiddenModal);
  };

  return (
    <>
      <a href="/">
        <img src="images/logo.svg" alt="PlayerTube" className="logo" />
      </a>
      <form className="search-bar">
        <input type="search" className="search-input" placeholder="Search" />
        <button className="search-btn">
          <i className="fas fa-search"></i>
        </button>
      </form>
      <div className="menu-icon">
        <button className="btn-video" >
          <i className="fas fa-video"></i>
        </button>
        {isAuth ? (
          <UserInfo />
        ) : (
          <button className="btn-singin" onClick={handleModal}>
            <i className="fas fa-user-circle"></i>
            SIGN IN
          </button>
        )}
        {isHiddenModal ? "" : <SignInSignUp handleModal={handleModal} />}
      </div>
    </>
  );
}

export default Navigation;
