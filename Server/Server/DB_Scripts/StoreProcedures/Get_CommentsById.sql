CREATE OR ALTER PROCEDURE Get_CommentsById
	@Id int
AS
	SELECT tblComment.Id, Content, CreateDate, Username, UserId, ParentComment from tblComment 
	full join tblUser on tblComment.UserId=tblUser.Id
	where tblComment.Id=@Id and tblComment.IsDeleted=0
	order by CreateDate
GO
