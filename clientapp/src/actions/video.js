import { API_CALL } from "./../middlewares/apiMiddleware";
import { videoURL, videoByIdURL } from "./endPoints.js";

export const FETCH_ALLVIDEOS = "FETCH_ALLVIDEOS";
export const FETCH_ALLVIDEOS_START = "FETCH_ALLVIDEOS_START";
export const FETCH_ALLVIDEOS_SUCCESS = "FETCH_ALLVIDEOS_SUCCESS";
export const FETCH_ALLVIDEOS_FAILURE = "FETCH_ALLVIDEOS_FAILURE";

export const FETCH_VIDEOBYID = "FETCH_VIDEOBYID";
export const FETCH_VIDEOBYID_START = "FETCH_VIDEOBYID_START";
export const FETCH_VIDEOBYID_SUCCESS = "FETCH_VIDEOBYID_SUCCESS";
export const FETCH_VIDEOBYID_FAILURE = "FETCH_VIDEOBYID_FAILURE";

export function getAllVideos() {
  return {
    [API_CALL]: true,
    type: FETCH_ALLVIDEOS,
    apiData: {
      url: videoURL,
      config: {
        method: "GET",
        headers: {
          "Content-type": "application/json",
        },
      },
    },
  };
}

export function getVideoById(videoId) {
  return {
    [API_CALL]: true,
    type: FETCH_VIDEOBYID,
    apiData: {
      url: videoByIdURL + videoId,
      config: {
        method: "GET",
        headers: {
          "Content-type": "application/json",
        },
      },
    },
  };
}
