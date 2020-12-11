CREATE OR ALTER PROCEDURE Delete_Subscriber
	@SubscriberId int
AS
begin
	update tblSubscribers set  
	IsDeleted='true'
	where SubscriberId=@SubscriberId
end
