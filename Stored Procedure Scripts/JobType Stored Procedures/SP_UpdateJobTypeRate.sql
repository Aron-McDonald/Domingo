CREATE PROCEDURE SP_UpdateJobTypeRate
(
	@jobTypeID INT = 0,
	@dailyRate DECIMAL = 0
)
AS
BEGIN
	UPDATE jobType
	SET dailyRate = @dailyRate
	WHERE jobTypeID = @jobTypeID
END