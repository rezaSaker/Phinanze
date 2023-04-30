CREATE TABLE [dbo].[Earning]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Amount] FLOAT NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [DailyInfoId] INT NOT NULL, 
    [Comment] TEXT NULL
)
