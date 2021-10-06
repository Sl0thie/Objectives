USE [dal11]
GO

/****** Object:  Table [dbo].[ObjClients]    Script Date: 27/08/2021 11:16:15 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ObjClients]') AND type in (N'U'))
DROP TABLE [dbo].[ObjClients]
GO

/****** Object:  Table [dbo].[ObjClients]    Script Date: 27/08/2021 11:16:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ObjClients](
	[Id] [uniqueidentifier] NOT NULL,
	[EntryId] [nvarchar](1024) NULL,
	[FirstName] [nvarchar](128) NULL,
	[MiddleName] [nvarchar](128) NULL,
	[LastName] [nvarchar](128) NULL,
	[Suffix] [nvarchar](8) NULL,
	[Title] [nvarchar](128) NULL,
	[Nickname] [nvarchar](128) NULL,
	[JobTitle] [nvarchar](128) NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[Archived] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


