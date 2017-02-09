CREATE TABLE [dbo].[Giveaways](
	[GiveawayID] [int] NOT NULL,
	[GiveawayTypeID] [int] NOT NULL,
	[GiveawayStatus] [bit] NULL DEFAULT 0,
	[GiveawayName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Giveaways] PRIMARY KEY CLUSTERED ([GiveawayID] ASC),
 )