CREATE OR ALTER PROCEDURE NumberOfLikesByCommentId
	@CommentId int
AS

SELECT COUNT(CASE WHEN IsLiked = 1 THEN 1 END) NumberOfLikes,
       COUNT(CASE WHEN IsLiked = 0 THEN 1 END) NumberOfUnlikes FROM tblCommentLikes 
	   where  CommentId=@CommentId
go