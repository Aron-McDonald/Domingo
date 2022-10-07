CREATE PROCEDURE SP_DeleteCustomer
(
	@customerID INT
)
AS
BEGIN
	DELETE FROM customer
	WHERE @customerID = customerID
END