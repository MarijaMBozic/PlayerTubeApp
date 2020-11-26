import React from "react";
import PlayerVideo from "../../containers/Video/PlayerVIdeo";
import VideoPlayerListAside from "./../../containers/Video/VideoPlayerListAside";
import "./index.css";

function VideoPage(props) {
  const videoId = props?.location?.aboutProps?.name;

  return (
    <div className="main-wrapper">
      <div className="left"></div>
      <main>
        <div className="main__video">
          <PlayerVideo videoId={videoId} />
        </div>
        <aside className="aside">
          <div className="aside__top-container">
            <p>Up next</p>
            <a href="#">AUTOPLAY</a>
          </div>
          <VideoPlayerListAside />
        </aside>
        <section>
          <div>
            <div className="section__comments">
              <p>6,806 Comments</p>
            </div>
            <div className="section__sort-container">
              <a href="#">
                <i className="fas fa-sort-amount-down"></i>
                <p>SORT BY</p>
              </a>
            </div>
            <div className="section__profile">
              <i className="fas fa-user-circle fa-2x"></i>
            </div>
            <div className="input__container">
              <form>
                <input
                  type="text"
                  name="comment"
                  id="comment"
                  value="Add a public comment..."
                />
                <div className="btn-input-comment">
                  <button type="button">CANCEL</button>
                  <button type="submit">COMMENT</button>
                </div>
              </form>
            </div>
          </div>
          <div>
            <div className="comments">
              <i className="fas fa-user-circle fa-2x"></i>
              <p className="comments__name">
                John Snow <a href="#">10 months ago</a>{" "}
              </p>
              <p className="comments__comment">
                Stephen A will do anything he possibly can to get KD on the
                Knicks 😂.
              </p>
              <div className="likes">
                <a>
                  <i className="fas fa-thumbs-up"></i>
                </a>
                <p>1K</p>
                <a>
                  <i className="fas fa-thumbs-down"></i>
                </a>
                <p>10</p>
                <a>REPLY</a>
              </div>
              <a href="#" className="comments_replies">
                View all 7 replies
              </a>
            </div>
            <div className="comments">
              <i className="fas fa-user-circle fa-2x"></i>
              <p className="comments__name">
                Arya Stark <a href="#">10 months ago</a>{" "}
              </p>
              <p className="comments__comment">
                Stephen A will do anything he possibly can to get KD on the
                Knicks 😂.
              </p>
              <div className="likes">
                <a href="#">
                  <i className="fas fa-thumbs-down"></i>
                </a>
                <p className="comments__text">1K</p>
                <a href="#">
                  <i className="fas fa-thumbs-up"></i>
                </a>
                <a href="#" className="comments__text">
                  REPLY
                </a>
              </div>
              <a href="#" className="comments_replies">
                View all 7 replies
              </a>
            </div>
            <div className="comments">
              <i className="fas fa-user-circle fa-2x"></i>
              <p className="comments__name">
                Tyrion Lannister <a href="#">10 months ago</a>{" "}
              </p>
              <p className="comments__comment">
                Stephen A will do anything he possibly can to get KD on the
                Knicks 😂.
              </p>
              <div className="likes">
                <a href="#">
                  <i className="fas fa-thumbs-down"></i>
                </a>
                <p className="comments__text">1K</p>
                <a href="#">
                  <i className="fas fa-thumbs-up"></i>
                </a>
                <a href="#" className="comments__text">
                  REPLY
                </a>
              </div>
              <a href="#" className="comments_replies">
                View all 7 replies
              </a>
            </div>
            <div className="comments">
              <i className="fas fa-user-circle fa-2x"></i>
              <p className="comments__name">
                Mark Snow <a href="#">10 months ago</a>{" "}
              </p>
              <p className="comments__comment">
                Stephen A will do anything he possibly can to get KD on the
                Knicks 😂.
              </p>
              <div className="likes">
                <a href="#">
                  <i className="fas fa-thumbs-down"></i>
                </a>
                <p className="comments__text">1K</p>
                <a href="#">
                  <i className="fas fa-thumbs-up"></i>
                </a>
                <a href="#" className="comments__text">
                  REPLY
                </a>
              </div>
              <a href="#" className="comments_replies">
                View all 7 replies
              </a>
            </div>
            <div className="comments">
              <i className="fas fa-user-circle fa-2x"></i>
              <p className="comments__name">
                Lord Varys <a href="#">10 months ago</a>{" "}
              </p>
              <p className="comments__comment">
                Stephen A will do anything he possibly can to get KD on the
                Knicks 😂.
              </p>
              <div className="likes">
                <a href="#">
                  <i class="fas fa-thumbs-down"></i>
                </a>
                <p className="comments__text">1K</p>
                <a href="#">
                  <i className="fas fa-thumbs-up"></i>
                </a>
                <a href="#" className="comments__text">
                  REPLY
                </a>
              </div>
              <a href="#" className="comments_replies">
                View all 7 replies
              </a>
            </div>
          </div>
        </section>
      </main>
    </div>
  );
}

export default VideoPage;
