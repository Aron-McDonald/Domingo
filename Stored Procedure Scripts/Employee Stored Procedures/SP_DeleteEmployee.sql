CREATE PROCEDURE SP_DeleteEmployee
(
	@employeeNo VARCHAR(6) = ''
)
AS
BEGIN
	DELETE FROM employee
	WHERE employeeNo = @employeeNo
END