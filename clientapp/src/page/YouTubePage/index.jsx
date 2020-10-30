import React from 'react';
import FirstPage from './../../components/FirstPage';
import UserPage from './../../components/UserPage';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

function Homepage(){
    return(
        <BrowserRouter>
            <Switch>    
                <Route exact path="/" component={FirstPage}/>
                <Route  path="/user" component={UserPage}/>
            </Switch>  
        </BrowserRouter>
    )
}

export default Homepage;