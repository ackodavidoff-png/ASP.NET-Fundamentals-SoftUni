--use the database
USE [Cars4U]
GO
--select all records from the Cars table
SELECT * FROM [Cars]
GO
--adding the cars an image
UPDATE [Cars]
SET [ImageUrl] = 'https://cdn2.focus.bg/mobile/photosorg/683/1/big1/11779704424135683_kM.webp'
WHERE [Id] = 2;
GO
UPDATE [Cars]
SET [ImageUrl] = 'https://mobistatic2.focus.bg/mobile/photosorg/519/1/big1/11787313000058519_uS.webp'
WHERE [Id] = 3;
GO
--selecting all the records from the ApplicationUsers table and the town of the users
SELECT
	[ApplicationUsers].[Id],
	[ApplicationUsers].[FirstName],
	[ApplicationUsers].[LastName],
	[ApplicationUsers].[UserName],
	[ApplicationUsers].[PhoneNumber],
	[ApplicationUsers].[Email],
	[ApplicationUsers].[IsAdmin],
	[Towns].[Name] AS [Town]
FROM [ApplicationUsers]
JOIN [Towns]
ON [ApplicationUsers].[TownId] = [Towns].[Id];