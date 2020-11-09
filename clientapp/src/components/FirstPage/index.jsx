import React from 'react';
import Login from './../Login/index';
import PlayerVIdeo from './../PlayerVIdeo/index';
import VideoPlayerList from './../VideoPlayerList';

function FirstPage(){
    return(
        <>
            <div>
                <Login/>
            </div>
            <div>
                <PlayerVIdeo/>
            </div>
            <div>
                <VideoPlayerList/>   
    	    </div>
            <div>
                listOfComments
            </div>
        </>
    )
}

export default FirstPage;