USE [Solution]
GO

/****** Object:  Table [dbo].[Productos]    Script Date: 26/07/2024 20:31:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Productos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Modelo] [nvarchar](100) NOT NULL,
	[IdMarca] [bigint] NOT NULL,
	[IdCategoria] [bigint] NOT NULL,
	[Descripcion] [nvarchar](800) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Talle] [int] NOT NULL,
	[IdGenero] [bigint] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[FechaPrimerModificacion] [datetime2](7) NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NOT NULL,
	[FechaEliminacion] [datetime2](7) NOT NULL,
	[Estado] [bit] NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Productos] ADD  DEFAULT (N'') FOR [ImageUrl]
GO

ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Categorias_IdCategoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Categorias_IdCategoria]
GO

ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Generos_IdGenero] FOREIGN KEY([IdGenero])
REFERENCES [dbo].[Generos] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Generos_IdGenero]
GO

ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Marcas_IdMarca] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marcas] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Marcas_IdMarca]
GO


