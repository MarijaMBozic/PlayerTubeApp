export function authHeader(){
    let token = localStorage.getItem("Token");

    if(token){
        return{
            "Authorization":`Bearer ${token}`
        }
    }else{
        return{};
    }
}