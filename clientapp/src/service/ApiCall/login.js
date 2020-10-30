import axios from "axios";
import qs from "qs";

const baseUrl = `${process.env.REACT_APP_API}/api/Token/`;

const config = {
  headers: {
    "Content-Type": "application/x-www-form-urlencoded",
  },
};

function Login(props) {
  console.log(props);
  const reqData = qs.stringify(props);

  return axios
    .post(baseUrl, reqData, config)
    .then((response) => {
      const { Token, Username, Id } = response.data;
      localStorage.setItem("token", Token);
      localStorage.setItem("Username", Username);
      localStorage.setItem("Id", Id);
      window.location.reload();
      alert("Successful login");
    })
    .catch((error) => {
      console.log(error);
    });
}
export default Login;
