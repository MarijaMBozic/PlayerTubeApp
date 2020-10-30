
import axios from 'axios';

const baseUrl = `${process.env.REACT_APP_API}/api/User/`;

function Registration(props) {

    return (
        axios.post(baseUrl, props).then(response => {
            window.location.reload();
            alert("Successful registration")
        }).catch(error => {
            console.log(error);
        })
    )
}

export default Registration