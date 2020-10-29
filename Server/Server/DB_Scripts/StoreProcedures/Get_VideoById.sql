CREATE OR ALTER PROCEDURE Get_VideoById
	@Id int
AS
	SELECT tblVideo.Id, VideoName, VideoViews, VideoPath, Description, Username, tblUser.Id from tblVideo 
	right join tblUser on tblVideo.UserId=tblUser.Id
	where tblVideo.Id=@Id and tblVideo.IsDeleted=0
GO