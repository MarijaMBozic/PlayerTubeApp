import React, { useEffect } from "react";
import ReactPlayer from "react-player";
import { useDispatch, useSelector } from "react-redux";
import { getVideoById } from "./../../../actions/video";
import { videoPath } from "../../../actions/endPoints";
import { videoSelector } from "./../../../reducers/video";
import "./index.css";
import { NavLink } from "react-router-dom";

function PlayerVideo(props) {
  const dispatch = useDispatch();
  const { videoId } = props;
  const videoInfo = useSelector(videoSelector);
  const { Path, Name, Views, Username, VideoLikes, Unlikes, UserId, Description } = videoInfo;

  console.log("Video selektor", videoInfo)

  useEffect(() => {
    dispatch(getVideoById(videoId));
  }, [dispatch, videoId]);

  const video = videoPath + Path;

  return (
    <>
      <div className="main__video-container">
      <ReactPlayer
        url={video}
        controls={true}
      />
      </div>
      <div className="main__description">
  <p>{Name}</p>
        <div className="main__description_metadata">
  <p>{Views} views</p>
          <div>
          <button className="btn-like">       
  <i className="fas fa-thumbs-up"></i>  {VideoLikes}
          </button>
          <button className="btn-like">
  <i className="fas fa-thumbs-down "></i> {Unlikes}
          </button>
          </div>
        </div>
      </div>
      <div className="main__sub-description">
        <NavLink to={{
              pathname: `/channel/$`,
              aboutProps: {
               Name:UserId
              },
            }}>
          <i className="fas fa-user-circle fa-2x"></i>
          <div className="metadate">
          <h3>{Username}</h3>
            <p> date</p>
          </div>  
        </NavLink>
          <p>{Description}</p>
      </div>
    </>
  );
}

export default PlayerVideo;
