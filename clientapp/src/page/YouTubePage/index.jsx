import React from "react";
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import HomePage from "../HomePage";
import ErrorPage from "./../ErrorPage";


function YouTubePage(){
    return (
      <BrowserRouter>
        <Switch>
          <Route path="/" component={HomePage} />
        </Switch>
      </BrowserRouter>
    );
}

export default YouTubePage;