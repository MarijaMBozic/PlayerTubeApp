CREATE OR ALTER PROCEDURE Update_VideoViews
	@Id int, @Views int
AS
	update tblVideo set  
	VideoViews=@Views
	where Id=@Id
Go