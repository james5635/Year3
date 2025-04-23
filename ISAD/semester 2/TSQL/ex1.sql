USE master
GO

IF EXISTS (
    SELECT name
FROM sys.databases
WHERE name = N'Sou_Chanrojame'
)
BEGIN
    -- Set database to single user mode to kill all connections
    ALTER DATABASE [Sou_Chanrojame] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE [Sou_Chanrojame]
END
GO

CREATE DATABASE [Sou_Chanrojame]
GO

USE [Sou_Chanrojame]
GO

Create Table tbStudent
(
    StuID int Primary Key,
    StuName varchar(30),
    Sex char(1),
    BirthDate Date,
    Phone
        varchar(20),
    ParentPhone
        varchar(20),
    ContactAddress varchar(200)
)
GO

Create Table tbSubject
(
    SubjectID tinyint Primary Key,
    SubjectName varchar(100)
)
GO

Create Table tbExam
(
    StuID int,
    SubjectID tinyint,
    FirstExamScore tinyint,
    SecondExamScore tinyint,
    Constraint FKStuID Foreign Key(StuID) References
tbStudent(StuID) On Delete Cascade On Update
Cascade,
    Constraint
 FKSubjectID
 Foreign
Key(SubjectID) References tbSubject(SubjectID)
On Delete Cascade On Update Cascade,
    Constraint
PKStuIDSubjectID Primary Key(StuID,SubjectID)
)
GO

-- Inserting subjects
INSERT INTO tbSubject
    (SubjectID, SubjectName)
VALUES
    (1, 'Mathematics'),
    (2, 'English'),
    (3, 'Physics'),
    (4, 'Chemistry'),
    (5, 'Biology'),
    (6, 'History'),
    (7, 'Geography'),
    (8, 'Computer Science'),
    (9, 'Art'),
    (10, 'Physical Education')
GO

-- Inserting students
INSERT INTO tbStudent
    (StuID, StuName, Sex, BirthDate, Phone, ParentPhone, ContactAddress)
VALUES
    (101, 'Alice Johnson', 'F', '2010-04-12', '123-456-7890', '321-654-0987', '123 Apple St'),
    (102, 'Bob Smith', 'M', '2010-08-23', '234-567-8901', '432-765-1098', '456 Orange Ave'),
    (103, 'Charlie Brown', 'M', '2010-12-05', '345-678-9012', '543-876-2109', '789 Banana Blvd'),
    (104, 'Diana Ross', 'F', '2010-03-14', '456-789-0123', '654-987-3210', '321 Grape Dr'),
    (105, 'Evan Lee', 'M', '2010-07-30', '567-890-1234', '765-098-4321', '654 Mango Way')
GO

-- Inserting exam scores (randomized for example)
INSERT INTO tbExam
    (StuID, SubjectID, FirstExamScore, SecondExamScore)
VALUES
    -- Alice (101)
    (101, 1, 85, 88),
    (101, 2, 90, 92),
    (101, 3, 75, 78),
    (101, 4, 82, 85),
    (101, 5, 89, 90),
    (101, 6, 80, 83),
    (101, 7, 87, 89),
    (101, 8, 91, 93),
    (101, 9, 86, 88),
    (101, 10, 84, 87),
    -- Bob (102)
    (102, 1, 70, 72),
    (102, 2, 75, 77),
    (102, 3, 68, 69),
    (102, 4, 73, 74),
    (102, 5, 76, 78),
    (102, 6, 71, 73),
    (102, 7, 79, 80),
    (102, 8, 82, 84),
    (102, 9, 74, 75),
    (102, 10, 78, 79),
    -- Charlie (103)
    (103, 1, 88, 90),
    (103, 2, 85, 87),
    (103, 3, 80, 83),
    (103, 4, 86, 88),
    (103, 5, 82, 84),
    (103, 6, 84, 86),
    (103, 7, 81, 83),
    (103, 8, 89, 90),
    (103, 9, 90, 92),
    (103, 10, 85, 86),
    -- Diana (104)
    (104, 1, 92, 95),
    (104, 2, 90, 93),
    (104, 3, 88, 91),
    (104, 4, 91, 94),
    (104, 5, 89, 92),
    (104, 6, 87, 90),
    (104, 7, 85, 87),
    (104, 8, 93, 96),
    (104, 9, 91, 94),
    (104, 10, 88, 90),
    -- Evan (105)
    (105, 1, 65, 68),
    (105, 2, 70, 72),
    (105, 3, 60, 62),
    (105, 4, 66, 69),
    (105, 5, 72, 74),
    (105, 6, 68, 70),
    (105, 7, 67, 69),
    (105, 8, 75, 77),
    (105, 9, 69, 71),
    (105, 10, 73, 75)
