import { createStore, applyMiddleware } from "redux";
import { composeWithDevTools } from "redux-devtools-extension";
import rootReducer from "./reducers";
import apiMiddleware from "./middlewares/apiMiddleware";

const middlewares = [apiMiddleware];

export default createStore(
  rootReducer,
  composeWithDevTools(applyMiddleware(...middlewares))
);
