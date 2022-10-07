CREATE PROCEDURE SP_CreateInvoice
(
	@jobCardNo INT = 0,
	@customerID INT = 0,
	@jobTypeID INT = 0
)
AS
BEGIN

	INSERT INTO invoice(jobCardNo, customerID, jobTypeID)
	VALUES(@jobCardNo, @customerID, @jobTypeID)

END