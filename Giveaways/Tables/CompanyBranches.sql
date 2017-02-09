CREATE TABLE [dbo].[CompanyBranches](
	[BranchID] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[AddressCont] [nvarchar](50) NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Zip] [int] NOT NULL,
 CONSTRAINT [PK_CompanyBranches] PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)
)