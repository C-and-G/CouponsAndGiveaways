CREATE TABLE [dbo].[VideoHistory](
	[ID] [int] NOT NULL,
	[UserID] [nvarchar](50) NOT NULL,
	[WatchedInZip] [int] NOT NULL,
	[VideoID] [int] NOT NULL,
 CONSTRAINT [PK_VideoHistory] PRIMARY KEY CLUSTERED ([ID] ASC))