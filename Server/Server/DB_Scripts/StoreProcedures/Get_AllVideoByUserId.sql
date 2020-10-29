CREATE OR ALTER PROCEDURE Get_AllVideoByUserId
	@UserId int

AS
	SELECT tblVideo.Id, VideoName, VideoViews, VideoPath, Description, Username, tblUser.Id from tblVideo 
	right join tblUser on tblVideo.UserId=tblUser.Id
	where tblVideo.UserId=@UserId and tblVideo.IsDeleted=0
GO