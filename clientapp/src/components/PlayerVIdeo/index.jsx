import React, { useState, useEffect } from "react";
import ReactPlayer from "react-player";
import GetVideoById from "./../../service/ApiCall/getVideoById";
import GetVideo from "./../../service/ApiCall/getVideo";
import "./index.scss";

function PlayerVideo() {
  const [videoInfo, setVideoInfo] = useState([]);
  const [video, setVideo] = useState();
  //const [videoFilePath, setVideoFileURL] = useState(null);
  const { Path } = videoInfo;

  useEffect(() => {
    GetVideoById(5).then((response) => {
      setVideoInfo(response?.data);
    });
  }, []);

  useEffect(() => {
    GetVideo(Path).then((response) => {
      setVideo(response);
    });
  }, []);

  console.log(video);
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
