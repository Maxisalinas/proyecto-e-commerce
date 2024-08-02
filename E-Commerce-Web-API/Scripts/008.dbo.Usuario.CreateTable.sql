USE [Solution]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 26/07/2024 20:31:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
	[Apellido] [nvarchar](20) NOT NULL,
	[CorreoElectronico] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IdRol] [bigint] NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
	[FechaPrimerModificacion] [datetime2](7) NOT NULL,
	[FechaUltimaModificacion] [datetime2](7) NOT NULL,
	[FechaEliminacion] [datetime2](7) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_RolesLocales_IdRol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[RolesLocales] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_RolesLocales_IdRol]
GO


