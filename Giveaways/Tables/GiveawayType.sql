CREATE TABLE [dbo].[GiveawayType](
	[GiveawayTypeID] [int] NOT NULL,
	[GiveawayTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GiveawayType] PRIMARY KEY CLUSTERED 
(
	[GiveawayTypeID] ASC
)
)