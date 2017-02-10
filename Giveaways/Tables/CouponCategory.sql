CREATE TABLE [dbo].[CouponCategory](
	[CategoryId] [int] NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CouponCategory] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
 )