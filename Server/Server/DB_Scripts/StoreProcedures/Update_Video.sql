CREATE OR ALTER PROCEDURE Update_Video
	@Id int, @Name nvarchar(100), @Description nvarchar(max)
AS
	update tblVideo set  
	VideoName=@Name,
	Description=@Description
	where Id=@Id
Go