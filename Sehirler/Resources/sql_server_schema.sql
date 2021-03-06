/****** Object:  Table [dbo].[sehiril]    Script Date: 4.07.2017 12:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sehiril](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SehirAd] [varchar](20) NULL,
 CONSTRAINT [PK_sehiril] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sehirilce]    Script Date: 4.07.2017 12:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sehirilce](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SehirID] [int] NOT NULL,
	[IlceAd] [varchar](30) NULL,
 CONSTRAINT [PK_sehirilce] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sehirmahalle]    Script Date: 4.07.2017 12:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sehirmahalle](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SemtID] [int] NOT NULL,
	[MahalleAd] [varchar](100) NULL,
	[PostaKodu] [int] NULL,
 CONSTRAINT [PK_sehirmahalle] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sehirsemt]    Script Date: 4.07.2017 12:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sehirsemt](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IlceID] [int] NOT NULL,
	[SemtAd] [varchar](50) NULL,
 CONSTRAINT [PK_sehirsemt] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[sehirilce]  WITH CHECK ADD  CONSTRAINT [FK_sehirilce_sehiril] FOREIGN KEY([SehirID])
REFERENCES [dbo].[sehiril] ([ID])
GO
ALTER TABLE [dbo].[sehirilce] CHECK CONSTRAINT [FK_sehirilce_sehiril]
GO
ALTER TABLE [dbo].[sehirmahalle]  WITH CHECK ADD  CONSTRAINT [FK_sehirmahalle_sehirsemt] FOREIGN KEY([SemtID])
REFERENCES [dbo].[sehirsemt] ([ID])
GO
ALTER TABLE [dbo].[sehirmahalle] CHECK CONSTRAINT [FK_sehirmahalle_sehirsemt]
GO
ALTER TABLE [dbo].[sehirsemt]  WITH CHECK ADD  CONSTRAINT [FK_sehirsemt_sehirilce] FOREIGN KEY([IlceID])
REFERENCES [dbo].[sehirilce] ([ID])
GO
ALTER TABLE [dbo].[sehirsemt] CHECK CONSTRAINT [FK_sehirsemt_sehirilce]
GO
