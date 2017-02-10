CREATE TABLE [dbo].[Giveaways](
	[GiveawayId] [int] NOT NULL,
	[GiveawayTypeId] [int] NOT NULL,
	[GiveawayStatus] [bit] NULL DEFAULT 0,
	[GiveawayName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Giveaways] PRIMARY KEY CLUSTERED ([GiveawayId] ASC),
 CONSTRAINT [FK_Giveaways_GiveawayType] FOREIGN KEY([GiveawayTypeId]) REFERENCES [dbo].[GiveawayType] ([GiveawayTypeId])
 )