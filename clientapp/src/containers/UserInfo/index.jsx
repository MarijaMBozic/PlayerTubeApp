import React from "react";
import { useHistory } from "react-router-dom";
import "./index.css";

function UserInfo() {
  const history = useHistory();
  const username  =  localStorage.getItem("Username");

  console.log("UserInfo username", username);

  const handleLogout = () => {
    localStorage.removeItem("Token");
    localStorage.removeItem("Username");
    localStorage.removeItem("Id");
    history.push("/");
  };

  return (
    <div>
      <ul className="userinfo_item">
        <li>
          <i className="fas fa-user-circle fa-2x"></i>
        </li>
        <li>
          <label>{username}</label>
        </li>
        <li className="last">
          <button className="btn-logOut" type="submit" onClick={handleLogout}>
            LogOut
          </button>
        </li>
      </ul>
    </div>
  );
}

export default UserInfo;
