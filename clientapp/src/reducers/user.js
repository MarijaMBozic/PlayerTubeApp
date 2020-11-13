import { LOGIN_USER_SUCCESS } from "./../actions/user";

const initialState = {
  userInfo: {},
};

export default function userReducer(state = initialState, action) {
  switch (action.type) {
    case LOGIN_USER_SUCCESS: {
      return {
        ...state,
        userInfo: action.payload,
      };
    }
    default:
      return state;
  }
}

export const userSelector = (state) => state?.user?.userInfo.Username;
