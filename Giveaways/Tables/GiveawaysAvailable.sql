CREATE TABLE [dbo].[GiveawaysAvailable](
	[ID] [nchar](10) NOT NULL,
	[GiveawayID] [int] NOT NULL,
	[BranchID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_GiveawaysAvailable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)
)