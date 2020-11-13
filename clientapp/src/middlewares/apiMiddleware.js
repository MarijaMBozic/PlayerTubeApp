import { callApi } from "./../actions/callApi";
export const API_CALL = "API_CALL";

const apiMiddleware = (store) => (next) => (action) => {
  if (action[API_CALL]) {
    handleApiCall(next, action);
  } else {
    next(action);
  }
};

function handleApiCall(next, action) {
  next({
    type: `${action.type}_START`,
  });

  callApi(action.apiData).then((response) => {
    if (response.error && response.apiError) {
      next({
        type: `${action.type}_ERROR`,
      });
    } else if (response.error && !response.apiError) {
      next({
        type: `${action.type}_FAILURE`,
      });
    } else if (!response.error) {
      next({
        type: `${action.type}_SUCCESS`,
        payload: response,
      });
      if (action.type === "LOGIN_USER") {
        const { Token } = response;
        localStorage.setItem("Token", Token);
      }
    }
  });
}

export default apiMiddleware;
