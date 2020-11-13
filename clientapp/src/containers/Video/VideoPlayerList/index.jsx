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

  console.log("video from dispatch", videoInfo);
  return (
    <div className="player-wrapper-list">
      {videoInfo?.map?.((video, index) => {
        const { Id, Name, Path } = video;

        return (
          <li key={`video_${index}`}>
            <NavLink
              to={{
                pathname: `/watch/${Name}`,
                aboutProps: {
                  name: Id,
                },
              }}
            >
              <ReactPlayer
                className="react-player-list"
                url={videoPath + Path}
                width="40vh"
                height="30vh"
              />
              <p>{Name}</p>
            </NavLink>
          </li>
        );
      })}
    </div>
  );
}

export default VideoPlayerList;
