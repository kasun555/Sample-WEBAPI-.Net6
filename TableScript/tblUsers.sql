USE [EMP_CURD]
GO

/****** Object:  Table [dbo].[tblUsers]    Script Date: 5/23/2023 11:27:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblUsers](
	[iUser_Id] [int] IDENTITY(1,1) NOT NULL,
	[strFirst_Name] [nvarchar](128) NOT NULL,
	[strLast_Name] [nvarchar](128) NULL,
	[strEmail] [nvarchar](200) NOT NULL,
	[dtDateOfBirth] [datetime] NOT NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[iUser_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


