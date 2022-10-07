CREATE PROCEDURE SP_GetAllInvoices
AS
BEGIN

SELECT i.invoiceNo,
	i.jobCardNo, 
	name,
	address,
	jT.jobType,
	jC.employeeNo,
	employeeName,
	material, 
	quantity,
	dailyRate,
	NoOfDays,
	dailyRate * NoOfDays AS subtotal,
	(dailyRate * NoOfDays) * 0.14 AS VAT,
	(dailyRate * NoOfDays) + (dailyRate * NoOfDays) * 0.14 AS total
FROM invoice i
JOIN customer c
ON c.customerID = i.customerID
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
