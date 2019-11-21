CREATE TABLE [dbo].login
(
	[loginID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[username] VARCHAR(50),
	[password] VARCHAR(50)

)
