import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import ReactPlayer from "react-player";
import { NavLink } from "react-router-dom";
import { getAllVideos } from "./../../../actions/video";
import { videoPath } from "../../../service/ApiCall/getVideo";
import { allVideoSelector } from "./../../../reducers/video";
import "./index.css";

function VideoPlayerList() {
  const dispatch = useDispatch();
  const videoInfo = useSelector(allVideoSelector);

  useEffect(() => {
    dispatch(getAllVideos());
  }, [dispatch]);
 console.log(videoInfo);
  return (
    <div className="video-cards">
      {videoInfo?.map?.((video, index) => {
        const { Id, Name, Path, Username, Views } = video;
        return (
          <NavLink
            className="video-container"
            key={`video_${index}`}
            to={{
              pathname: `Home/watch/${Name}`,
              aboutProps: {
                name: Id,
              },
            }}
          >
            <div className="video-image">
              <ReactPlayer
                url={videoPath + Path}
                width="200px"
                height="150px"
              />
            </div>
            <div className="video-bottom-section">
              <div className="channel-icon">
                <i className="fas fa-user-circle"></i>
              </div>
              <div className="video-details">
                <h3>{Name}</h3>
                <p>{Username}</p>
                <div className="video-info">
                  <span> {Views} views</span>
                </div>
              </div>
            </div>
          </NavLink>
        );
      })}
    </div>
  );
}

export default VideoPlayerList;
