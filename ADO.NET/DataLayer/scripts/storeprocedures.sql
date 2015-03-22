CREATE PROCEDURE GETEMPPLOYEEDETAILS
@businessEntityId int
AS

select * from HumanResources.Employee E
			JOIN Person.Person P ON E.BusinessEntityId = P.BusinessEntityId AND P.PersonType = 'EM'
			JOIN HumanResources.EmployeeDepartmentHistory EH ON E.BusinessEntityId = EH.BusinessEntityId
			JOIN HumanResources.Department D ON D.DepartmentId = EH.DepartmentId
where
	E.BusinessEntityId = @businessEntityId

	GO

CREATE TABLE APPLICATIONLOG(
id int IDENTITY(1,1) primary key,
date_added DATETIME NOT NULL DEFAULT(GETUTCDATE()),
comment ntext NOT NULL,
application_name nvarchar(100))

GO

CREATE PROCEDURE AddAppLog
@comment ntext
AS

INSERT INTO dbo.ApplicationLog VALUES(
DEFAULT,@comment, (SELECT app_name()))

GO

CREATE PROCEDURE AddAppLog2
@comment ntext
AS

SET NOCOUNT ON

INSERT INTO dbo.ApplicationLog VALUES(
DEFAULT,@comment, (SELECT app_name()))

-- SCOPE_IDENTITY : Returns the last identity value inserted into an identity column in the same scope
Select SCOPE_IDENTITY()

GO

CREATE PROCEDURE AddAppLog3
@comment ntext,
@outid int output

AS

SET NOCOUNT ON

INSERT INTO dbo.ApplicationLog VALUES(
DEFAULT,@comment, (SELECT app_name()))

-- SCOPE_IDENTITY : Returns the last identity value inserted into an identity column in the same scope
SET @outid = SCOPE_IDENTITY()

GO

CREATE PROCEDURE AddAppLog4
@comment ntext

AS

SET NOCOUNT ON

INSERT INTO dbo.ApplicationLog VALUES(
DEFAULT,@comment, (SELECT app_name()))

RETURN scope_identity()

GO

CREATE PROCEDURE DeleteAppLog
@appname nvarchar(100)
AS

SET NOCOUNT ON

DELETE FROM [dbo].[APPLICATIONLOG] WHERE application_name = @appname

GO

CREATE PROCEDURE UpdateDepartmentName
@id int,
@name nvarchar(100)
AS

SET NOCOUNT ON

UPDATE HumanResources.Department
SET Name = @name
where DepartmentID = @id

GO

ALTER PROCEDURE [dbo].[UpdateDepartmentName]
@id int,
@name nvarchar(100)
AS

SET NOCOUNT ON

IF(@name = 'test')
BEGIN
	--use the THROW command with SQL SERVER 2012 instead
	RAISERROR('invalid department name',16,1)
	RETURN
END

UPDATE HumanResources.Department
SET Name = @name
where DepartmentID = @id

GO


CREATE PROCEDURE [dbo].[SP_ThrowException]
AS

SET NOCOUNT ON
	--use the THROW command with SQL SERVER 2012 instead
	RAISERROR('custom exception throw from the database',16,1)
	RETURN

GO

CREATE PROCEDURE [dbo].[UpdateDepartmentNameWithConcurrencyCheckWhere]
@id int,
@name nvarchar(100),
@oldname nvarchar(100)
AS

SET NOCOUNT ON

IF(@name = 'test')
BEGIN
	--use the THROW command with SQL SERVER 2012 instead
	RAISERROR('invalid department name',16,1)
	RETURN
END

UPDATE HumanResources.Department
SET Name = @name
where DepartmentID = @id
AND name = @oldname

--WARNING: Use @@rowcount immediately after the UPDATE statement
if(@@ROWCOUNT = 0)
Begin

RAISERROR('Concurrency error detected',16,1)
RETURN

End

GO

CREATE PROCEDURE [dbo].GETAPPLOG
AS
begin

SET NOCOUNT ON

select * from dbo.APPLICATIONLOG

End

GO

CREATE PROCEDURE [dbo].[DeleteAppLogUsingDbTransaction]
@appname nvarchar(100)
AS

SET NOCOUNT ON

SET XACT_ABORT ON --rollback on all errors

BEGIN TRAN

DELETE FROM [dbo].[APPLICATIONLOG] WHERE application_name = @appname

DECLARE	@comment nvarchar(100)
SET @comment = 'Delete all comments using a database transaction'
EXEC [dbo].[AddAppLog4] @comment

COMMIT;

GO

ALTER TABLE ApplicationLog ADD extra_data xml null

GO

CREATE PROCEDURE [dbo].[AddAppLog5]
@comment ntext,
@extra_data xml

AS

SET NOCOUNT ON

INSERT INTO dbo.ApplicationLog VALUES(
DEFAULT,@comment, (SELECT app_name()), @extra_data)

RETURN scope_identity()

GO

CREATE PROCEDURE UpdateLogMass
@xmlchanges xml
AS 

SET NOCOUNT ON
DECLARE @handle int
EXEC sp_xml_preparedocument @handle OUTPUT, @xmlchanges

UPDATE APPLICATIONLOG
	SET 
	comment = updatedcomment,
	date_added = dateupdated
FROM OPENXML(@handle, N'changes/change')
WITH (operation nchar(10) '@op', dateupdated datetime '@datetime', updatedcomment ntext '@comment', logid int '@id')
WHERE operation = 'UPDATE' and id = logid

EXEC sp_xml_removedocument @handle


GO

CREATE PROCEDURE UpdateLogMass_2
@xmlchanges xml
AS 

SET NOCOUNT ON
DECLARE @handle int
DECLARE @rowsaffected int
EXEC sp_xml_preparedocument @handle OUTPUT, @xmlchanges

UPDATE APPLICATIONLOG
	SET 
	comment = updatedcomment,
	date_added = dateupdated
FROM OPENXML(@handle, N'changes/change')
WITH (operation nchar(10) '@op', dateupdated datetime '@datetime', updatedcomment ntext '@comment', logid int '@id')
WHERE operation = 'UPDATE' and id = logid

SET @rowsaffected = @@ROWCOUNT

EXEC sp_xml_removedocument @handle

--RETURN  2 Result sets using MARS

SELECT @rowsaffected as RowsAffected
SELECT * from APPLICATIONLOG

GO




