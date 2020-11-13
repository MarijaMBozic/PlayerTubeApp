import React from "react";
import PlayerVideo from "../../containers/Video/PlayerVIdeo";
import VideoPlayerList from "./../../containers/Video/VideoPlayerList";
import "./index.css";

function VideoPage(props) {
  const videoId = props.location.aboutProps.name;

  return (
    <div className="wraped-container">
      <header className="container-header">
        <PlayerVideo videoId={videoId} />
      </header>
      <div className="container-videoList">
        <VideoPlayerList />
      </div>
      <div className="container-comments">Comments</div>

      <div>listOfComments</div>
    </div>
  );
}

export default VideoPage;
