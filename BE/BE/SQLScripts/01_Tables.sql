print 'Begin of 01_Tables.sql';

--------------------------------------------------------------------------------------------
--- _Conversion
--------------------------------------------------------------------------------------------
IF db_name()<>'master' and
   NOT EXISTS (	SELECT * FROM information_schema.tables
		WHERE table_name='_Conversion' AND table_type='BASE TABLE')
BEGIN
	Print 'Create table _Conversion';
	CREATE TABLE [dbo].[_Conversion](
	
		[Id] [bigint] IDENTITY(1,1) NOT NULL,			-- PRIMARY KEY
		[ConversionType] [varchar](50) NOT NULL,
		[IsDone] [tinyint] NOT NULL,
		[Type] [smallint] NOT NULL,
		[ConversionDateUTC] [datetime] NOT NULL

		CONSTRAINT [PK__Conversion] PRIMARY KEY ([Id])
  	);
END;
--- END _Conversion


--------------------------------------------------------------------------------------------
--- Cities
--------------------------------------------------------------------------------------------
IF db_name()<>'master' and
   not exists (	select * from information_schema.tables
		where table_name='Cities' and table_type='BASE TABLE')
BEGIN
	Print 'Create table [Cities]';
	CREATE TABLE [dbo].[Cities](
		[CityID] [int] NOT NULL,
		[CityName] [nvarchar](50) NULL,
		[Country] [nvarchar](50) NULL,
		[Longitude] [nvarchar](50) NULL,
		[Latitude] [nvarchar](50) NULL

		CONSTRAINT [PK_Cities] PRIMARY KEY ([CityID])
  	);
END;
--- END Cities


--------------------------------------------------------------------------------------------
--- Users
--------------------------------------------------------------------------------------------
IF db_name()<>'master' and
   not exists (	select * from information_schema.tables
		where table_name='Users' and table_type='BASE TABLE')
BEGIN
	Print 'Create table [Users]';
	CREATE TABLE [dbo].[Users](
		[UserID] [bigint] IDENTITY(1,1) NOT NULL,
		[Email] [nvarchar](50) NOT NULL,
		[Password] [nvarchar](150) NOT NULL

		CONSTRAINT [PK_Users] PRIMARY KEY ([UserID])
  	);
END;
--- END Users


--------------------------------------------------------------------------------------------
--- UserGames
--------------------------------------------------------------------------------------------
IF db_name()<>'master' and
   not exists (	select * from information_schema.tables
		where table_name='UserGames' and table_type='BASE TABLE')
BEGIN
	Print 'Create table [UserGames]';
	CREATE TABLE [dbo].[UserGames](
	
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[UserID] [bigint] NOT NULL,
		[CreatedDate] DATETIME NOT NULL DEFAULT GETUTCDATE(),
		[SelectedRoutes] [nvarchar](300) NOT NULL

		CONSTRAINT [PK_UserGames] PRIMARY KEY ([ID]),
		CONSTRAINT [FK_UserGames_User] FOREIGN KEY([UserID]) REFERENCES [dbo].[Users] ([UserID])
  	);
END;
--- END UserGames





print 'End of 01_Tables.sql';
SET QUOTED_IDENTIFIER OFF 
GO
