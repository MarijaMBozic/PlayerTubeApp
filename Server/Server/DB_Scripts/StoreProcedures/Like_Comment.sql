CREATE OR ALTER PROCEDURE Like_Comment
	@UserId int, @CommentId int, @IsLiked bit
AS
BEGIN
    IF EXISTS (SELECT * FROM tblCommentLikes
        WHERE UserId=@UserId
               and CommentId=@CommentId and IsDeleted='false')
    begin
		update tblCommentLikes set
		       IsLiked=@IsLiked
		where UserId=@UserId and CommentId=@CommentId and IsDeleted='false'
    end
   else
	begin 
		insert into tblCommentLikes(UserId, CommentId, IsLiked)
		values(@UserId, @CommentId, @IsLiked)
	end
end
