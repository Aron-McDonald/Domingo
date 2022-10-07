USE master

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'DomingoDB')
DROP DATABASE DomingoDB
CREATE DATABASE DomingoDB
USE DomingoDB

-- CREATING TABLES (Chao,2014).

CREATE TABLE customer(
customerID INT IDENTITY(1,1) NOT NULL,
name VARCHAR(50) NOT NULL,
address VARCHAR (150) NOT NULL,
PRIMARY KEY (customerID)
);

CREATE TABLE employee(
employeeNo VARCHAR(6) NOT NULL,
employeeName VARCHAR(50) NOT NULL,
PRIMARY KEY (employeeNo)
);

CREATE TABLE jobType(
jobTypeID INT IDENTITY(1,1) NOT NULL,
jobType VARCHAR(20) NOT NULL,
dailyRate DECIMAL NOT NULL,
PRIMARY KEY (jobTypeID)
);

CREATE TABLE material(
materialID INT IDENTITY(1,1) NOT NULL,
material VARCHAR(150) NOT NULL,
PRIMARY KEY (materialID)
);

CREATE TABLE job(
jobCardNo INT NOT NULL,
jobTypeID INT NOT NULL,
NoOfDays INT NOT NULL,
PRIMARY KEY (jobCardNo),
FOREIGN KEY (jobTypeID) REFERENCES jobType(jobTypeID)
);

CREATE TABLE jobMaterial(
jobMaterialID INT IDENTITY(1,1) NOT NULL,
jobCardNo INT NOT NULL,
materialID INT NOT NULL,
quantity VARCHAR(50) NOT NULL,
PRIMARY KEY (jobMaterialID),
FOREIGN KEY (jobCardNo) REFERENCES job(jobCardNo)
);

CREATE TABLE jobContract(
contractNo INT IDENTITY(1,1) NOT NULL,
jobCardNo INT NOT NULL,
employeeNo VARCHAR(6) NOT NULL,
PRIMARY KEY (contractNo),
FOREIGN KEY (jobCardNo) REFERENCES job(jobCardNo),
FOREIGN KEY (employeeNo) REFERENCES employee(employeeNo)
);

CREATE TABLE invoice(
invoiceNo INT IDENTITY(1,1) NOT NULL,
jobCardNo INT NOT NULL,
customerID INT NOT NULL,
jobTypeID INT NOT NULL,
PRIMARY KEY (invoiceNo),
FOREIGN KEY (jobCardNo) REFERENCES job(jobCardNo),
FOREIGN KEY (customerID) REFERENCES customer(customerID),
FOREIGN KEY (jobTypeID) REFERENCES jobType(jobTypeID)
);

-- SHOWING FINISHED TABLES (Chao, 2014).

SELECT *
FROM customer;

SELECT *
FROM employee;

SELECT *
FROM jobType;

SELECT *
FROM material;

SELECT *
FROM job;

SELECT *
FROM jobMaterial;

SELECT *
FROM jobContract;

SELECT *
FROM invoice;


-- POPULATING DATA FOR ALL JOB CARDS AND DETAILS OF THOSE JOBS (Chao,2014).

INSERT INTO jobType (jobType, dailyRate)
VALUES ('Full Conversion', 1200.00),
('Semi Conversion', 1080.00),
('Floor Boarding', 900.00);

INSERT INTO job (jobCardNo, jobTypeID, NoOfDays)
VALUES (11000, 1, 7),
(10478, 2, 2),
(14253, 3, 2),
(11258, 1, 8),
(12058, 2, 3),
(13697, 1, 7),
(10211, 1, 7),
(10471, 2, 2),
(13521, 2, 3),
(10102, 3, 2);

