CREATE PROCEDURE SP_DeleteJobCard
(
	@jobCardNo INT = 0
)
AS
BEGIN
	DELETE FROM job
	WHERE jobCardNo = @jobCardNo
END