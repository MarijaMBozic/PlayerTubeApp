CREATE OR ALTER PROCEDURE Delete_Comment
	@Id int
AS
	update tblComment set  
	IsDeleted='true'
	where Id=@Id
GO