INSERT INTO customer(name, address)
VALUES('Tendai Ndoro', '3 Leos Place 457 Church Str PRETORIA, 0002'),
('Donald Puttingh', '408 Oubos 368 Prinsloo Street PRETORIA, 0001'),
('Tracy Samson', '206 Albertros 269 Stead Avenue PRETORIA, 0186'),
('Jacob Smith', 'A201 Overton 269 Debouvlrde Str PRETORIA, 0002'),
('Thato Molopo', '11 Luttig Court 289  MALTZAN Str PRETORIA, 0001'),
('Dakolo Mudau', '1182 CEBINIA Str PRETORIA, 0082'),
('Sifiso Myeni', '503 Hamilton Gardens 337 Visagie Str PRETORIA, 0001'),
('Ricardo Keyla', '10 Silville 614 Jasmyn Str PRETORIA, 0184'),
('Smallboy Mtshali', '307 FEORA East PRETORIA-WEST, 0183'),
('Wilson Jansen', '701 Monticchico Flat251 Jacob Mare Str PRETORIA, 0002');

INSERT INTO invoice(jobCardNo, customerID, jobTypeID)
VALUES(11000, 1, 1),
(10478, 2, 2),
(14253, 3, 3),
(11258, 4, 1),
(12058, 5, 2),
(13697, 6, 1),
(10211, 7, 1),
(10471, 8, 2),
(13521, 9, 2),
(10102, 10, 3);

-- LISTING OF THE JOB TABLE (Chao, 2014).

SELECT *
FROM job;


-- POPULATING DATA FOR EMPLOYEES (Chao, 2014).

INSERT INTO employee(employeeNo, employeeName)
VALUES('EMP100', 'Albert Malose'),
('EMP920', 'Chris Byne'),
('EMP010', 'John hendriks'),
('EMP771', 'Smallboy Modipa'),
('EMP681', 'Stanley Jacobs');

-- ASSIGNING EMPLOYEES TO JOB CARDS (Chao, 2014).

INSERT INTO jobContract(jobCardNo, employeeNo)
VALUES(11000, 'EMP100'),
(11000, 'EMP920'),
(11000, 'EMP010'),
(10478, 'EMP920'),
(14253, 'EMP771'),
(11258, 'EMP681'),
(11258, 'EMP010'),
(11258, 'EMP771'),
(12058, 'EMP681');

-- LISTING OF THE EMPLOYEE TABLE (Chao, 2014).

SELECT*
FROM employee;


-- POPULATING DATA ON MATERIALS THAT ARE USED ON A JOB CARD (Chao, 2014).

INSERT INTO material(material)
VALUES('Standard floorboards'),
('Power points'),
('Standard electrical wiring'),
('Standard stairs pack');

INSERT INTO jobMaterial(jobCardNo, materialID, quantity)
VALUES
-- JOB 11000.
(11000, 1, '90'),
(11000, 2, '3'),
(11000, 3, '20 metres'),
(11000, 4, '1'),

-- JOB 10478.
(10478, 1, '50'),
(10478, 2, '1'),
(10478, 3, '10 metres'),

-- JOB 14253.
(14253, 1, '40'),

-- JOB 11258.
(11258, 1, '80'),
(11258, 2, '3'),
(11258, 3, '20 metres'),
(11258, 4, '1'),


-- JOB 12058.
(12058, 1, '60'),
(12058, 2, '2'),
(12058, 3, '15 metres'),

-- JOB 13697.
(13697, 1, '80'),
(13697, 2, '4'),
(13697, 3, '40 metres'),
(13697, 4, '1'),

-- JOB 10211.
(10211, 1, '100'),
(10211, 2, '5'),
(10211, 3, '30 metres'),
(10211, 4, '1'),

-- JOB 10471.
(10471, 1, '40'),
(10471, 2, '1'),
(10471, 3, '8 metres'),

-- JOB 13521.
(13521, 1, '65'),
(13521, 2, '3'),
(13521, 3, '18 metres'),

-- JOB 10102.
(10102, 1, '70');

-- LISTING OF THE JOBMATERIAL TABLE / MATERIALS THAT ARE USED ON A JOB (Chao, 2014).

SELECT jobMaterialID,
	jobCardNo,
	jM.materialID,
	material,
	quantity
FROM jobMaterial JM
-- JOINING THE MATERIAL TABLE TO DISPLAY THE MATERIALS CORRESPONDING TO THEIR ID'S.
JOIN material m
ON jM.materialID = m.materialID;


