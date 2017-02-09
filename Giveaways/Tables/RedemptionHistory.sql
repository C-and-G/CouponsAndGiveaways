CREATE TABLE [dbo].[RedemptionHistory](
	[ID] [int] NOT NULL,
	[GiveawayID] [int] NOT NULL,
	[UserID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RedemptionHistory] PRIMARY KEY CLUSTERED ([ID] ASC))