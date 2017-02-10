CREATE TABLE [dbo].[CompanyBranches](
	[BranchId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[AddressCont] [nvarchar](50) NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Zip] [int] NOT NULL,
 CONSTRAINT [PK_CompanyBranches] PRIMARY KEY CLUSTERED ([BranchId] ASC),
 CONSTRAINT [FK_CompanyBranches_Company] FOREIGN KEY([CompanyId]) REFERENCES [dbo].[Company] ([CompanyId])
 )