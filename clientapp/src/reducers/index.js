import { combineReducers } from "redux";
import userReducer from "./user";
import videoReducer from "./video";

export default combineReducers({
  user: userReducer,
  video: videoReducer,
});
