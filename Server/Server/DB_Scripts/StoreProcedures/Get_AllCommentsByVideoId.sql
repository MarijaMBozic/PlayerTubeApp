CREATE OR ALTER PROCEDURE Get_AllCommentsByVideoId
	@VideoId int
as
select  tblComment.Id, Content, CreateDate, Username, ParentComment, NumberOfLikes, NumberOfUnlikes  from tblComment 
right join tblUser on tblComment.UserId=tblUser.Id
left join (SELECT COUNT(CASE WHEN IsLiked = 1 THEN 1 END) NumberOfLikes,
                  COUNT(CASE WHEN IsLiked = 0 THEN 1 END) NumberOfUnlikes, CommentId FROM tblCommentLikes 
	              group by CommentId) as LikesCount
on tblComment.Id=LikesCount.CommentId
where VideoId=@VideoId and tblComment.IsDeleted=0
order by CreateDate
go

