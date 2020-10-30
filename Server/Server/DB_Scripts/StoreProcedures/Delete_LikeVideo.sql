CREATE OR ALTER PROCEDURE Delete_LikeVideo
	@UserId int, @VideoId int
AS
	update tblVideoLikes set  
	IsDeleted='true' 
	where UserId=@UserId and VideoId=@VideoId
Go