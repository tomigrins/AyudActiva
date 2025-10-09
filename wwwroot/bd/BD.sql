USE [master]
GO
/****** Object:  Database [AyudActivaDB]    Script Date: 6/10/2025 14:29:35 ******/
CREATE DATABASE [AyudActivaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AyudActivaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\AyudActivaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AyudActivaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\AyudActivaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AyudActivaDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AyudActivaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AyudActivaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AyudActivaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AyudActivaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AyudActivaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AyudActivaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AyudActivaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AyudActivaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AyudActivaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AyudActivaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AyudActivaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AyudActivaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AyudActivaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AyudActivaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AyudActivaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AyudActivaDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AyudActivaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AyudActivaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AyudActivaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AyudActivaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AyudActivaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AyudActivaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AyudActivaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AyudActivaDB] SET RECOVERY FULL 
GO
ALTER DATABASE [AyudActivaDB] SET  MULTI_USER 
GO
ALTER DATABASE [AyudActivaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AyudActivaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AyudActivaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AyudActivaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AyudActivaDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AyudActivaDB', N'ON'
GO
ALTER DATABASE [AyudActivaDB] SET QUERY_STORE = OFF
GO
USE [AyudActivaDB]
GO
/****** Object:  User [alumno]    Script Date: 6/10/2025 14:29:35 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Campanas]    Script Date: 6/10/2025 14:29:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campanas](
	[IDCampana] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[IDCategoria] [int] NOT NULL,
	[ubicacion] [varchar](100) NULL,
	[fechaInicio] [date] NULL,
	[fechaFin] [date] NULL,
	[horario] [time](7) NULL,
	[estado] [varchar](20) NULL,
	[imagenUrl] [varchar](255) NULL,
	[meta] [float] NULL,
 CONSTRAINT [PK__Campañas__3199C5125BC3E79D] PRIMARY KEY CLUSTERED 
(
	[IDCampana] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 6/10/2025 14:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[IDCategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donaciones]    Script Date: 6/10/2025 14:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donaciones](
	[IDDonacion] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[tipoDonacion] [varchar](50) NULL,
	[descripcion] [varchar](50) NULL,
	[fecha] [date] NULL,
	[estado] [varchar](20) NULL,
	[IDCampana] [int] NOT NULL,
	[cantidad] [float] NULL,
 CONSTRAINT [PK__Donacion__8BD41EA3BEB6BE72] PRIMARY KEY CLUSTERED 
(
	[IDDonacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonacionesMonetarias]    Script Date: 6/10/2025 14:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonacionesMonetarias](
	[IDDonacionMonetaria] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[monto] [decimal](10, 2) NOT NULL,
	[fecha] [date] NULL,
	[animosidad] [bit] NOT NULL,
	[IDCampana] [int] NOT NULL,
 CONSTRAINT [PK__Donacion__EC21699BF39890A0] PRIMARY KEY CLUSTERED 
(
	[IDDonacionMonetaria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eventos]    Script Date: 6/10/2025 14:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eventos](
	[IDEvento] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [text] NULL,
	[fecha] [date] NULL,
	[ubicacion] [varchar](100) NULL,
	[recordatorio] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 6/10/2025 14:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[email] [varchar](150) NOT NULL,
	[contrasena] [varchar](100) NOT NULL,
	[edad] [int] NOT NULL,
 CONSTRAINT [PK__Usuarios__5231116917FDB83F] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voluntariados]    Script Date: 6/10/2025 14:29:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voluntariados](
	[IDVoluntariado] [int] NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[IDCampaña] [int] NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_Voluntariados] PRIMARY KEY CLUSTERED 
(
	[IDVoluntariado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuarios__AB6E6164CF325352]    Script Date: 6/10/2025 14:29:36 ******/
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [UQ__Usuarios__AB6E6164CF325352] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DonacionesMonetarias] ADD  CONSTRAINT [DF__Donacione__fecha__44FF419A]  DEFAULT (getdate()) FOR [fecha]
GO
ALTER TABLE [dbo].[Campanas]  WITH CHECK ADD  CONSTRAINT [FK__Campañas__IDCate__38996AB5] FOREIGN KEY([IDCategoria])
REFERENCES [dbo].[Categorias] ([IDCategoria])
GO
ALTER TABLE [dbo].[Campanas] CHECK CONSTRAINT [FK__Campañas__IDCate__38996AB5]
GO
ALTER TABLE [dbo].[Donaciones]  WITH CHECK ADD  CONSTRAINT [FK__Donacione__IDUsu__3F466844] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuarios] ([IDUsuario])
GO
ALTER TABLE [dbo].[Donaciones] CHECK CONSTRAINT [FK__Donacione__IDUsu__3F466844]
GO
ALTER TABLE [dbo].[Donaciones]  WITH CHECK ADD  CONSTRAINT [FK_Donaciones_Campanas] FOREIGN KEY([IDCampana])
REFERENCES [dbo].[Campanas] ([IDCampana])
GO
ALTER TABLE [dbo].[Donaciones] CHECK CONSTRAINT [FK_Donaciones_Campanas]
GO
ALTER TABLE [dbo].[DonacionesMonetarias]  WITH CHECK ADD  CONSTRAINT [FK__Donacione__IDUsu__45F365D3] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuarios] ([IDUsuario])
GO
ALTER TABLE [dbo].[DonacionesMonetarias] CHECK CONSTRAINT [FK__Donacione__IDUsu__45F365D3]
GO
ALTER TABLE [dbo].[DonacionesMonetarias]  WITH CHECK ADD  CONSTRAINT [FK_DonacionesMonetarias_Campanas] FOREIGN KEY([IDCampana])
REFERENCES [dbo].[Campanas] ([IDCampana])
GO
ALTER TABLE [dbo].[DonacionesMonetarias] CHECK CONSTRAINT [FK_DonacionesMonetarias_Campanas]
GO
ALTER TABLE [dbo].[Voluntariados]  WITH CHECK ADD  CONSTRAINT [FK_Voluntariados_Campanas] FOREIGN KEY([IDCampaña])
REFERENCES [dbo].[Campanas] ([IDCampana])
GO
ALTER TABLE [dbo].[Voluntariados] CHECK CONSTRAINT [FK_Voluntariados_Campanas]
GO
ALTER TABLE [dbo].[Voluntariados]  WITH CHECK ADD  CONSTRAINT [FK_Voluntariados_Usuarios] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuarios] ([IDUsuario])
GO
ALTER TABLE [dbo].[Voluntariados] CHECK CONSTRAINT [FK_Voluntariados_Usuarios]
GO
ALTER TABLE [dbo].[DonacionesMonetarias]  WITH CHECK ADD  CONSTRAINT [CK__Donacione__monto__440B1D61] CHECK  (([monto]>(0)))
GO
ALTER TABLE [dbo].[DonacionesMonetarias] CHECK CONSTRAINT [CK__Donacione__monto__440B1D61]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [CK__Usuarios__edad__3C69FB99] CHECK  (([edad]>=(13)))
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [CK__Usuarios__edad__3C69FB99]
GO
USE [master]
GO
ALTER DATABASE [AyudActivaDB] SET  READ_WRITE 
GO