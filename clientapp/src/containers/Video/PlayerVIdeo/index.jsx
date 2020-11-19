import React, { useEffect } from "react";
import ReactPlayer from "react-player";
import { useDispatch, useSelector } from "react-redux";
import { getVideoById } from "./../../../actions/video";
import { videoPath } from "../../../actions/endPoints";
import { videoSelector } from "./../../../reducers/video";
import "./index.css";

function PlayerVideo(props) {
  const dispatch = useDispatch();
  const { videoId } = props;
  const videoInfo = useSelector(videoSelector);
  const { Path } = videoInfo;

  useEffect(() => {
    dispatch(getVideoById(videoId));
  }, [dispatch]);

  const video = videoPath + Path;

  return (
    <>
      <div className="main__video-container">
      <ReactPlayer
        url={video}
        controls={true}
      />
      </div>
      <div class="main__description">
        <p>Steph Curry & DeMarcus Postgame Interview - Game 2 | Warriors vs Raptos | 2019 NBA Finals</p>
        <div class="main__description_metadata">
          <p>290,399 views</p>
          <a href="#">       
            <i class="fas fa-thumbs-up"></i>  like
            <i class="fas fa-thumbs-down "></i> unlike
          </a>
        </div>
      </div>
      <div class="main__sub-description">
        <a href="#">
          <i class="fas fa-user-circle fa-2x"></i>
          <div class="metadate">
            <h3>UserName</h3>
            <p> date</p>
          </div>  
        </a>
        <p>Stephen A. Smith gives his best sales pitch for Kevin Durant to sign with the New York Knicks ahead of 2019 NBA free agency, saying KD would get whatever he desired courtesy of James Dolan..</p>
      </div>
    </>
  );
}

export default PlayerVideo;
