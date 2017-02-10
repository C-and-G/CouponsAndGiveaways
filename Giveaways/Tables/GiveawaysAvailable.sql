CREATE TABLE [dbo].[GiveawaysAvailable](
	[Id] [nchar](10) NOT NULL,
	[GiveawayId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_GiveawaysAvailable] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_GiveawaysAvailable_Company] FOREIGN KEY([BranchId]) REFERENCES [dbo].[CompanyBranches] ([BranchId]),
 CONSTRAINT [FK_GiveawaysAvailable_CouponCategory] FOREIGN KEY([CategoryId]) REFERENCES [dbo].[CouponCategory] ([CategoryId]),
 CONSTRAINT [FK_GiveawaysAvailable_Giveaways] FOREIGN KEY([GiveawayId]) REFERENCES [dbo].[Giveaways] ([GiveawayId])
)