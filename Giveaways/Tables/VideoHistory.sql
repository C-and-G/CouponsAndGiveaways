CREATE TABLE [dbo].[VideoHistory](
	[Id] [int] NOT NULL,
	[MemberId] [nvarchar](50) NOT NULL,
	[WatchedInZip] [int] NOT NULL,
	[VideoId] [int] NOT NULL,
 CONSTRAINT [PK_VideoHistory] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_VideoHistory_UserDetails] FOREIGN KEY([MemberId]) REFERENCES [dbo].[UserDetails] ([MemberId]), 
 CONSTRAINT [FK_VideoHistory_VideoURLs] FOREIGN KEY([VideoId]) REFERENCES [dbo].[VideoURLs] ([VideoId])
 )