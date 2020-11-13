const isAuthenticated = () => {
    const token = localStorage.getItem("Token");
    
    if (token) {
        return true;
    } else {
        return false;
    }
}

export default isAuthenticated;