CREATE PROCEDURE SP_CreateCustomer
(
	@name VARCHAR(50) = '',
	@address VARCHAR (150) = ''
)
AS
BEGIN

	INSERT INTO customer (name, address)
	VALUES(@name, @address)

END