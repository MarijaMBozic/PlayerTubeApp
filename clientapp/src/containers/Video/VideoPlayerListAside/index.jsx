import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import ReactPlayer from "react-player";
import { NavLink } from "react-router-dom";
import { getAllVideos } from "../../../actions/video";
import { videoPath } from "../../../service/ApiCall/getVideo";
import { allVideoSelector } from "../../../reducers/video";
import "./index.css";

function VideoPlayerListAside() {
  const dispatch = useDispatch();
  const videoInfo = useSelector(allVideoSelector);

  useEffect(() => {
    dispatch(getAllVideos());
  }, [dispatch]);
  console.log(videoInfo);

  return (
    <>
      {videoInfo?.map?.((video, index) => {
        const { Id, Name, Path, Username, Views } = video;
        return (
          <NavLink
            className="aside_video-container"
            key={`video_${index}`}
            to={{
              pathname: `watch/${Name}`,
              aboutProps: {
                name: Id,
              },
            }}
          >
            <div className="aside-video-image">
              <ReactPlayer
                url={videoPath + Path}
                width="200px"
                height="150px"
              />
            </div>
            <div className="video-aside-section">
              <div className="video-aside-details">
                <h3>{Name}</h3>
                <p>{Username}</p>
                <p>{Views} views</p>
              </div>
            </div>
          </NavLink>
        );
      })}
    </>
  );
}

export default VideoPlayerListAside;
