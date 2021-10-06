USE [dal11]
GO

/****** Object:  Table [dbo].[Objectives]    Script Date: 27/08/2021 11:17:33 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Objectives]') AND type in (N'U'))
DROP TABLE [dbo].[Objectives]
GO

/****** Object:  Table [dbo].[Objectives]    Script Date: 27/08/2021 11:17:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Objectives](
	[ObjectiveName] [nvarchar](100) NOT NULL,
	[ObjectiveCreated] [datetime2](7) NOT NULL,
	[Archived] [bit] NOT NULL,
 CONSTRAINT [PK_Objectives] PRIMARY KEY CLUSTERED 
(
	[ObjectiveName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


