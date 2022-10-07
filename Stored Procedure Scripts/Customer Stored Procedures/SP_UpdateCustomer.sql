CREATE PROCEDURE SP_UpdateCustomer
(
	@customerID INT,
	@name VARCHAR(50),
	@address VARCHAR(150)
)
AS
BEGIN
	UPDATE customer
	SET name = @name,
	address = @address
	WHERE customerID = @customerID
END