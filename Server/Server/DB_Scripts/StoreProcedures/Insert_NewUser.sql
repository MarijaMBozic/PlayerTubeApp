CREATE OR ALTER PROCEDURE Insert_NewUser 
	@Username nvarchar(100), @Email nvarchar(100), @Password nvarchar(max)
as
	Insert into tblUser(Username, Email, Password) 
	Values (@Username, @Email, @Password)
	SELECT SCOPE_IDENTITY()
GO