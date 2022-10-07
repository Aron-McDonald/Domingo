CREATE PROCEDURE SP_GetJobCardByJobCardNo
(
	@jobCardNo INT = 0
)
AS
BEGIN

	SELECT jobCardNo,
	j.jobTypeID,
	jT.jobType,
	NoOfDays
	FROM job j
	JOIN jobType jT
	ON j.jobTypeID = jT.jobTypeID
	WHERE jobCardNo = @jobCardNo

END