-- QUERY THAT SELECTS ALL THE JOB CARDS AND WHICH EMPLOYEES HAVE WORKED ON THEM (Chao, 2014).

SELECT j.jobCardNo, 
	jC.employeeNo,
	e.employeeName
FROM jobContract jC
FULL JOIN job j
ON j.jobCardNo = jC.jobCardNo
FULL JOIN employee e
ON e.employeeNo = jC.employeeNo;


-- QUERY THAT SELECTS ALL MATERIALS USED ON JOB CARDS OF TYPE 'FULL CONVERSION' (Chao, 2014).

SELECT jobMaterialID, 
	j.jobCardNo, 
	jM.materialID,
	material,
	quantity, 
	j.jobTypeID,
	jobType
FROM jobMaterial jM
JOIN job j
ON j.jobCardNo = jM.jobCardNo
JOIN jobType jT
ON jT.jobTypeID = j.jobTypeID
AND jT.jobType = 'Full Conversion'
JOIN material m
ON m.materialID = jM.materialID;


-- QUERY THAT SELECTS ALL JOB CARDS THAT CHRIS BYNE HAS WORKED ON (Chao, 2014) & (w3schools.com, 2021).

SELECT *
FROM jobContract jC
WHERE EXISTS(
	SELECT *
	FROM employee e
	WHERE e.employeeNo = jC.employeeNo 
	AND e.employeeName = 'Chris Byne'
);


-- QUERY THAT SHOWS ALL JOB CARDS THAT HAVE TAKEN PLACE IN ADDRESSES THAT CONTAIN '0001' OR '0002' (Chao, 2014).

SELECT jobCardNo,
	i.customerID,
	name AS customerName,
	address
FROM invoice i
JOIN customer c
ON i.customerID = c.customerID
WHERE (c.address LIKE '%0001%' OR c.address LIKE '%0002%')
ORDER BY i.customerID ASC;

-- QUERY THAT COUNTS THE NUMBER OF JOBS THAT HAVE USED ELECTRICAL WIRING (Chao, 2014) & (w3schools.com, 2021).

SELECT COUNT(*) AS 'Number of jobs that have used electrical wirirng'
FROM jobMaterial
WHERE materialID = 3;


-- QUERY THAT PRODUCES THE OUTPUT THAT COULD BE USED TO PREPARE AN INVOICE 
-- (FOR A CERTAIN JOB CARD) [IMITATING THE INVOICE EXAMPLE] (geeksengine.com, 2021),
-- (w3schools.com, 2021), and (Chao, 2014).

SELECT i.jobCardNo, 
	name AS cutomerName,
	address,
	jT.jobType,
	jC.employeeNo,
	employeeName,
	CONCAT (material, ' x ', quantity) AS 'Material and Quantity',
	CONCAT ( 'R', dailyRate) AS Rate,
	NoOfDays,
	CONCAT ( 'R', dailyRate * NoOfDays) AS 'Subtotal (Before VAT)',
	CONCAT ( 'R', (dailyRate * NoOfDays) * 0.14) AS 'VAT @14%',
	CONCAT ( 'R', (dailyRate * NoOfDays) + (dailyRate * NoOfDays) * 0.14) AS Total
FROM invoice i
JOIN customer c
ON c.customerID = i.customerID
JOIN job j
ON j.jobCardNo = 12058 AND i.jobCardNo = j.jobCardNo
FULL JOIN jobContract jC
ON jC.jobCardNo = j.jobCardNo
FULL JOIN employee e
ON e.employeeNo = jC.employeeNo
JOIN jobMaterial jM 
ON jM.jobCardNo = j.jobCardNo
JOIN material m
ON m.materialID = jM.materialID
JOIN jobType jT
ON  jT.jobTypeID = j.jobTypeID;


-- QUERY TO UPDATE THE DAILY RATE OF PAY FOR A FULL CONVERSION TO R1 440.00 (Chao, 2014).

UPDATE jobType 
SET dailyRate = 1440.00 
WHERE jobType = 'Full Conversion';


