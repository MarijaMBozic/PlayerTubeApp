CREATE OR ALTER PROCEDURE Delete_User
	@Id int
AS
begin
	update tblUser set  
	IsDeleted='true'
	where Id=@Id
end
begin
	update tblComment set  
	IsDeleted='true'
	where UserId=@Id
end
begin
	update tblVideo set  
	IsDeleted='true'
	where UserId=@Id
end
GO