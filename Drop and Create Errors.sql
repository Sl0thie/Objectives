USE [dal11]
GO

/****** Object:  Table [dbo].[Errors]    Script Date: 27/08/2021 11:19:29 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Errors]') AND type in (N'U'))
DROP TABLE [dbo].[Errors]
GO

/****** Object:  Table [dbo].[Errors]    Script Date: 27/08/2021 11:19:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Errors](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[Processed] [int] NOT NULL,
	[HelpLink] [nvarchar](max) NOT NULL,
	[HResult] [int] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Source] [nvarchar](max) NOT NULL,
	[StackTrace] [nvarchar](max) NOT NULL,
	[TargetSite] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Errors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