-- CHECKING THE JOBTYPE TABLE TO CONFIRM UPDATED FULL CONVERSION DAILY RATE (Chao, 2014).

SELECT *
FROM jobType;

	
-- STORED PROCEDURES (Chao, 2014).


-- CREATE A NEW JOBCARD.

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

-- READING ALL JOB CARDS.

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

-- GET A JOB CARD BY JOB ID

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

CREATE PROCEDURE SP_DeleteJobCard
(
	@jobCardNo INT = 0
)
AS
BEGIN
	DELETE FROM job
	WHERE jobCardNo = @jobCardNo
END

-- GET ALL JOB TYPES.

CREATE PROCEDURE SP_GetAllJobTypes
AS
BEGIN
	SELECT * FROM jobType
END

-- GET JOB TYPE BY JOB TYPE ID.

CREATE PROCEDURE SP_GetJobTypeByJobTypeID
(
	@jobTypeID INT = 0
)
AS
BEGIN
	SELECT * 
	FROM jobType 
	WHERE jobTypeID = @jobTypeID
END

-- UPDATE JOB TYPE DAILY RATE BY JOBTYPE ID.

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


-- RETRIEVE ALL INVOICES.

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

-- RETRIEVE AN INVOICE BY INVOICE NUMBER.

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

-- CREATE NEW INVOICE.

CREATE PROCEDURE SP_CreateInvoice
(
	@jobCardNo INT = 0,
	@customerID INT = 0,
	@jobTypeID INT = 0
)
AS
BEGIN

	INSERT INTO invoice(jobCardNo, customerID, jobTypeID)
	VALUES(@jobCardNo, @customerID, @jobTypeID)

END

-- CREATE CUSTOMER

CREATE PROCEDURE SP_CreateCustomer
(
	@name VARCHAR(50) = '',
	@address VARCHAR (150) = ''
)
AS
BEGIN

	INSERT INTO customer (name, address)
	VALUES(@name, @address)

END

-- GET ALL CUSTOMERS

CREATE PROCEDURE SP_GetAllCustomers
AS
BEGIN
	SELECT * FROM customer
END

-- GET CUSTOMER BY CUSTOMER ID

CREATE PROCEDURE SP_GetCustomerByCustomerID
(
	@customerID INT
)
AS
BEGIN
	SELECT *
	FROM customer
	WHERE @customerID = customerID
END

-- UPDATE CUSTOMER INFORMATION

CREATE PROCEDURE SP_UpdateCustomer
(
	@customerID INT,
	@name VARCHAR(50),
	@address VARCHAR(150)
)
AS
BEGIN
	UPDATE customer
	SET name = @name,
	address = @address
	WHERE customerID = @customerID
END

-- DELETE CUSTOMER

CREATE PROCEDURE SP_DeleteCustomer
(
	@customerID INT
)
AS
BEGIN
	DELETE FROM customer
	WHERE @customerID = customerID
END

-- GET ALL EMPLOYEES

CREATE PROCEDURE SP_GetAllEmployees
AS
BEGIN
	SELECT * FROM employee
END

-- GET AN EMPLOYEE BY EMPLOYEE No.

CREATE PROCEDURE SP_GetEmployeeByEmployeeNo
(
	@employeeNo VARCHAR(6) = ''
)
AS
BEGIN

	SELECT * FROM employee WHERE employeeNo = @employeeNo

END

-- DELETE AN EMPLOYEE.

CREATE PROCEDURE SP_DeleteEmployee
(
	@employeeNo VARCHAR(6) = ''
)	
AS
BEGIN
	DELETE FROM employee
	WHERE employeeNo = @employeeNo
END

-- INSERT NEW EMPLOYEE.

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

-- UPDATE EMPLOYEE INFORMATION.

CREATE PROCEDURE SP_UpdateEmployee
(
	@employeeID INT = 0,
	@employeeNo VARCHAR(6),
	@employeeName VARCHAR(50)
)
AS
BEGIN

	UPDATE employee
	SET employeeName = @employeeName
	WHERE employeeNo = @employeeNo

END