GO


CREATE VIEW Result
AS
    Select S.StuID as [Student ID], StuName as [Name], Sex, SubjectName as [Subject], FirstExamScore as [Semester 1],
        Case When FirstExamScore<50 Then 'F'
When FirstExamScore<60 Then 'E'
When FirstExamScore <70 Then 'D'
When FirstExamScore <80 Then 'C'
When FirstExamScore <90 Then 'B'
Else
'A'
End As FirstGrade, SecondExamScore as [Semester 2],
        Case When SecondExamScore<50 Then 'F'
When SecondExamScore<60 Then 'E'
When SecondExamScore <70 Then 'D'
When SecondExamScore <80 Then 'C'
When SecondExamScore <90 Then 'B'
Else
'A'
End As SecondGrade,
        (FirstExamScore + SecondExamScore) /2 as [Final],
        Case When  (FirstExamScore + SecondExamScore) /2 <50 Then 'F'
When (FirstExamScore + SecondExamScore) /2 <60 Then 'E'
When (FirstExamScore + SecondExamScore) /2  <70 Then 'D'
When (FirstExamScore + SecondExamScore) /2  <80 Then 'C'
When (FirstExamScore + SecondExamScore) /2  <90 Then 'B'
Else
'A'
End As FinalGrade
    From tbSubject B Inner Join(tbExam E Inner Join tbStudent S On
E.StuID=S.StuID) On B.SubjectID=E.SubjectID
GO
CREATE VIEW FinalResult1 AS
SELECT [Student ID],
    SUM(CASE WHEN [Subject] = 'Mathematics' THEN [Semester 1] END) AS [Mathematics],
    SUM(CASE WHEN [Subject] = 'English' THEN [Semester 1] END) AS [English],
    SUM(CASE WHEN [Subject] = 'Physics' THEN [Semester 1] END) AS [Physics],
    SUM(CASE WHEN [Subject] = 'Chemistry' THEN [Semester 1] END) AS [Chemistry],
    SUM(CASE WHEN [Subject] = 'Biology' THEN [Semester 1] END) AS [Biology],
    SUM(CASE WHEN [Subject] = 'History' THEN [Semester 1] END) AS [History],
    SUM(CASE WHEN [Subject] = 'Geography' THEN [Semester 1] END) AS [Geography],
    SUM(CASE WHEN [Subject] = 'Computer Science' THEN [Semester 1] END) AS [Computer Science],
    SUM(CASE WHEN [Subject] = 'Art' THEN [Semester 1] END) AS [Art],
    SUM(CASE WHEN [Subject] =  'Physical Education' THEN [Semester 1] END) AS [Physical Education],
    SUM([Semester 1]) AS Total,
    RANK () OVER(ORDER BY SUM([Semester 1]) DESC ) AS [Rank]
FROM Result
GROUP BY [Student ID]
GO
CREATE VIEW FinalResult2 AS
SELECT [Student ID],
    SUM(CASE WHEN [Subject] = 'Mathematics' THEN [Semester 2] END) AS [Mathematics],
    SUM(CASE WHEN [Subject] = 'English' THEN [Semester 2] END) AS [English],
    SUM(CASE WHEN [Subject] = 'Physics' THEN [Semester 2] END) AS [Physics],
    SUM(CASE WHEN [Subject] = 'Chemistry' THEN [Semester 2] END) AS [Chemistry],
    SUM(CASE WHEN [Subject] = 'Biology' THEN [Semester 2] END) AS [Biology],
    SUM(CASE WHEN [Subject] = 'History' THEN [Semester 2] END) AS [History],
    SUM(CASE WHEN [Subject] = 'Geography' THEN [Semester 2] END) AS [Geography],
    SUM(CASE WHEN [Subject] = 'Computer Science' THEN [Semester 2] END) AS [Computer Science],
    SUM(CASE WHEN [Subject] = 'Art' THEN [Semester 2] END) AS [Art],
    SUM(CASE WHEN [Subject] =  'Physical Education' THEN [Semester 2] END) AS [Physical Education],
    SUM([Semester 2]) AS Total,
    RANK () OVER(ORDER BY SUM([Semester 2]) DESC ) AS [Rank]
FROM Result
GROUP BY [Student ID]
GO

SELECT * FROM FinalResult1
SELECT * FROM FinalResult2