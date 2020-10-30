import axios from "axios";
import { authHeader } from "./../../helpers/authHeader";
const baseUrl = `${process.env.REACT_APP_API}/api/Video?path=`;

function GetVideo({ Path }) {
  console.log(Path);
  return axios
    .get(baseUrl + Path, { headers: authHeader() })
    .then((res) => res)
    .catch((error) => {
      console.log(error);
    });
}

export default GetVideo;
