CREATE OR ALTER PROCEDURE Update_CommentParentInfo
	@Id int, @ParentComment int
AS
	update tblComment set  
	ParentComment=@ParentComment
	where Id=@Id
GO