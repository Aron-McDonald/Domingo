CREATE PROCEDURE SP_CreateJobCard
(
	@jobCardNo INT = 0,
	@jobTypeID INT = 0,
	@NoOfDays INT = 0
)
AS
BEGIN

	INSERT INTO job (jobCardNo, jobtypeID, NoOfDays)
	VALUES (@jobCardNo, @jobTypeID, @NoOfDays)

END