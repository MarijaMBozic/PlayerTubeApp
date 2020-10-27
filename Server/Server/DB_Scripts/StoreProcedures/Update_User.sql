CREATE OR ALTER PROCEDURE Update_User
	@Id int, @Password nvarchar(max)
AS
	update tblUser set  
	Password=@Password
	where Id=@Id
GO