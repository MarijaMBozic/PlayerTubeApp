CREATE OR ALTER PROCEDURE Delete_Comment
	@Id int
AS
	begin
		select Id from tblComment   
		where IsDeleted='false' and ParentComment=@Id
	end
   begin
		update tblComment set  
		IsDeleted='true'
		where Id=@Id
	end

	begin
		update tblComment set  
		IsDeleted='true'
		where ParentComment=@Id
	end
GO