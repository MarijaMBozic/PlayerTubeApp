CREATE OR ALTER PROCEDURE Get_LoginData
	@Email nvarchar(100), @Password nvarchar(max) 
AS
	select Id, Username from tblUser 
	where Email=@Email and Password=@Password and IsDeleted=0

GO