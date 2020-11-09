import React, { useState, useEffect } from "react";
import ReactPlayer from "react-player";
import getAllVideos from "./../../service/ApiCall/getAllVideos";
import {videoPath} from "./../../service/ApiCall/getVideo";
//import "./index.scss";

function VideoPlayerList() {
  const [videoInfo, setVideoInfo] = useState({});

  useEffect(() => {
    getAllVideos().then((response) => {
        setVideoInfo(response.data)
    });
  }, []);

  console.log(videoPath)
  return (
      <div className="player-wrapper-list">
      {
         videoInfo?.map?.((video, index)=>{
          const {Name, Views, Path, Description, VideoLikes, Unlikes, Username}=video;
                  
          return(
            <div className="player-wrapper-list">
            <ReactPlayer
              className="react-player-list"
              url={videoPath+Path}
              width="30%"
              height="30%"              
            />
            <header>{Name}</header>
          </div>
          )
      })   
      }
      </div>
  );
}

export default VideoPlayerList;
