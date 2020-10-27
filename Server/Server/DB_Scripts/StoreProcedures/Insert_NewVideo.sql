CREATE OR ALTER PROCEDURE Insert_NewVideo
	@VideoName nvarchar(100), @VideoPath nvarchar(100), @Description nvarchar(max), @UserId int
as
	Insert into tblVideo(VideoName, VideoPath, Description, UserId) 
	Values (@VideoName, @VideoPath, @Description, @UserId)
	SELECT SCOPE_IDENTITY()
GO