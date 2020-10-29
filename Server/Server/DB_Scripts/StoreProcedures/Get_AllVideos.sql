CREATE OR ALTER PROCEDURE Get_AllVideos

AS
	SELECT tblVideo.Id, VideoName, VideoViews, VideoPath, Description, Username, tblUser.Id from tblVideo 
	right join tblUser on tblVideo.UserId=tblUser.Id
	where tblVideo.IsDeleted=0
GO