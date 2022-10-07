CREATE PROCEDURE SP_GetInvoiceByInvoiceNo
(
	@invoiceNo INT
)
AS
BEGIN

SELECT i.jobCardNo, 
	name AS cutomerName,
	address,
	jT.jobType,
	jC.employeeNo,
	employeeName,
	material,
	quantity,
	CONCAT ( 'R', dailyRate) AS Rate,
	NoOfDays,
	CONCAT ( 'R', dailyRate * NoOfDays) AS 'Subtotal (Before VAT)',
	CONCAT ( 'R', (dailyRate * NoOfDays) * 0.14) AS 'VAT @14%',
	CONCAT ( 'R', (dailyRate * NoOfDays) + (dailyRate * NoOfDays) * 0.14) AS Total
FROM invoice i
JOIN customer c
ON @invoiceNo = i.invoiceNo AND c.customerID = i.customerID
JOIN job j
ON i.jobCardNo = j.jobCardNo
FULL JOIN jobContract jC
ON jC.jobCardNo = j.jobCardNo
FULL JOIN employee e
ON e.employeeNo = jC.employeeNo
FULL JOIN jobMaterial jM 
ON jM.jobCardNo = j.jobCardNo
FULL JOIN material m
ON m.materialID = jM.materialID
JOIN jobType jT
ON  jT.jobTypeID = j.jobTypeID;

END