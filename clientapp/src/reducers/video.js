import {
  FETCH_ALLVIDEOS_SUCCESS,
  FETCH_VIDEOBYID_SUCCESS,
} from "./../actions/video";

const initialState = {
  videoList: [],
  videoInfo: {},
};

export default function videoReducer(state = initialState, action) {
  switch (action.type) {
    case FETCH_ALLVIDEOS_SUCCESS: {
      return {
        ...state,
        videoList: action.payload,
      };
    }
    case FETCH_VIDEOBYID_SUCCESS: {
      return {
        ...state,
        videoInfo: action.payload,
      };
    }
    default:
      return state;
  }
}

export const allVideoSelector = (state) => state?.video?.videoList;
export const videoSelector = (state) => state?.video?.videoInfo;
