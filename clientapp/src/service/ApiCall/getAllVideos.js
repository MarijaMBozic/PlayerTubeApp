import axios from "axios";
const baseUrl = `${process.env.REACT_APP_API}/api/Video/`;

function getAllVideos() {
    return (
        axios.get(baseUrl).then(res =>        
            res
        ).catch(error => {
            console.log(error);
        })
    )
}

export default getAllVideos;