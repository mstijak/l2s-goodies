USE [master]
GO
/****** Object:  Database [Test]    Script Date: 12/04/2011 17:17:07 ******/
CREATE DATABASE [Test]
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DOB] [datetime] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Person] ON
INSERT [dbo].[Person] ([PersonId], [Name], [DOB]) VALUES (1, N'Test', NULL)
SET IDENTITY_INSERT [dbo].[Person] OFF
