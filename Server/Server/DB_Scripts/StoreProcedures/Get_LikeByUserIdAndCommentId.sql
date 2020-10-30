CREATE OR ALTER PROCEDURE Get_LikeByUserIdAndCommentId
	@UserId int, @CommentId int
AS
	select IsLiked from tblCommentLikes   
	where IsDeleted='false' and UserId=@UserId and CommentId=@CommentId
Go
