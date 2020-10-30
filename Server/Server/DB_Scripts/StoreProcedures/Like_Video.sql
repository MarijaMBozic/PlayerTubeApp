CREATE OR ALTER PROCEDURE Like_Video
	@UserId int, @VideoId int, @IsLiked bit
AS
BEGIN
    IF EXISTS (SELECT * FROM tblVideoLikes
        WHERE UserId=@UserId
               and VideoId=@VideoId and IsDeleted='false')
    begin
		update tblVideoLikes set
		       IsLiked=@IsLiked
		where UserId=@UserId and VideoId=@VideoId and IsDeleted='false'
    end
   else
	begin 
		insert into tblVideoLikes(UserId, VideoId, IsLiked)
		values(@UserId, @VideoId, @IsLiked)
	end
end