CREATE OR ALTER PROCEDURE Insert_NewSubscriber
	@UserId int, @SubscriberId int
as
	Insert into tblSubscribers(UserId, SubscriberId) 
	Values (@UserId, @SubscriberId)
	SELECT SCOPE_IDENTITY()
GO