CREATE TABLE [dbo].[Company](
	[CompanyID] [int] NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)
)