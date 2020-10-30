import React from 'react';
import Login from './../Login/index';
import PlayerVIdeo from './../PlayerVIdeo/index';

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
                ListOfVideos
            </div>
            <div>
                listOfComments
            </div>
        </>
    )
}

export default FirstPage;