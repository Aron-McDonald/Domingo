CREATE PROCEDURE SP_GetCustomerByCustomerID
(
	@customerID INT
)
AS
BEGIN
	SELECT *
	FROM customer
	WHERE @customerID = customerID
END