CREATE PROCEDURE SP_UpdateEmployee
(
	@employeeNo VARCHAR(6),
	@employeeName VARCHAR(50)
)
AS
BEGIN

	UPDATE employee
	SET employeeName = @employeeName
	WHERE employeeNo = @employeeNo

END