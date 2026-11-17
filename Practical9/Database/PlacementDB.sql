IF DB_ID('PlacementDB') IS NULL
    CREATE DATABASE PlacementDB;
GO
USE PlacementDB;
GO
IF OBJECT_ID('dbo.Students', 'U') IS NOT NULL DROP TABLE dbo.Students;
GO
CREATE TABLE dbo.Students
(
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    StudentName NVARCHAR(100) NOT NULL,
    Department NVARCHAR(50) NOT NULL,
    Email NVARCHAR(120) NULL,
    CompanyName NVARCHAR(100) NULL,
    PackageLPA DECIMAL(6,2) NULL,
    PlacementDate DATE NULL,
    Status NVARCHAR(20) NOT NULL
);
GO
INSERT INTO dbo.Students
(StudentName, Department, Email, CompanyName, PackageLPA, PlacementDate, Status)
VALUES
('Aarav Patel','Computer','aarav@example.com','TCS',4.50,'2026-03-12','Placed'),
('Diya Shah','Computer','diya@example.com','Infosys',5.20,'2026-03-18','Placed'),
('Krish Mehta','IT','krish@example.com','Wipro',4.00,'2026-04-02','Placed'),
('Anaya Desai','Computer','anaya@example.com',NULL,NULL,NULL,'Not Placed'),
('Reyansh Joshi','IT','reyansh@example.com','Capgemini',4.80,'2026-04-10','Placed'),
('Ira Trivedi','Mechanical','ira@example.com',NULL,NULL,NULL,'Not Placed'),
('Vivaan Parmar','Civil','vivaan@example.com','L&T',3.80,'2026-04-15','Placed'),
('Myra Dave','Computer','myra@example.com','Microsoft',12.00,'2026-04-20','Placed'),
('Advik Rana','Mechanical','advik@example.com',NULL,NULL,NULL,'Not Placed'),
('Sara Vyas','IT','sara@example.com','Accenture',4.20,'2026-04-25','Placed');
GO
