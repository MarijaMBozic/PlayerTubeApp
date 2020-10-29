CREATE OR ALTER PROCEDURE Get_AllCommentsBySongId
	@VideoId int

AS
	SELECT tblComment.Id, Content, CreateDate, Username, ParentComment from tblComment 
	full join tblUser on tblComment.UserId=tblUser.Id
	where VideoId=@VideoId and tblComment.IsDeleted=0
	order by CreateDate

GO

