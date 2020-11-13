import React from "react";
import { useHistory } from "react-router-dom";
import { useSelector } from "react-redux";
import { userSelector } from "../../reducers/user";
import "./index.css";

function UserInfo() {
  const history = useHistory();
  const userInfo = useSelector(userSelector);
  
  const handleLogout = () => {
    localStorage.removeItem("Token");
    history.push("/");
  };

  console.log("UserInfo username", userInfo)
  return (
    <div>
        <ul className="userinfo_item">
          <li>
            <label>{userInfo}</label>
          </li>
          <li className="last">
            <button className="btn orange" type="submit" onClick={handleLogout}>
              LogOut
            </button>
          </li>
        </ul>
    </div>
  );
}

export default UserInfo;
