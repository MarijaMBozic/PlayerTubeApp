export function authHeader(){
    let token=sessionStorage.getItem("token")

    if(token){
        return{
            "Authorization":`Bearer ${token}`
        }
    }else{
        return{};
    }
}