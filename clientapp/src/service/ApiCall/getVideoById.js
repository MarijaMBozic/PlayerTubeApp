import axios from "axios";
import { authHeader } from "./../../helpers/authHeader";
const baseUrl = `${process.env.REACT_APP_API}/api/GetVideo?videoId=`;

function GetVideoById(Id) {
  return axios
    .get(baseUrl + Id, { headers: authHeader() })
    .then((res) => res)
    .catch((error) => {
      console.log(error);
    });
}

export default GetVideoById;
