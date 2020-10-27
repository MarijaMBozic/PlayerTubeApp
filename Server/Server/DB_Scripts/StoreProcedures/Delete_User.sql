CREATE OR ALTER PROCEDURE Delete_User
	@Id int
AS
	update tblUser set  
	IsDeleted='true'
	where Id=@Id
GO