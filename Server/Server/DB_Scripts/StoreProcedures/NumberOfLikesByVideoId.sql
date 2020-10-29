CREATE OR ALTER PROCEDURE NumberOfLikesByVideoId
	@VideoId int
AS

SELECT COUNT(CASE WHEN IsLiked = 1 THEN 1 END) NumberOfLikes,
       COUNT(CASE WHEN IsLiked = 0 THEN 1 END) NumberOfUnliks FROM tblVideoLikes 
	   where  VideoId=@VideoId
go




