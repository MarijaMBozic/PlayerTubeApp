CREATE OR ALTER PROCEDURE Delete_Video
	@Id int
AS
begin
	update tblVideo set  
	IsDeleted='true'
	where Id=@Id
end

begin
	update tblComment set  
	IsDeleted='true'
	where VideoId=@Id
end
GO

