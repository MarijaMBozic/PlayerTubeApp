CREATE OR ALTER PROCEDURE Get_AllSubscriberByUser
	@UserId int
AS
	select tblUser.Email  from tblSubscribers  
	inner join tblUser on tblUser.Id=tblSubscribers.SubscriberId 
	where tblSubscribers.IsDeleted='false' and tblSubscribers.UserId=@UserId
Go