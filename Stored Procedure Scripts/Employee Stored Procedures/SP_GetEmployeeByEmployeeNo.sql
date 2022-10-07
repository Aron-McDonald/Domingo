CREATE PROCEDURE SP_GetEmployeeByEmployeeNo
(
	@employeeNo VARCHAR(6)
)
AS
BEGIN

	SELECT * FROM employee WHERE employeeNo = @employeeNo

END