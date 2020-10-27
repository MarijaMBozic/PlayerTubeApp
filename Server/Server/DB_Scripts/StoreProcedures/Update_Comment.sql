CREATE OR ALTER PROCEDURE Update_Comment
	@Id int, @Content nvarchar(max)
AS
	update tblComment set  
	Content=@Content
	where Id=@Id
GO