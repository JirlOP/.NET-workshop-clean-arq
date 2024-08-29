﻿CREATE TABLE [dbo].[Users]
(
    [UserId] VARCHAR(256) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(320) NOT NULL UNIQUE, 
    [IsActive] BIT NOT NULL
)
