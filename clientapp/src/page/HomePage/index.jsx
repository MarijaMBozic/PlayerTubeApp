import React from "react";
import { Route } from "react-router-dom";
import ErrorPage from "../ErrorPage";
import Login from "./../../containers/Login/Login";
import VideoPlayerList from "./../../containers/Video/VideoPlayerList";
import VideoPage from "./../VideoPage";
import "./index.css";

function HomePage() {
  return (
    <>
      <header className="main-nav">
        <Login />
      </header>

          <Route exact path="/" component={VideoPlayerList} />
          <Route exact path="/watch/:video" component={VideoPage} />

    </>
  );
}

export default HomePage;
