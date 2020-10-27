CREATE OR ALTER PROCEDURE Insert_NewComment 
	@Content nvarchar(max), @UserId int, @VideoId int
AS
	Insert into tblComment(Content, UserId, VideoId) 
	Values (@Content,@UserId, @VideoId)
	SELECT SCOPE_IDENTITY()
GO
