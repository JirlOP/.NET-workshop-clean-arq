/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/*
	Script to
*/
-- MERGE is a SQL command that allows you to perform insert, update, or delete operations in a single statement
/*
	- MERGE INTO: Specifies the target table to update, insert, or delete rows in.
	- USING: Specifies the source of the data to be inserted, updated, or deleted.
	- ON: Specifies the condition to determine whether a row should be updated or inserted.
	- WHEN MATCHED: Specifies the action to take when a row is matched.
	- WHEN NOT MATCHED: Specifies the action to take when a row is not matched.
*/
MERGE INTO Users AS Target
USING(VALUES -- Test data USING clause specifies the source of the data to be inserted, updated, or deleted 
    ('6ab342d1-e9d8-4a17-8a91-4b5a5a1c4417', 'Jorge', 'Sagot', 'jorge.diazsagot@ucr.ac.cr', 0),
    ('772f7fc0-fbf4-48b0-aa35-93a93e2673e3', 'Daniel', 'Conejo', 'daniel.conejo@ucr.ac.cr', 1),
    ('850d6ac0-04be-4814-aa27-ca040fdbfccb', 'Totoro', 'Ghibli', 'totoro.ghibli@ucr.ac.cr', 1)
) 
AS SOURCE ([UserId], [Name], [LastName], [Email], [IsActive])
	ON TARGET.[UserId] = SOURCE.[UserId]
-- when not matched by target, insert
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([UserId], [Name], [LastName], [Email], [IsActive])
	VALUES (SOURCE.[UserId], SOURCE.[Name], SOURCE.[LastName], SOURCE.[Email], SOURCE.[IsActive])
-- when matched, update
WHEN MATCHED THEN
	UPDATE SET
		[Name] = SOURCE.[Name],
		[LastName] = SOURCE.[LastName],
		[Email] = SOURCE.[Email],
		[IsActive] = SOURCE.[IsActive];
