CREATE PROCEDURE SP_InsertEmployee
(
	@employeeNo VARCHAR(6),
	@employeeName VARCHAR(50)
)
AS
BEGIN

	INSERT INTO employee(employeeNo, employeeName)
	VALUES(@employeeNo, @employeeName)

END