CREATE TABLE [dbo].[UserDetails](
	[MemberID] [nvarchar] (50) NOT NULL,
	[FirstName] [nchar](20) NOT NULL,
	[LastName] [nchar](20) NOT NULL,
	[Gender] [char](10) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED ([MemberID] ASC),
 CONSTRAINT [FK_UserDetails_MemberID] FOREIGN KEY ([MemberID]) REFERENCES [LOGINDETAILS](MemberId)
 )