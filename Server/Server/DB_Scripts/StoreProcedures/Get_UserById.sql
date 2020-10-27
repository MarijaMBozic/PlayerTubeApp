CREATE OR ALTER PROCEDURE Get_UserById
	@Id int
AS
	SELECT Id, Username, Email, Password from tblUser 
	where Id=@Id and IsDeleted=0
GO