import React, { useState, useEffect } from "react";
import ReactPlayer from "react-player";
import GetVideoById from "../../../service/ApiCall/getVideoById";
import { videoPath } from "../../../actions/endPoints";
import "./index.css";

function PlayerVideo(props) {
  const { videoId } = props;
  const [videoInfo, setVideoInfo] = useState([]);
  const { Path } = videoInfo;

  useEffect(() => {
    GetVideoById(videoId).then((response) => {
      setVideoInfo(response?.data);
    });
  }, []);

  const video = videoPath + Path;

  return (
    <div className="player-wrapper">
      <ReactPlayer
        className="react-player"
        url={video}
        width="60vh"
        height="50vh"
        controls={true}
      />
    </div>
  );
}

export default PlayerVideo;
