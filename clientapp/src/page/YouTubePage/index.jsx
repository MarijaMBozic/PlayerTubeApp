import React from "react";
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import HomePage from "../HomePage";
import UserPage from "../UserPage";
import VideoPage from "./../VideoPage";

function YouTubePage(){
    return (
      <BrowserRouter>
        <Switch>     
          <Route  path="/" component={HomePage} />
        </Switch>
      </BrowserRouter>
    );
}

export default YouTubePage;