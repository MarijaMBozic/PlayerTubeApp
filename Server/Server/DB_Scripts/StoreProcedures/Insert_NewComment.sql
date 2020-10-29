CREATE OR ALTER PROCEDURE Insert_NewComment 
	@Content nvarchar(max), @UserId int, @VideoId int, @ParentComment int = 0
AS
	Insert into tblComment(Content, UserId, VideoId, ParentComment) 
	Values (@Content,@UserId, @VideoId, @ParentComment)
	SELECT SCOPE_IDENTITY()
GO
