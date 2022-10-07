CREATE PROCEDURE SP_GetAllJobCards
AS
BEGIN
	SELECT jobCardNo,
	j.jobTypeID,
	jT.jobType,
	NoOfDays
	FROM job j
	JOIN jobType jT
	ON j.jobTypeID = jT.jobTypeID
END