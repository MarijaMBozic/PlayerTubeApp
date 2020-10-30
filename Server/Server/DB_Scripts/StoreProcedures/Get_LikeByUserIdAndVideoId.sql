CREATE OR ALTER PROCEDURE Get_LikeByUserIdAndVideoId
	@UserId int, @VideoId int
AS
	select IsLiked from tblVideoLikes   
	where IsDeleted='false' and UserId=@UserId and VideoId=@VideoId
Go