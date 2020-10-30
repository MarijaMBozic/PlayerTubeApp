CREATE OR ALTER PROCEDURE Get_AllCommentsByParentId
	@Id int
AS
	select Id from tblComment   
	where IsDeleted='false' and ParentComment=@Id
Go
