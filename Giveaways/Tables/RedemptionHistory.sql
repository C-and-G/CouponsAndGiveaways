CREATE TABLE [dbo].[RedemptionHistory](
	[Id] [int] NOT NULL,
	[GiveawayId] [int] NOT NULL,
	[MemberId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RedemptionHistory] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_RedemptionHistory_Giveaways] FOREIGN KEY([GiveawayId]) REFERENCES [dbo].[Giveaways] ([GiveawayId]),
 CONSTRAINT [FK_RedemptionHistory_UserDetails] FOREIGN KEY([MemberId]) REFERENCES [dbo].[UserDetails] ([MemberId])
 )