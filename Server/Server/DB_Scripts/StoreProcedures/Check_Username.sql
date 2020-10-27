CREATE OR ALTER PROCEDURE Check_Username
	@Username nvarchar(100)
AS
	SELECT Id from tblUser 
	where Username=@Username and IsDeleted=0
GO