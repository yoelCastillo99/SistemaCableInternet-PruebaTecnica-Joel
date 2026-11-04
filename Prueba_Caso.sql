USE [Prueba_Caso]
GO
/****** Object:  Table [dbo].[Alerta]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alerta](
	[AlertaId] [int] IDENTITY(1,1) NOT NULL,
	[ContratoId] [int] NOT NULL,
	[Tipo] [varchar](15) NOT NULL,
	[FechaProgramada] [datetime2](0) NOT NULL,
	[Estado] [varchar](12) NOT NULL,
	[Mensaje] [nvarchar](500) NULL,
 CONSTRAINT [PK_Alerta] PRIMARY KEY CLUSTERED 
(
	[AlertaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AplicacionPago]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AplicacionPago](
	[AplicacionPagoId] [int] IDENTITY(1,1) NOT NULL,
	[PagoId] [int] NOT NULL,
	[FacturaId] [int] NOT NULL,
	[ImporteAplicado] [decimal](12, 2) NOT NULL,
	[FechaAplicacion] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_AplicacionPago] PRIMARY KEY CLUSTERED 
(
	[AplicacionPagoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[FechaAlta] [date] NOT NULL,
	[Direccion] [nvarchar](250) NOT NULL,
	[Correo] [nvarchar](254) NULL,
	[Telefono] [varchar](30) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contrato]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contrato](
	[ContratoId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[FechaInicio] [date] NOT NULL,
	[FechaFin] [date] NULL,
	[DiaPago] [tinyint] NOT NULL,
	[Estado] [varchar](12) NOT NULL,
 CONSTRAINT [PK_Contrato] PRIMARY KEY CLUSTERED 
(
	[ContratoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContratoServicio]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContratoServicio](
	[ContratoServicioId] [int] IDENTITY(1,1) NOT NULL,
	[ContratoId] [int] NOT NULL,
	[PlanId] [int] NOT NULL,
	[ServicioId] [int] NOT NULL,
	[DireccionId] [int] NOT NULL,
	[TarifaId] [int] NOT NULL,
	[PrecioPactado] [decimal](12, 2) NOT NULL,
	[VelocidadActualMbps] [smallint] NULL,
	[FechaAlta] [date] NOT NULL,
	[FechaBaja] [date] NULL,
	[Estado] [varchar](12) NOT NULL,
 CONSTRAINT [PK_ContratoServicio] PRIMARY KEY CLUSTERED 
(
	[ContratoServicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Descuento]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Descuento](
	[DescuentoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Tipo] [varchar](15) NOT NULL,
	[Valor] [decimal](12, 4) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Descuento] PRIMARY KEY CLUSTERED 
(
	[DescuentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DireccionInstalacion]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DireccionInstalacion](
	[DireccionId] [int] IDENTITY(1,1) NOT NULL,
	[ContratoId] [int] NOT NULL,
	[ZonaId] [int] NOT NULL,
	[Direccion] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[DireccionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventoSuspension]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventoSuspension](
	[EventoSuspensionId] [int] IDENTITY(1,1) NOT NULL,
	[ContratoId] [int] NOT NULL,
	[FechaSuspension] [date] NOT NULL,
	[Motivo] [nvarchar](300) NOT NULL,
	[FechaReactivacion] [date] NULL,
 CONSTRAINT [PK_Suspension] PRIMARY KEY CLUSTERED 
(
	[EventoSuspensionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[FacturaId] [int] IDENTITY(1,1) NOT NULL,
	[ContratoId] [int] NOT NULL,
	[Serie] [varchar](10) NOT NULL,
	[Numero] [int] NOT NULL,
	[Periodo] [date] NOT NULL,
	[FechaEmision] [date] NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
	[Subtotal] [decimal](12, 2) NOT NULL,
	[ImporteDescuento] [decimal](12, 2) NOT NULL,
	[Total] [decimal](12, 2) NOT NULL,
	[Estado] [varchar](10) NOT NULL,
	[Suspendido] [bit] NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[FacturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaDetalle]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaDetalle](
	[FacturaDetalleId] [int] IDENTITY(1,1) NOT NULL,
	[FacturaId] [int] NOT NULL,
	[ContratoId] [int] NOT NULL,
	[ContratoServicioId] [int] NOT NULL,
	[ReglaId] [int] NULL,
	[Concepto] [nvarchar](200) NOT NULL,
	[Cantidad] [smallint] NOT NULL,
	[PrecioMensual] [decimal](12, 2) NOT NULL,
	[PorcentajeAplicado] [decimal](7, 4) NOT NULL,
	[ImporteDescuento] [decimal](12, 2) NOT NULL,
	[Subtotal] [decimal](12, 2) NOT NULL,
	[Total] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_FacturaDetalle] PRIMARY KEY CLUSTERED 
(
	[FacturaDetalleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistoricoVelocidad]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoricoVelocidad](
	[HistoricoVelocidadId] [int] IDENTITY(1,1) NOT NULL,
	[ContratoServicioId] [int] NOT NULL,
	[FechaCambio] [date] NOT NULL,
	[VelocidadAnterior] [smallint] NOT NULL,
	[VelocidadNueva] [smallint] NOT NULL,
	[Motivo] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_HistoricoVelocidad] PRIMARY KEY CLUSTERED 
(
	[HistoricoVelocidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[PagoId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[FechaPago] [date] NOT NULL,
	[ImporteTotal] [decimal](12, 2) NOT NULL,
	[FormaPago] [varchar](20) NOT NULL,
	[ReferenciaOperacion] [varchar](80) NULL,
	[Estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[PagoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plan]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plan](
	[PlanId] [int] IDENTITY(1,1) NOT NULL,
	[ServicioId] [int] NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[VelocidadMbps] [smallint] NULL,
	[Canales] [smallint] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Plan] PRIMARY KEY CLUSTERED 
(
	[PlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReglaDescuento]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReglaDescuento](
	[ReglaId] [int] IDENTITY(1,1) NOT NULL,
	[DescuentoId] [int] NOT NULL,
	[Condicion] [nvarchar](500) NOT NULL,
	[CantidadMinServicios] [tinyint] NOT NULL,
	[Prioridad] [int] NOT NULL,
	[VigenciaDesde] [date] NOT NULL,
	[VigenciaHasta] [date] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Regla] PRIMARY KEY CLUSTERED 
(
	[ReglaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[ServicioId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](150) NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[ServicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarifaVigente]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarifaVigente](
	[TarifaId] [int] IDENTITY(1,1) NOT NULL,
	[PlanId] [int] NOT NULL,
	[ZonaId] [int] NOT NULL,
	[PrecioMensual] [decimal](12, 2) NOT NULL,
	[VigenciaDesde] [date] NOT NULL,
	[VigenciaHasta] [date] NULL,
 CONSTRAINT [PK_Tarifa] PRIMARY KEY CLUSTERED 
(
	[TarifaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zona]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zona](
	[ZonaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Zona] PRIMARY KEY CLUSTERED 
(
	[ZonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ClienteId], [Codigo], [Nombre], [FechaAlta], [Direccion], [Correo], [Telefono], [Activo]) VALUES (1, N'CLI-0001', N'Carlos Alberto Ramirez', CAST(N'2025-01-15' AS Date), N'Zona 1, Guatemala', N'carlos.ramirez@gmail.com', N'5551-1001', 1)
INSERT [dbo].[Cliente] ([ClienteId], [Codigo], [Nombre], [FechaAlta], [Direccion], [Correo], [Telefono], [Activo]) VALUES (2, N'CLI-0002', N'Maria Fernanda Lopez', CAST(N'2025-02-10' AS Date), N'Zona 3, Guatemala', N'maria.lopez@gmail.com', N'5551-1002', 1)
INSERT [dbo].[Cliente] ([ClienteId], [Codigo], [Nombre], [FechaAlta], [Direccion], [Correo], [Telefono], [Activo]) VALUES (3, N'CLI-0003', N'Jose Manuel Castillo', CAST(N'2025-03-05' AS Date), N'Zona 7, Guatemala', N'jose.castillo@gmail.com', N'5551-1003', 1)
INSERT [dbo].[Cliente] ([ClienteId], [Codigo], [Nombre], [FechaAlta], [Direccion], [Correo], [Telefono], [Activo]) VALUES (4, N'CLI-0004', N'Ana Lucia Morales', CAST(N'2025-03-20' AS Date), N'Zona 11, Guatemala', N'ana.morales@gmail.com', N'5551-1004', 1)
INSERT [dbo].[Cliente] ([ClienteId], [Codigo], [Nombre], [FechaAlta], [Direccion], [Correo], [Telefono], [Activo]) VALUES (5, N'CLI-0005', N'Luis Fernando Perez', CAST(N'2025-04-12' AS Date), N'Zona 12, Guatemala', N'luis.perez@gmail.com', N'5551-1005', 1)
INSERT [dbo].[Cliente] ([ClienteId], [Codigo], [Nombre], [FechaAlta], [Direccion], [Correo], [Telefono], [Activo]) VALUES (6, N'CLI-0006', N'Sofia Alejandra Garcia', CAST(N'2025-05-08' AS Date), N'Mixco, Guatemala', N'sofia.garcia@gmail.com', N'5551-1006', 1)
INSERT [dbo].[Cliente] ([ClienteId], [Codigo], [Nombre], [FechaAlta], [Direccion], [Correo], [Telefono], [Activo]) VALUES (7, N'CLI-0007', N'Miguel Angel Mora', CAST(N'2025-06-18' AS Date), N'Zona 3, Guatemala', N'miguel.hernandez@gmail.com', N'5551-1007', 1)
INSERT [dbo].[Cliente] ([ClienteId], [Codigo], [Nombre], [FechaAlta], [Direccion], [Correo], [Telefono], [Activo]) VALUES (8, N'CLI-0008', N'Daniela Isabel Torres', CAST(N'2025-07-22' AS Date), N'San Miguel Petapa, Guatemala', N'daniela.torres@gmail.com', N'5551-1008', 0)
INSERT [dbo].[Cliente] ([ClienteId], [Codigo], [Nombre], [FechaAlta], [Direccion], [Correo], [Telefono], [Activo]) VALUES (9, N'CLI-0009', N'Roberto Carlos Mendoza', CAST(N'2025-08-14' AS Date), N'Zona 18, Guatemala', N'roberto.mendoza@gmail.com', N'5551-1009', 0)
INSERT [dbo].[Cliente] ([ClienteId], [Codigo], [Nombre], [FechaAlta], [Direccion], [Correo], [Telefono], [Activo]) VALUES (10, N'CLI-0010', N'Gabriela Sofia Flores', CAST(N'2025-09-30' AS Date), N'Carretera a El Salvador, Guatemala', N'gabriela.flores@gmail.com', N'5551-1010', 0)
INSERT [dbo].[Cliente] ([ClienteId], [Codigo], [Nombre], [FechaAlta], [Direccion], [Correo], [Telefono], [Activo]) VALUES (11, N'CLI-0011', N'José Eduardo Martines Caballeros', CAST(N'2026-11-02' AS Date), N'24 calle 10-20 Zona 8 Guatemala', N'joseedu@gmail.com', N'6633-1144', 1)
INSERT [dbo].[Cliente] ([ClienteId], [Codigo], [Nombre], [FechaAlta], [Direccion], [Correo], [Telefono], [Activo]) VALUES (12, N'CLI-0012', N'Eduardo José Bonilla Santos', CAST(N'2026-11-02' AS Date), N'Zona 11 Ciudad Capital', N'edujose@gmail.com', N'8877-2012', 1)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Contrato] ON 

INSERT [dbo].[Contrato] ([ContratoId], [ClienteId], [FechaInicio], [FechaFin], [DiaPago], [Estado]) VALUES (1, 1, CAST(N'2026-10-03' AS Date), NULL, 10, N'Activo')
INSERT [dbo].[Contrato] ([ContratoId], [ClienteId], [FechaInicio], [FechaFin], [DiaPago], [Estado]) VALUES (2, 2, CAST(N'2026-09-03' AS Date), NULL, 15, N'Activo')
INSERT [dbo].[Contrato] ([ContratoId], [ClienteId], [FechaInicio], [FechaFin], [DiaPago], [Estado]) VALUES (3, 3, CAST(N'2026-08-04' AS Date), NULL, 20, N'Activo')
INSERT [dbo].[Contrato] ([ContratoId], [ClienteId], [FechaInicio], [FechaFin], [DiaPago], [Estado]) VALUES (4, 4, CAST(N'2026-07-05' AS Date), NULL, 25, N'Activo')
INSERT [dbo].[Contrato] ([ContratoId], [ClienteId], [FechaInicio], [FechaFin], [DiaPago], [Estado]) VALUES (5, 5, CAST(N'2026-06-05' AS Date), NULL, 30, N'Activo')
INSERT [dbo].[Contrato] ([ContratoId], [ClienteId], [FechaInicio], [FechaFin], [DiaPago], [Estado]) VALUES (6, 12, CAST(N'2026-11-02' AS Date), NULL, 15, N'Activo')
INSERT [dbo].[Contrato] ([ContratoId], [ClienteId], [FechaInicio], [FechaFin], [DiaPago], [Estado]) VALUES (7, 7, CAST(N'2026-11-03' AS Date), NULL, 20, N'Activo')
SET IDENTITY_INSERT [dbo].[Contrato] OFF
GO
SET IDENTITY_INSERT [dbo].[ContratoServicio] ON 

INSERT [dbo].[ContratoServicio] ([ContratoServicioId], [ContratoId], [PlanId], [ServicioId], [DireccionId], [TarifaId], [PrecioPactado], [VelocidadActualMbps], [FechaAlta], [FechaBaja], [Estado]) VALUES (1, 1, 1, 1, 1, 5, CAST(175.00 AS Decimal(12, 2)), 20, CAST(N'2026-11-03' AS Date), NULL, N'Activo')
INSERT [dbo].[ContratoServicio] ([ContratoServicioId], [ContratoId], [PlanId], [ServicioId], [DireccionId], [TarifaId], [PrecioPactado], [VelocidadActualMbps], [FechaAlta], [FechaBaja], [Estado]) VALUES (2, 6, 2, 1, 4, 2, CAST(250.00 AS Decimal(12, 2)), 50, CAST(N'2026-11-03' AS Date), NULL, N'Activo')
SET IDENTITY_INSERT [dbo].[ContratoServicio] OFF
GO
SET IDENTITY_INSERT [dbo].[DireccionInstalacion] ON 

INSERT [dbo].[DireccionInstalacion] ([DireccionId], [ContratoId], [ZonaId], [Direccion]) VALUES (1, 1, 6, N'20 Avenida 5ta calle 5-90')
INSERT [dbo].[DireccionInstalacion] ([DireccionId], [ContratoId], [ZonaId], [Direccion]) VALUES (2, 3, 2, N'8va calle 10-9')
INSERT [dbo].[DireccionInstalacion] ([DireccionId], [ContratoId], [ZonaId], [Direccion]) VALUES (3, 7, 2, N'30 calle 45-5')
INSERT [dbo].[DireccionInstalacion] ([DireccionId], [ContratoId], [ZonaId], [Direccion]) VALUES (4, 6, 1, N'9na calle 1-9')
SET IDENTITY_INSERT [dbo].[DireccionInstalacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Plan] ON 

INSERT [dbo].[Plan] ([PlanId], [ServicioId], [Nombre], [VelocidadMbps], [Canales], [Activo]) VALUES (1, 1, N'Básico', 20, NULL, 1)
INSERT [dbo].[Plan] ([PlanId], [ServicioId], [Nombre], [VelocidadMbps], [Canales], [Activo]) VALUES (2, 1, N'Intermedio', 50, NULL, 1)
INSERT [dbo].[Plan] ([PlanId], [ServicioId], [Nombre], [VelocidadMbps], [Canales], [Activo]) VALUES (3, 3, N'Básico', NULL, 80, 1)
INSERT [dbo].[Plan] ([PlanId], [ServicioId], [Nombre], [VelocidadMbps], [Canales], [Activo]) VALUES (4, 3, N'Familiar', NULL, 120, 1)
INSERT [dbo].[Plan] ([PlanId], [ServicioId], [Nombre], [VelocidadMbps], [Canales], [Activo]) VALUES (5, 4, N'Premium', NULL, 150, 1)
SET IDENTITY_INSERT [dbo].[Plan] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicio] ON 

INSERT [dbo].[Servicio] ([ServicioId], [Descripcion], [Activo]) VALUES (1, N'Internet Residencial', 1)
INSERT [dbo].[Servicio] ([ServicioId], [Descripcion], [Activo]) VALUES (2, N'Internet Empresarial', 1)
INSERT [dbo].[Servicio] ([ServicioId], [Descripcion], [Activo]) VALUES (3, N'Televisión por Cable', 1)
INSERT [dbo].[Servicio] ([ServicioId], [Descripcion], [Activo]) VALUES (4, N'Televisión Digital', 1)
INSERT [dbo].[Servicio] ([ServicioId], [Descripcion], [Activo]) VALUES (5, N'Telefonía Fija', 1)
INSERT [dbo].[Servicio] ([ServicioId], [Descripcion], [Activo]) VALUES (6, N'Internet Fibra Óptica', 1)
INSERT [dbo].[Servicio] ([ServicioId], [Descripcion], [Activo]) VALUES (7, N'Internet Inalámbrico', 1)
INSERT [dbo].[Servicio] ([ServicioId], [Descripcion], [Activo]) VALUES (8, N'Paquete Triple Play', 1)
INSERT [dbo].[Servicio] ([ServicioId], [Descripcion], [Activo]) VALUES (9, N'Televisión HD 2', 1)
INSERT [dbo].[Servicio] ([ServicioId], [Descripcion], [Activo]) VALUES (10, N'Servicios de Soporte Técnico', 1)
INSERT [dbo].[Servicio] ([ServicioId], [Descripcion], [Activo]) VALUES (11, N'Paquete Doble Play', 0)
INSERT [dbo].[Servicio] ([ServicioId], [Descripcion], [Activo]) VALUES (12, N'Internet por starlink', 1)
SET IDENTITY_INSERT [dbo].[Servicio] OFF
GO
SET IDENTITY_INSERT [dbo].[TarifaVigente] ON 

INSERT [dbo].[TarifaVigente] ([TarifaId], [PlanId], [ZonaId], [PrecioMensual], [VigenciaDesde], [VigenciaHasta]) VALUES (1, 1, 1, CAST(150.00 AS Decimal(12, 2)), CAST(N'2026-01-01' AS Date), NULL)
INSERT [dbo].[TarifaVigente] ([TarifaId], [PlanId], [ZonaId], [PrecioMensual], [VigenciaDesde], [VigenciaHasta]) VALUES (2, 2, 1, CAST(250.00 AS Decimal(12, 2)), CAST(N'2026-01-01' AS Date), NULL)
INSERT [dbo].[TarifaVigente] ([TarifaId], [PlanId], [ZonaId], [PrecioMensual], [VigenciaDesde], [VigenciaHasta]) VALUES (3, 3, 1, CAST(100.00 AS Decimal(12, 2)), CAST(N'2026-01-01' AS Date), NULL)
INSERT [dbo].[TarifaVigente] ([TarifaId], [PlanId], [ZonaId], [PrecioMensual], [VigenciaDesde], [VigenciaHasta]) VALUES (4, 4, 2, CAST(175.00 AS Decimal(12, 2)), CAST(N'2026-01-01' AS Date), NULL)
INSERT [dbo].[TarifaVigente] ([TarifaId], [PlanId], [ZonaId], [PrecioMensual], [VigenciaDesde], [VigenciaHasta]) VALUES (5, 1, 6, CAST(175.00 AS Decimal(12, 2)), CAST(N'2026-01-01' AS Date), NULL)
INSERT [dbo].[TarifaVigente] ([TarifaId], [PlanId], [ZonaId], [PrecioMensual], [VigenciaDesde], [VigenciaHasta]) VALUES (6, 5, 1, CAST(300.00 AS Decimal(12, 2)), CAST(N'2026-01-01' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[TarifaVigente] OFF
GO
SET IDENTITY_INSERT [dbo].[Zona] ON 

INSERT [dbo].[Zona] ([ZonaId], [Nombre], [Activo]) VALUES (1, N'Zona 1', 1)
INSERT [dbo].[Zona] ([ZonaId], [Nombre], [Activo]) VALUES (2, N'Zona 2', 1)
INSERT [dbo].[Zona] ([ZonaId], [Nombre], [Activo]) VALUES (4, N'Zona 3', 0)
INSERT [dbo].[Zona] ([ZonaId], [Nombre], [Activo]) VALUES (5, N'Zona 4', 0)
INSERT [dbo].[Zona] ([ZonaId], [Nombre], [Activo]) VALUES (6, N'Zona 5', 1)
SET IDENTITY_INSERT [dbo].[Zona] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Cliente_Codigo]    Script Date: 3/11/2026 22:54:40 ******/
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [UQ_Cliente_Codigo] UNIQUE NONCLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Plan_PlanServicio]    Script Date: 3/11/2026 22:54:40 ******/
ALTER TABLE [dbo].[Plan] ADD  CONSTRAINT [UQ_Plan_PlanServicio] UNIQUE NONCLUSTERED 
(
	[PlanId] ASC,
	[ServicioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF_Cliente_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Servicio] ADD  CONSTRAINT [DF_Servicio_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Alerta]  WITH CHECK ADD  CONSTRAINT [FK_Alerta_Contrato] FOREIGN KEY([ContratoId])
REFERENCES [dbo].[Contrato] ([ContratoId])
GO
ALTER TABLE [dbo].[Alerta] CHECK CONSTRAINT [FK_Alerta_Contrato]
GO
ALTER TABLE [dbo].[AplicacionPago]  WITH CHECK ADD  CONSTRAINT [FK_Aplicacion_Factura] FOREIGN KEY([FacturaId])
REFERENCES [dbo].[Factura] ([FacturaId])
GO
ALTER TABLE [dbo].[AplicacionPago] CHECK CONSTRAINT [FK_Aplicacion_Factura]
GO
ALTER TABLE [dbo].[AplicacionPago]  WITH CHECK ADD  CONSTRAINT [FK_Aplicacion_Pago] FOREIGN KEY([PagoId])
REFERENCES [dbo].[Pago] ([PagoId])
GO
ALTER TABLE [dbo].[AplicacionPago] CHECK CONSTRAINT [FK_Aplicacion_Pago]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Contrato_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_Contrato_Cliente]
GO
ALTER TABLE [dbo].[ContratoServicio]  WITH CHECK ADD  CONSTRAINT [FK_CS_Contrato] FOREIGN KEY([ContratoId])
REFERENCES [dbo].[Contrato] ([ContratoId])
GO
ALTER TABLE [dbo].[ContratoServicio] CHECK CONSTRAINT [FK_CS_Contrato]
GO
ALTER TABLE [dbo].[ContratoServicio]  WITH CHECK ADD  CONSTRAINT [FK_CS_DireccionContrato] FOREIGN KEY([DireccionId])
REFERENCES [dbo].[DireccionInstalacion] ([DireccionId])
GO
ALTER TABLE [dbo].[ContratoServicio] CHECK CONSTRAINT [FK_CS_DireccionContrato]
GO
ALTER TABLE [dbo].[ContratoServicio]  WITH CHECK ADD  CONSTRAINT [FK_CS_Plan_Servicio] FOREIGN KEY([PlanId], [ServicioId])
REFERENCES [dbo].[Plan] ([PlanId], [ServicioId])
GO
ALTER TABLE [dbo].[ContratoServicio] CHECK CONSTRAINT [FK_CS_Plan_Servicio]
GO
ALTER TABLE [dbo].[ContratoServicio]  WITH CHECK ADD  CONSTRAINT [FK_CS_PlanServicio] FOREIGN KEY([PlanId])
REFERENCES [dbo].[Plan] ([PlanId])
GO
ALTER TABLE [dbo].[ContratoServicio] CHECK CONSTRAINT [FK_CS_PlanServicio]
GO
ALTER TABLE [dbo].[ContratoServicio]  WITH CHECK ADD  CONSTRAINT [FK_CS_Servicio] FOREIGN KEY([ServicioId])
REFERENCES [dbo].[Servicio] ([ServicioId])
GO
ALTER TABLE [dbo].[ContratoServicio] CHECK CONSTRAINT [FK_CS_Servicio]
GO
ALTER TABLE [dbo].[ContratoServicio]  WITH CHECK ADD  CONSTRAINT [FK_CS_Tarifa] FOREIGN KEY([TarifaId])
REFERENCES [dbo].[TarifaVigente] ([TarifaId])
GO
ALTER TABLE [dbo].[ContratoServicio] CHECK CONSTRAINT [FK_CS_Tarifa]
GO
ALTER TABLE [dbo].[DireccionInstalacion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Contrato] FOREIGN KEY([ContratoId])
REFERENCES [dbo].[Contrato] ([ContratoId])
GO
ALTER TABLE [dbo].[DireccionInstalacion] CHECK CONSTRAINT [FK_Direccion_Contrato]
GO
ALTER TABLE [dbo].[DireccionInstalacion]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Zona] FOREIGN KEY([ZonaId])
REFERENCES [dbo].[Zona] ([ZonaId])
GO
ALTER TABLE [dbo].[DireccionInstalacion] CHECK CONSTRAINT [FK_Direccion_Zona]
GO
ALTER TABLE [dbo].[EventoSuspension]  WITH CHECK ADD  CONSTRAINT [FK_Suspension_Contrato] FOREIGN KEY([ContratoId])
REFERENCES [dbo].[Contrato] ([ContratoId])
GO
ALTER TABLE [dbo].[EventoSuspension] CHECK CONSTRAINT [FK_Suspension_Contrato]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Contrato] FOREIGN KEY([ContratoId])
REFERENCES [dbo].[Contrato] ([ContratoId])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Contrato]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_CS_Contrato_FD] FOREIGN KEY([ContratoId])
REFERENCES [dbo].[Contrato] ([ContratoId])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_CS_Contrato_FD]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_CSContrato] FOREIGN KEY([ContratoServicioId])
REFERENCES [dbo].[ContratoServicio] ([ContratoServicioId])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_Detalle_CSContrato]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_FacturaContrato] FOREIGN KEY([FacturaId])
REFERENCES [dbo].[Factura] ([FacturaId])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_Detalle_FacturaContrato]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Regla] FOREIGN KEY([ReglaId])
REFERENCES [dbo].[ReglaDescuento] ([ReglaId])
GO
ALTER TABLE [dbo].[FacturaDetalle] CHECK CONSTRAINT [FK_Detalle_Regla]
GO
ALTER TABLE [dbo].[HistoricoVelocidad]  WITH CHECK ADD  CONSTRAINT [FK_Historico_CS] FOREIGN KEY([ContratoServicioId])
REFERENCES [dbo].[ContratoServicio] ([ContratoServicioId])
GO
ALTER TABLE [dbo].[HistoricoVelocidad] CHECK CONSTRAINT [FK_Historico_CS]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_Pago_Cliente]
GO
ALTER TABLE [dbo].[Plan]  WITH CHECK ADD  CONSTRAINT [FK_Plan_Servicio] FOREIGN KEY([ServicioId])
REFERENCES [dbo].[Servicio] ([ServicioId])
GO
ALTER TABLE [dbo].[Plan] CHECK CONSTRAINT [FK_Plan_Servicio]
GO
ALTER TABLE [dbo].[ReglaDescuento]  WITH CHECK ADD  CONSTRAINT [FK_Regla_Descuento] FOREIGN KEY([DescuentoId])
REFERENCES [dbo].[Descuento] ([DescuentoId])
GO
ALTER TABLE [dbo].[ReglaDescuento] CHECK CONSTRAINT [FK_Regla_Descuento]
GO
ALTER TABLE [dbo].[TarifaVigente]  WITH CHECK ADD  CONSTRAINT [FK_Tarifa_Plan] FOREIGN KEY([PlanId])
REFERENCES [dbo].[Plan] ([PlanId])
GO
ALTER TABLE [dbo].[TarifaVigente] CHECK CONSTRAINT [FK_Tarifa_Plan]
GO
ALTER TABLE [dbo].[TarifaVigente]  WITH CHECK ADD  CONSTRAINT [FK_Tarifa_Zona] FOREIGN KEY([ZonaId])
REFERENCES [dbo].[Zona] ([ZonaId])
GO
ALTER TABLE [dbo].[TarifaVigente] CHECK CONSTRAINT [FK_Tarifa_Zona]
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [CK_Contrato_Estado] CHECK  (([Estado]='Finalizado' OR [Estado]='Suspendido' OR [Estado]='Activo'))
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [CK_Contrato_Estado]
GO
ALTER TABLE [dbo].[TarifaVigente]  WITH CHECK ADD  CONSTRAINT [CK_Tarifa_Precio] CHECK  (([PrecioMensual]>=(0)))
GO
ALTER TABLE [dbo].[TarifaVigente] CHECK CONSTRAINT [CK_Tarifa_Precio]
GO
/****** Object:  StoredProcedure [dbo].[usp_Cliente_Actualizar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Cliente_Actualizar]
    @ClienteId INT,
    @Codigo VARCHAR(20),
    @Nombre NVARCHAR(150),
    @FechaAlta DATE,
    @Direccion NVARCHAR(250),
    @Correo NVARCHAR(254) = NULL,
    @Telefono VARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Cliente
        WHERE ClienteId = @ClienteId
    )
        THROW 50005, 'El cliente no existe.', 1;

    IF NULLIF(LTRIM(RTRIM(@Codigo)), '') IS NULL
        THROW 50006, 'El codigo es obligatorio.', 1;

    IF NULLIF(LTRIM(RTRIM(@Nombre)), '') IS NULL
        THROW 50007, 'El nombre es obligatorio.', 1;

    IF NULLIF(LTRIM(RTRIM(@Direccion)), '') IS NULL
        THROW 50008, 'La direccion es obligatoria.', 1;

    IF EXISTS (
        SELECT 1
        FROM dbo.Cliente
        WHERE Codigo = @Codigo
          AND ClienteId <> @ClienteId
    )
        THROW 50009, 'El codigo ya pertenece a otro cliente.', 1;

    UPDATE dbo.Cliente
    SET
        Codigo = @Codigo,
        Nombre = @Nombre,
        FechaAlta = @FechaAlta,
        Direccion = @Direccion,
        Correo = @Correo,
        Telefono = @Telefono
    WHERE ClienteId = @ClienteId;

    EXEC dbo.usp_Cliente_ObtenerPorId
        @ClienteId = @ClienteId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Cliente_CambiarEstado]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Cliente_CambiarEstado]
    @ClienteId INT,
    @Activo BIT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Cliente
        WHERE ClienteId = @ClienteId
    )
        THROW 50010, 'El cliente no existe.', 1;

    UPDATE dbo.Cliente
    SET Activo = @Activo
    WHERE ClienteId = @ClienteId;

    EXEC dbo.usp_Cliente_ObtenerPorId
        @ClienteId = @ClienteId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Cliente_Insertar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Cliente_Insertar]
    @Codigo VARCHAR(20),
    @Nombre NVARCHAR(150),
    @FechaAlta DATE,
    @Direccion NVARCHAR(250),
    @Correo NVARCHAR(254) = NULL,
    @Telefono VARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@Codigo)), '') IS NULL
        THROW 50001, 'El codigo es obligatorio.', 1;

    IF NULLIF(LTRIM(RTRIM(@Nombre)), '') IS NULL
        THROW 50002, 'El nombre es obligatorio.', 1;

    IF NULLIF(LTRIM(RTRIM(@Direccion)), '') IS NULL
        THROW 50003, 'La direccion es obligatoria.', 1;

    IF EXISTS (
        SELECT 1
        FROM dbo.Cliente
        WHERE Codigo = @Codigo
    )
        THROW 50004, 'El codigo ya existe.', 1;

    INSERT INTO dbo.Cliente
    (
        Codigo,
        Nombre,
        FechaAlta,
        Direccion,
        Correo,
        Telefono
    )
    VALUES
    (
        @Codigo,
        @Nombre,
        @FechaAlta,
        @Direccion,
        @Correo,
        @Telefono
    );

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS ClienteId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Cliente_Listar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Cliente_Listar]
    @Buscar NVARCHAR(150) = NULL,
    @Activo BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ClienteId,
        Codigo,
        Nombre,
        FechaAlta,
        Direccion,
        Correo,
        Telefono,
        Activo
    FROM dbo.Cliente
    WHERE
        (
            @Buscar IS NULL
            OR Codigo LIKE '%' + @Buscar + '%'
            OR Nombre LIKE '%' + @Buscar + '%'
            OR Correo LIKE '%' + @Buscar + '%'
        )
        AND (@Activo IS NULL OR Activo = @Activo)
    ORDER BY ClienteId DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Cliente_ObtenerPorId]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Cliente_ObtenerPorId]
    @ClienteId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ClienteId,
        Codigo,
        Nombre,
        FechaAlta,
        Direccion,
        Correo,
        Telefono,
        Activo
    FROM dbo.Cliente
    WHERE ClienteId = @ClienteId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Contrato_Actualizar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Contrato_Actualizar]
    @ContratoId INT,
    @ClienteId INT,
    @FechaInicio DATE,
    @FechaFin DATE = NULL,
    @DiaPago TINYINT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el contrato exista
    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Contrato
        WHERE ContratoId = @ContratoId
    )
    BEGIN
        THROW 50004, 'El contrato especificado no existe.', 1;
    END;

    -- Validar que el cliente exista
    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Cliente
        WHERE ClienteId = @ClienteId
    )
    BEGIN
        THROW 50005, 'El cliente especificado no existe.', 1;
    END;

    -- Validar el día de pago
    IF @DiaPago < 1 OR @DiaPago > 31
    BEGIN
        THROW 50006, 'El día de pago debe estar entre 1 y 31.', 1;
    END;

    -- Validar fechas
    IF @FechaFin IS NOT NULL AND @FechaFin < @FechaInicio
    BEGIN
        THROW 50007, 'La fecha de finalización no puede ser anterior a la fecha de inicio.', 1;
    END;

    -- Actualizar contrato
    UPDATE dbo.Contrato
    SET
        ClienteId = @ClienteId,
        FechaInicio = @FechaInicio,
        FechaFin = @FechaFin,
        DiaPago = @DiaPago
    WHERE ContratoId = @ContratoId;

    SELECT 'Contrato actualizado correctamente.' AS Mensaje;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Contrato_CambiarEstado]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Contrato_CambiarEstado]
    @ContratoId INT,
    @Estado VARCHAR(12)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el contrato exista
    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Contrato
        WHERE ContratoId = @ContratoId
    )
    BEGIN
        THROW 50008, 'El contrato especificado no existe.', 1;
    END;

    -- Validar el estado
    IF @Estado NOT IN ('Activo', 'Suspendido', 'Finalizado')
    BEGIN
        THROW 50009, 'El estado debe ser Activo, Suspendido o Finalizado.', 1;
    END;

    -- Actualizar estado
    UPDATE dbo.Contrato
    SET Estado = @Estado
    WHERE ContratoId = @ContratoId;

    SELECT 'Estado del contrato actualizado correctamente.' AS Mensaje;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Contrato_Insertar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Contrato_Insertar]
    @ClienteId INT,
    @FechaInicio DATE,
    @FechaFin DATE = NULL,
    @DiaPago TINYINT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el cliente exista
    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Cliente
        WHERE ClienteId = @ClienteId
    )
    BEGIN
        THROW 50001, 'El cliente especificado no existe.', 1;
    END;

    -- Validar el día de pago
    IF @DiaPago < 1 OR @DiaPago > 31
    BEGIN
        THROW 50002, 'El día de pago debe estar entre 1 y 31.', 1;
    END;

    -- Validar fechas
    IF @FechaFin IS NOT NULL AND @FechaFin < @FechaInicio
    BEGIN
        THROW 50003, 'La fecha de finalización no puede ser anterior a la fecha de inicio.', 1;
    END;

    -- Insertar contrato
    INSERT INTO dbo.Contrato
    (
        ClienteId,
        FechaInicio,
        FechaFin,
        DiaPago,
        Estado
    )
    VALUES
    (
        @ClienteId,
        @FechaInicio,
        @FechaFin,
        @DiaPago,
        'Activo'
    );

    -- Devolver el ID generado
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS ContratoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Contrato_Listar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Contrato_Listar]
    @Buscar NVARCHAR(100) = NULL,
    @Estado VARCHAR(12) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.ContratoId,
        c.ClienteId,
        cl.Codigo,
        cl.Nombre AS Cliente,
        c.FechaInicio,
        c.FechaFin,
        c.DiaPago,
        c.Estado
    FROM dbo.Contrato c
    INNER JOIN dbo.Cliente cl
        ON c.ClienteId = cl.ClienteId
    WHERE
        (
            @Buscar IS NULL
            OR cl.Nombre LIKE '%' + @Buscar + '%'
            OR cl.Codigo LIKE '%' + @Buscar + '%'
        )
        AND
        (
            @Estado IS NULL
            OR c.Estado = @Estado
        )
    ORDER BY c.ContratoId DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Contrato_ObtenerPorId]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Contrato_ObtenerPorId]
    @ContratoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.ContratoId,
        c.ClienteId,
        cl.Codigo,
        cl.Nombre AS Cliente,
        c.FechaInicio,
        c.FechaFin,
        c.DiaPago,
        c.Estado
    FROM dbo.Contrato c
    INNER JOIN dbo.Cliente cl
        ON c.ClienteId = cl.ClienteId
    WHERE c.ContratoId = @ContratoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ContratoServicio_Actualizar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_ContratoServicio_Actualizar]
    @ContratoServicioId INT,
    @ContratoId INT,
    @PlanId INT,
    @ServicioId INT,
    @DireccionId INT,
    @TarifaId INT,
    @FechaAlta DATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ZonaId INT;
    DECLARE @Precio DECIMAL(12,2);
    DECLARE @Velocidad SMALLINT;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.ContratoServicio
        WHERE ContratoServicioId = @ContratoServicioId
    )
        THROW 50007, 'La asignación no existe.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Contrato
        WHERE ContratoId = @ContratoId
          AND Estado = 'Activo'
    )
        THROW 50008, 'El contrato no existe o no está activo.', 1;

    SELECT @ZonaId = ZonaId
    FROM dbo.DireccionInstalacion
    WHERE DireccionId = @DireccionId
      AND ContratoId = @ContratoId;

    IF @ZonaId IS NULL
        THROW 50009, 'La dirección no pertenece al contrato indicado.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.[Plan] p
        INNER JOIN dbo.Servicio s
            ON p.ServicioId = s.ServicioId
        WHERE p.PlanId = @PlanId
          AND p.ServicioId = @ServicioId
          AND p.Activo = 1
          AND s.Activo = 1
    )
        THROW 50010, 'El plan o servicio no es válido.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Zona
        WHERE ZonaId = @ZonaId
          AND Activo = 1
    )
        THROW 50011, 'La zona está inactiva.', 1;

    SELECT @Precio = PrecioMensual
    FROM dbo.TarifaVigente
    WHERE TarifaId = @TarifaId
      AND PlanId = @PlanId
      AND ZonaId = @ZonaId
      AND VigenciaDesde <= @FechaAlta
      AND (VigenciaHasta IS NULL OR VigenciaHasta >= @FechaAlta);

    IF @Precio IS NULL
        THROW 50012, 'No existe una tarifa vigente para el plan y la zona.', 1;

    SELECT @Velocidad = VelocidadMbps
    FROM dbo.[Plan]
    WHERE PlanId = @PlanId;

    IF EXISTS (
        SELECT 1
        FROM dbo.ContratoServicio
        WHERE ContratoId = @ContratoId
          AND ServicioId = @ServicioId
          AND Estado = 'Activo'
          AND ContratoServicioId <> @ContratoServicioId
    )
        THROW 50013, 'El contrato ya tiene este servicio activo.', 1;

    UPDATE dbo.ContratoServicio
    SET
        ContratoId = @ContratoId,
        PlanId = @PlanId,
        ServicioId = @ServicioId,
        DireccionId = @DireccionId,
        TarifaId = @TarifaId,
        PrecioPactado = @Precio,
        VelocidadActualMbps = @Velocidad,
        FechaAlta = @FechaAlta
    WHERE ContratoServicioId = @ContratoServicioId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ContratoServicio_CambiarEstado]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_ContratoServicio_CambiarEstado]
    @ContratoServicioId INT,
    @Estado VARCHAR(12)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Estado NOT IN ('Activo', 'Suspendido', 'Finalizado')
        THROW 50014, 'El estado indicado no es válido.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.ContratoServicio
        WHERE ContratoServicioId = @ContratoServicioId
    )
        THROW 50015, 'El servicio contratado no existe.', 1;

    UPDATE dbo.ContratoServicio
    SET
        Estado = @Estado,
        FechaBaja = CASE
            WHEN @Estado = 'Finalizado' THEN CAST(GETDATE() AS DATE)
            WHEN @Estado = 'Activo' THEN NULL
            ELSE FechaBaja
        END
    WHERE ContratoServicioId = @ContratoServicioId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ContratoServicio_Insertar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_ContratoServicio_Insertar]
    @ContratoId INT,
    @PlanId INT,
    @ServicioId INT,
    @DireccionId INT,
    @TarifaId INT,
    @FechaAlta DATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ZonaId INT;
    DECLARE @Precio DECIMAL(12,2);
    DECLARE @Velocidad SMALLINT;

    -- Validar contrato
    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Contrato
        WHERE ContratoId = @ContratoId
          AND Estado = 'Activo'
    )
        THROW 50001, 'El contrato no existe o no está activo.', 1;

    -- Validar dirección
    SELECT @ZonaId = ZonaId
    FROM dbo.DireccionInstalacion
    WHERE DireccionId = @DireccionId
      AND ContratoId = @ContratoId;

    IF @ZonaId IS NULL
        THROW 50002, 'La dirección no pertenece al contrato indicado.', 1;

    -- Validar plan y servicio
    IF NOT EXISTS (
        SELECT 1
        FROM dbo.[Plan] p
        INNER JOIN dbo.Servicio s
            ON p.ServicioId = s.ServicioId
        WHERE p.PlanId = @PlanId
          AND p.ServicioId = @ServicioId
          AND p.Activo = 1
          AND s.Activo = 1
    )
        THROW 50003, 'El plan o servicio no existe, no coincide o está inactivo.', 1;

    -- Validar zona
    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Zona
        WHERE ZonaId = @ZonaId
          AND Activo = 1
    )
        THROW 50004, 'La zona de instalación está inactiva.', 1;

    -- Obtener tarifa vigente
    SELECT @Precio = PrecioMensual
    FROM dbo.TarifaVigente
    WHERE TarifaId = @TarifaId
      AND PlanId = @PlanId
      AND ZonaId = @ZonaId
      AND VigenciaDesde <= @FechaAlta
      AND (VigenciaHasta IS NULL OR VigenciaHasta >= @FechaAlta);

    IF @Precio IS NULL
        THROW 50005, 'No existe una tarifa vigente para el plan y la zona seleccionados.', 1;

    -- Obtener velocidad del plan
    SELECT @Velocidad = VelocidadMbps
    FROM dbo.[Plan]
    WHERE PlanId = @PlanId;

    -- Evitar duplicar un servicio activo del mismo tipo
    IF EXISTS (
        SELECT 1
        FROM dbo.ContratoServicio
        WHERE ContratoId = @ContratoId
          AND ServicioId = @ServicioId
          AND Estado = 'Activo'
    )
        THROW 50006, 'El contrato ya tiene este servicio activo.', 1;

    -- Registrar asignación
    INSERT INTO dbo.ContratoServicio
    (
        ContratoId,
        PlanId,
        ServicioId,
        DireccionId,
        TarifaId,
        PrecioPactado,
        VelocidadActualMbps,
        FechaAlta,
        FechaBaja,
        Estado
    )
    VALUES
    (
        @ContratoId,
        @PlanId,
        @ServicioId,
        @DireccionId,
        @TarifaId,
        @Precio,
        @Velocidad,
        @FechaAlta,
        NULL,
        'Activo'
    );

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS ContratoServicioId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ContratoServicio_Listar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_ContratoServicio_Listar]
    @ContratoId INT = NULL,
    @ClienteId INT = NULL,
    @Estado VARCHAR(12) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        cs.ContratoServicioId,
        cs.ContratoId,
        c.ClienteId,
        cl.Codigo AS CodigoCliente,
        cl.Nombre AS NombreCliente,
        cs.PlanId,
        p.Nombre AS NombrePlan,
        cs.ServicioId,
        s.Descripcion AS Servicio,
        cs.DireccionId,
        d.Direccion,
        z.ZonaId,
        z.Nombre AS Zona,
        cs.TarifaId,
        t.PrecioMensual,
        cs.PrecioPactado,
        cs.VelocidadActualMbps,
        cs.FechaAlta,
        cs.FechaBaja,
        cs.Estado
    FROM dbo.ContratoServicio cs
    INNER JOIN dbo.Contrato c
        ON cs.ContratoId = c.ContratoId
    INNER JOIN dbo.Cliente cl
        ON c.ClienteId = cl.ClienteId
    INNER JOIN dbo.[Plan] p
        ON cs.PlanId = p.PlanId
    INNER JOIN dbo.Servicio s
        ON cs.ServicioId = s.ServicioId
    INNER JOIN dbo.DireccionInstalacion d
        ON cs.DireccionId = d.DireccionId
    INNER JOIN dbo.Zona z
        ON d.ZonaId = z.ZonaId
    INNER JOIN dbo.TarifaVigente t
        ON cs.TarifaId = t.TarifaId
    WHERE
        (@ContratoId IS NULL OR cs.ContratoId = @ContratoId)
        AND (@ClienteId IS NULL OR c.ClienteId = @ClienteId)
        AND (@Estado IS NULL OR cs.Estado = @Estado)
    ORDER BY cs.ContratoServicioId DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ContratoServicio_ObtenerPorId]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_ContratoServicio_ObtenerPorId]
    @ContratoServicioId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        cs.ContratoServicioId,
        cs.ContratoId,
        c.ClienteId,
        cl.Codigo AS CodigoCliente,
        cl.Nombre AS NombreCliente,
        cs.PlanId,
        p.Nombre AS NombrePlan,
        cs.ServicioId,
        s.Descripcion AS Servicio,
        cs.DireccionId,
        d.Direccion,
        z.ZonaId,
        z.Nombre AS Zona,
        cs.TarifaId,
        t.PrecioMensual,
        cs.PrecioPactado,
        cs.VelocidadActualMbps,
        cs.FechaAlta,
        cs.FechaBaja,
        cs.Estado
    FROM dbo.ContratoServicio cs
    INNER JOIN dbo.Contrato c
        ON cs.ContratoId = c.ContratoId
    INNER JOIN dbo.Cliente cl
        ON c.ClienteId = cl.ClienteId
    INNER JOIN dbo.[Plan] p
        ON cs.PlanId = p.PlanId
    INNER JOIN dbo.Servicio s
        ON cs.ServicioId = s.ServicioId
    INNER JOIN dbo.DireccionInstalacion d
        ON cs.DireccionId = d.DireccionId
    INNER JOIN dbo.Zona z
        ON d.ZonaId = z.ZonaId
    INNER JOIN dbo.TarifaVigente t
        ON cs.TarifaId = t.TarifaId
    WHERE cs.ContratoServicioId = @ContratoServicioId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Direccion_Actualizar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Direccion_Actualizar]
    @DireccionId INT,
    @ContratoId INT,
    @ZonaId INT,
    @Direccion NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;

    SET @Direccion = LTRIM(RTRIM(@Direccion));

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.DireccionInstalacion
        WHERE DireccionId = @DireccionId
    )
        THROW 50004, 'La dirección de instalación no existe.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Contrato
        WHERE ContratoId = @ContratoId
          AND Estado = 'Activo'
    )
        THROW 50005, 'El contrato no existe o no está activo.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Zona
        WHERE ZonaId = @ZonaId
          AND Activo = 1
    )
        THROW 50006, 'La zona no existe o está inactiva.', 1;

    IF @Direccion IS NULL OR @Direccion = ''
        THROW 50007, 'La dirección es obligatoria.', 1;

    UPDATE dbo.DireccionInstalacion
    SET
        ContratoId = @ContratoId,
        ZonaId = @ZonaId,
        Direccion = @Direccion
    WHERE DireccionId = @DireccionId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Direccion_Insertar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Direccion_Insertar]
    @ContratoId INT,
    @ZonaId INT,
    @Direccion NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;

    SET @Direccion = LTRIM(RTRIM(@Direccion));

    IF @ContratoId <= 0 OR NOT EXISTS (
        SELECT 1
        FROM dbo.Contrato
        WHERE ContratoId = @ContratoId
          AND Estado = 'Activo'
    )
        THROW 50001, 'El contrato no existe o no está activo.', 1;

    IF @ZonaId <= 0 OR NOT EXISTS (
        SELECT 1
        FROM dbo.Zona
        WHERE ZonaId = @ZonaId
          AND Activo = 1
    )
        THROW 50002, 'La zona no existe o está inactiva.', 1;

    IF @Direccion IS NULL OR @Direccion = ''
        THROW 50003, 'La dirección es obligatoria.', 1;

    INSERT INTO dbo.DireccionInstalacion
    (
        ContratoId,
        ZonaId,
        Direccion
    )
    VALUES
    (
        @ContratoId,
        @ZonaId,
        @Direccion
    );

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS DireccionId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Direccion_Listar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Direccion_Listar]
    @Buscar NVARCHAR(500) = NULL,
    @ContratoId INT = NULL,
    @ZonaId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        d.DireccionId,
        d.ContratoId,
        d.ZonaId,
        d.Direccion,
        z.Nombre AS Zona,
        c.Estado AS EstadoContrato
    FROM dbo.DireccionInstalacion d
    INNER JOIN dbo.Zona z
        ON d.ZonaId = z.ZonaId
    INNER JOIN dbo.Contrato c
        ON d.ContratoId = c.ContratoId
    WHERE
        (@Buscar IS NULL OR d.Direccion LIKE '%' + @Buscar + '%')
        AND (@ContratoId IS NULL OR d.ContratoId = @ContratoId)
        AND (@ZonaId IS NULL OR d.ZonaId = @ZonaId)
    ORDER BY d.DireccionId DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Direccion_ObtenerPorId]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Direccion_ObtenerPorId]
    @DireccionId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        d.DireccionId,
        d.ContratoId,
        d.ZonaId,
        d.Direccion,
        z.Nombre AS Zona,
        c.Estado AS EstadoContrato
    FROM dbo.DireccionInstalacion d
    INNER JOIN dbo.Zona z
        ON d.ZonaId = z.ZonaId
    INNER JOIN dbo.Contrato c
        ON d.ContratoId = c.ContratoId
    WHERE d.DireccionId = @DireccionId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Plan_Actualizar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Plan_Actualizar]
    @PlanId INT,
    @ServicioId INT,
    @Nombre NVARCHAR(100),
    @VelocidadMbps INT = NULL,
    @Canales INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@Nombre)), '') IS NULL
        THROW 50015, 'El nombre del plan es obligatorio.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.[Plan]
        WHERE PlanId = @PlanId
    )
        THROW 50016, 'El plan no existe.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Servicio
        WHERE ServicioId = @ServicioId
          AND Activo = 1
    )
        THROW 50017, 'El servicio no existe o está inactivo.', 1;

    IF @VelocidadMbps IS NOT NULL AND @VelocidadMbps <= 0
        THROW 50018, 'La velocidad debe ser mayor que cero.', 1;

    IF @Canales IS NOT NULL AND @Canales <= 0
        THROW 50019, 'La cantidad de canales debe ser mayor que cero.', 1;

    UPDATE dbo.[Plan]
    SET
        ServicioId = @ServicioId,
        Nombre = LTRIM(RTRIM(@Nombre)),
        VelocidadMbps = @VelocidadMbps,
        Canales = @Canales
    WHERE PlanId = @PlanId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Plan_CambiarEstado]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Plan_CambiarEstado]
    @PlanId INT,
    @Activo BIT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.[Plan]
        WHERE PlanId = @PlanId
    )
        THROW 50020, 'El plan no existe.', 1;

    UPDATE dbo.[Plan]
    SET Activo = @Activo
    WHERE PlanId = @PlanId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Plan_Insertar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Plan_Insertar]
    @ServicioId INT,
    @Nombre NVARCHAR(100),
    @VelocidadMbps INT = NULL,
    @Canales INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@Nombre)), '') IS NULL
        THROW 50011, 'El nombre del plan es obligatorio.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Servicio
        WHERE ServicioId = @ServicioId
          AND Activo = 1
    )
        THROW 50012, 'El servicio no existe o está inactivo.', 1;

    IF @VelocidadMbps IS NOT NULL AND @VelocidadMbps <= 0
        THROW 50013, 'La velocidad debe ser mayor que cero.', 1;

    IF @Canales IS NOT NULL AND @Canales <= 0
        THROW 50014, 'La cantidad de canales debe ser mayor que cero.', 1;

    INSERT INTO dbo.[Plan]
    (
        ServicioId,
        Nombre,
        VelocidadMbps,
        Canales,
        Activo
    )
    VALUES
    (
        @ServicioId,
        LTRIM(RTRIM(@Nombre)),
        @VelocidadMbps,
        @Canales,
        1
    );

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS PlanId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Plan_Listar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Plan_Listar]
    @Buscar NVARCHAR(100) = NULL,
    @ServicioId INT = NULL,
    @Activo BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        P.PlanId,
        P.ServicioId,
        S.Descripcion AS Servicio,
        P.Nombre,
        P.VelocidadMbps,
        P.Canales,
        P.Activo
    FROM dbo.[Plan] P
    INNER JOIN dbo.Servicio S
        ON P.ServicioId = S.ServicioId
    WHERE
        (@Buscar IS NULL OR P.Nombre LIKE '%' + @Buscar + '%')
        AND (@ServicioId IS NULL OR P.ServicioId = @ServicioId)
        AND (@Activo IS NULL OR P.Activo = @Activo)
    ORDER BY P.PlanId DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Plan_ObtenerPorId]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Plan_ObtenerPorId]
    @PlanId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        PlanId,
        ServicioId,
        Nombre,
        VelocidadMbps,
        Canales,
        Activo
    FROM dbo.[Plan]
    WHERE PlanId = @PlanId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Servicio_Actualizar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Servicio_Actualizar]
    @ServicioId INT,
    @Descripcion NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@Descripcion)), '') IS NULL
    BEGIN
        THROW 50002, 'La descripción del servicio es obligatoria.', 1;
    END;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Servicio
        WHERE ServicioId = @ServicioId
    )
    BEGIN
        THROW 50003, 'El servicio no existe.', 1;
    END;

    UPDATE dbo.Servicio
    SET Descripcion = LTRIM(RTRIM(@Descripcion))
    WHERE ServicioId = @ServicioId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Servicio_CambiarEstado]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Servicio_CambiarEstado]
    @ServicioId INT,
    @Activo BIT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Servicio
        WHERE ServicioId = @ServicioId
    )
    BEGIN
        THROW 50004, 'El servicio no existe.', 1;
    END;

    UPDATE dbo.Servicio
    SET Activo = @Activo
    WHERE ServicioId = @ServicioId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Servicio_Insertar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Servicio_Insertar]
    @Descripcion NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF NULLIF(LTRIM(RTRIM(@Descripcion)), '') IS NULL
    BEGIN
        THROW 50001, 'La descripción del servicio es obligatoria.', 1;
    END;

    INSERT INTO dbo.Servicio (Descripcion, Activo)
    VALUES (LTRIM(RTRIM(@Descripcion)), 1);

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS ServicioId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Servicio_Listar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Servicio_Listar]
    @Buscar NVARCHAR(100) = NULL,
    @Activo BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ServicioId,
        Descripcion,
        Activo
    FROM dbo.Servicio
    WHERE
        (@Buscar IS NULL OR Descripcion LIKE '%' + @Buscar + '%')
        AND (@Activo IS NULL OR Activo = @Activo)
    ORDER BY ServicioId DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Servicio_ObtenerPorId]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Servicio_ObtenerPorId]
    @ServicioId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ServicioId,
        Descripcion,
        Activo
    FROM dbo.Servicio
    WHERE ServicioId = @ServicioId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Tarifa_Listar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Tarifa_Listar]
    @PlanId INT = NULL,
    @ZonaId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        t.TarifaId,
        t.PlanId,
        p.Nombre AS NombrePlan,
        t.ZonaId,
        z.Nombre AS NombreZona,
        t.PrecioMensual,
        t.VigenciaDesde,
        t.VigenciaHasta
    FROM dbo.TarifaVigente t
    INNER JOIN dbo.[Plan] p
        ON t.PlanId = p.PlanId
    INNER JOIN dbo.Zona z
        ON t.ZonaId = z.ZonaId
    WHERE
        (@PlanId IS NULL OR t.PlanId = @PlanId)
        AND (@ZonaId IS NULL OR t.ZonaId = @ZonaId)
        AND t.VigenciaDesde <= CAST(GETDATE() AS DATE)
        AND (
            t.VigenciaHasta IS NULL
            OR t.VigenciaHasta >= CAST(GETDATE() AS DATE)
        )
        AND z.Activo = 1
        AND p.Activo = 1
    ORDER BY p.Nombre, z.Nombre;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Tarifa_ObtenerPorId]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Tarifa_ObtenerPorId]
    @TarifaId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        t.TarifaId,
        t.PlanId,
        p.Nombre AS NombrePlan,
        t.ZonaId,
        z.Nombre AS NombreZona,
        t.PrecioMensual,
        t.VigenciaDesde,
        t.VigenciaHasta
    FROM dbo.TarifaVigente t
    INNER JOIN dbo.[Plan] p
        ON t.PlanId = p.PlanId
    INNER JOIN dbo.Zona z
        ON t.ZonaId = z.ZonaId
    WHERE t.TarifaId = @TarifaId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Zona_Actualizar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Zona_Actualizar]
    @ZonaId INT,
    @Nombre NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    SET @Nombre = LTRIM(RTRIM(@Nombre));

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Zona
        WHERE ZonaId = @ZonaId
    )
        THROW 50002, 'La zona no existe.', 1;

    IF @Nombre IS NULL OR @Nombre = ''
        THROW 50003, 'El nombre de la zona es obligatorio.', 1;

    UPDATE dbo.Zona
    SET Nombre = @Nombre
    WHERE ZonaId = @ZonaId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Zona_CambiarEstado]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Zona_CambiarEstado]
    @ZonaId INT,
    @Activo BIT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Zona
        WHERE ZonaId = @ZonaId
    )
        THROW 50004, 'La zona no existe.', 1;

    UPDATE dbo.Zona
    SET Activo = @Activo
    WHERE ZonaId = @ZonaId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Zona_Insertar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Zona_Insertar]
    @Nombre NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    SET @Nombre = LTRIM(RTRIM(@Nombre));

    IF @Nombre IS NULL OR @Nombre = ''
        THROW 50001, 'El nombre de la zona es obligatorio.', 1;

    INSERT INTO dbo.Zona (Nombre, Activo)
    VALUES (@Nombre, 1);

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS ZonaId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Zona_Listar]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Zona_Listar]
    @Buscar NVARCHAR(200) = NULL,
    @Activo BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ZonaId,
        Nombre,
        Activo
    FROM dbo.Zona
    WHERE
        (@Buscar IS NULL OR Nombre LIKE '%' + @Buscar + '%')
        AND (@Activo IS NULL OR Activo = @Activo)
    ORDER BY Nombre;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_Zona_ObtenerPorId]    Script Date: 3/11/2026 22:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_Zona_ObtenerPorId]
    @ZonaId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ZonaId,
        Nombre,
        Activo
    FROM dbo.Zona
    WHERE ZonaId = @ZonaId;
END;
GO
