CREATE TABLE [dbo].[LoginDetails](
	[MemberId] [nvarchar] (50) NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[Salt] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[VerificationStatus] [bit] NOT NULL DEFAULT 0,
 CONSTRAINT [PK_LoginDetails] PRIMARY KEY CLUSTERED ([UserId] ASC),
 CONSTRAINT [Unique_MemberId] UNIQUE ([MemberId]),
 CONSTRAINT [FK_LoginDetails_UserDetails] FOREIGN KEY([MemberId]) REFERENCES [dbo].[UserDetails] ([MemberId])
)