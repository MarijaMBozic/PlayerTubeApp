CREATE OR ALTER PROCEDURE Get_AllVideosBySearch
 @InputName nvarchar(100)=null
AS
select   tblVideo.Id, VideoName, VideoViews, VideoPath, Description, Username, tblUser.Id, NumberOfLikes, NumberOfUnlikes  from tblVideo 
right join tblUser on tblVideo.UserId=tblUser.Id
left join (SELECT COUNT(CASE WHEN IsLiked = 1 THEN 1 END) NumberOfLikes,
                  COUNT(CASE WHEN IsLiked = 0 THEN 1 END) NumberOfUnlikes, VideoId FROM tblVideoLikes 
				  where IsDeleted=0
	              group by VideoId) as LikesCount
on tblVideo.Id=LikesCount.VideoId
where VideoName LIKE '%'+@InputName+'%' and tblVideo.IsDeleted=0
GO