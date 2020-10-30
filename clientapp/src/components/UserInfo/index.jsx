import React, { useMemo } from "react";
import { UserContext } from "./../../useContext/useContext.js";
import "./index.css";

function UserInfo() {
  const userInfo = localStorage.getItem("Username");
  const userId = localStorage.getItem("Id");
  const providerValue = useMemo(() => userId, [userId]);

  const handleLogout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("Username");
    localStorage.removeItem("Id");
    window.location.reload();
  };

  return (
    <div>
      <UserContext.Provider value={providerValue}>
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
      </UserContext.Provider>
    </div>
  );
}

export default UserInfo;
