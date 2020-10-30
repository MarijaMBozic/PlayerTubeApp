import axios from 'axios';
import qs from 'qs';


const baseUrl = `${process.env.REACT_APP_API}/api/Token/`;

const config = {
    headers: {
        "Content-Type": "application/x-www-form-urlencoded"
    }
};

function Login(props) {
    console.log(props)
    const reqData = qs.stringify(props);

    return (
        axios.post(baseUrl, reqData, config)
            .then(response => {
                localStorage.setItem("token", response.data.Token );
                localStorage.setItem("Username", response.data.Username );
                localStorage.setItem("Id", response.data.Id );
                window.location.reload();
                alert("Successful login")
            })
            .catch(error => {
                console.log(error);
            })
    )
}
export default Login;