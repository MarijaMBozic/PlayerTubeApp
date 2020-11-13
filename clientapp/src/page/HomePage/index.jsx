import React from "react";
import { Route } from "react-router-dom";
import Login from "./../../containers/Login/Login";
import VideoPlayerList from "./../../containers/Video/VideoPlayerList";
import VideoPage from "./../VideoPage";

function HomePage() {
  return (
    <>
      <div>
        <Login />
      </div>
      <div>
        <Route exact path="/" component={VideoPlayerList} />
        <Route path="/watch/:video" component={VideoPage} />
      </div>
    </>
  );
}

export default HomePage;
