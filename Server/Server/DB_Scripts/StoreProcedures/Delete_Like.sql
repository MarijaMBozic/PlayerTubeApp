CREATE OR ALTER PROCEDURE Delete_Like
	@UserId int, @CommentId int
AS
	update tblCommentLikes set  
	IsDeleted='true' 
	where UserId=@UserId and CommentId=@CommentId
Go
