import { API_CALL } from "./../middlewares/apiMiddleware";
import { loginUrl, registrationUrl } from "./endPoints.js";

export const LOGIN_USER = "LOGIN_USER";
export const LOGIN_USER_START = "LOGIN_USER_START";
export const LOGIN_USER_SUCCESS = "LOGIN_USER_SUCCESS";
export const LOGIN_USER_FAILURE = "LOGIN_USER_FAILURE";

export const REGISTRATION_USER = "REGISTRATION_USER";
export const REGISTRATION_USER_START = "REGISTRATION_USER_START";
export const REGISTRATION_USER_SUCCESS = "REGISTRATION_USER_SUCCESS";
export const REGISTRATION_USER_FAILURE = "REGISTRATION_USER_FAILURE";

export function loginUser(userInfo) {
  return {
    [API_CALL]: true,
    type: LOGIN_USER,
    apiData: {
      url: loginUrl,
      config: {
        method: "POST",
        body: userInfo,
        headers: {
          "Content-type": "application/json",
        },
      },
    },
  };
}

export function registrationUser(userInfo) {
  return {
    [API_CALL]: true,
    type: REGISTRATION_USER,
    apiData: {
      url: registrationUrl,
      config: {
        method: "POST",
        body: userInfo,
        headers: {
          "Content-type": "application/json",
        },
      },
    },
  };
}
