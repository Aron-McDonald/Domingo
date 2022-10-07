CREATE PROCEDURE SP_GetJobTypeByJobTypeID
(
	@jobTypeID INT = 0
)
AS
BEGIN
	SELECT * FROM jobType WHERE jobTypeID = @jobTypeID
END