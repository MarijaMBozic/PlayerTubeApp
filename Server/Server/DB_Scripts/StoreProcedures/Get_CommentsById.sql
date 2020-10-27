CREATE OR ALTER PROCEDURE Get_CommentsById
	@Id int
AS
	SELECT tblComment.Id, Content, CreateDate, CommentLike, Unlike, Username from tblComment 
	full join tblUser on tblComment.UserId=tblUser.Id
	where tblComment.Id=@Id and tblComment.IsDeleted=0
	order by CreateDate
GO