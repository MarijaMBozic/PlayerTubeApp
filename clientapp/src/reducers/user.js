import { LOGIN_USER_SUCCESS } from "./../actions/user";

const initialState = {
  userInformation: {},
};

export default function userReducer(state = initialState, action) {
  switch (action.type) {
    case LOGIN_USER_SUCCESS: {
      return {
        ...state,
        userInformation: action.payload,
      };
    }
    default:
      return state;
  }
}



