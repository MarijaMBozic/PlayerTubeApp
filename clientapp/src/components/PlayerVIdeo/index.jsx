import React, { useState, useEffect } from "react";
import ReactPlayer from "react-player";
import GetVideoById from "./../../service/ApiCall/getVideoById";
import {videoPath} from "./../../service/ApiCall/getVideo";
import "./index.scss";

function PlayerVideo() {
  const [videoInfo, setVideoInfo] = useState([]);
  const { Path } = videoInfo;

  useEffect(() => {
    GetVideoById(6).then((response) => {
      setVideoInfo(response?.data);
    });
  }, []);

  const video=videoPath+Path;

  console.log(videoInfo);
  return (
    <div className="player-wrapper">
      <ReactPlayer 
        className="react-player"
        url={video}
        width="60%"
        height="60%"
        controls={true}
      />
    </div>
  );
}

export default PlayerVideo;
