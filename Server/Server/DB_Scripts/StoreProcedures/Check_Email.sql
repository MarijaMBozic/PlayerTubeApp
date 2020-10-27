CREATE OR ALTER PROCEDURE Check_Email
	@Email nvarchar(100)

AS
	SELECT Id from tblUser 
	where Email=@Email and IsDeleted=0

GO