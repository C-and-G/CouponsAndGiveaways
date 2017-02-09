CREATE TABLE [dbo].[CouponCategory](
	[CategoryID] [int] NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CouponCategory] PRIMARY KEY CLUSTERED ([CategoryID] ASC)
 )