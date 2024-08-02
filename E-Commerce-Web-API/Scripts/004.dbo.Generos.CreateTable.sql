USE [Solution]
GO

/****** Object:  Table [dbo].[Generos]    Script Date: 26/07/2024 20:29:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Generos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[Abreviacion] [nvarchar](4) NOT NULL,
	[Sigla] [nvarchar](1) NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[FechaPrimerModificacion] [datetime2](7) NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NOT NULL,
	[FechaEliminacion] [datetime2](7) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Generos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


