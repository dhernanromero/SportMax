USE [SportMaxDB]
GO
/****** Object:  StoredProcedure [dbo].[Empleado_BuscarxDNI]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 02/06/2018
-- Description:	Listar Empleado	por DNI
-- =============================================
create PROCEDURE [dbo].[Empleado_BuscarxDNI] 
					@iDNI int

AS					   
BEGIN

	select IdEmpleado,a.IdUsuario,b.Usuario,Legajo,Nombre,Apellido,DNI,FechaNacimiento,Direccion,Telefono,Estado,Sueldo,
	c.IdTipoUsuario,c.Descripcion   
	from Empleado a
	inner join Usuario b on a.IdUsuario = b.IdUsuario
	inner join TipoUsuario c on b.IdTipoUsuario = c.IdTipoUsuario  
	where a.DNI = @iDNI

END		


GO
/****** Object:  StoredProcedure [dbo].[Empleado_BuscarxLegajo]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 02/06/2018
-- Description:	Listar Empleado	por Legajo
-- =============================================
create PROCEDURE [dbo].[Empleado_BuscarxLegajo] 
					@sLegajo varchar(20)

AS					   
BEGIN

	select IdEmpleado,a.IdUsuario,b.Usuario,Legajo,Nombre,Apellido,DNI,FechaNacimiento,Direccion,Telefono,Estado,Sueldo,
	c.IdTipoUsuario,c.Descripcion   
	from Empleado a
	inner join Usuario b on a.IdUsuario = b.IdUsuario
	inner join TipoUsuario c on b.IdTipoUsuario = c.IdTipoUsuario  
	where a.Legajo = @sLegajo

END		


GO
/****** Object:  StoredProcedure [dbo].[Empleado_Eliminar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 02/06/2018
-- Description:	Eliminar Empleado
-- =============================================
Create PROCEDURE [dbo].[Empleado_Eliminar] 
				@IdEmpleado int,
				@IdUsuario int,
				@Legajo varchar(29)
AS					   
BEGIN

	IF exists(select IdEmpleado from Empleado where IdEmpleado = @IdEmpleado)
		begin
			Update Empleado
			set Estado = 0
			where IdEmpleado = @IdEmpleado and IdUsuario = @IdUsuario and Legajo = @Legajo  

		end 
	else
		begin
			return 'Error al intentar modificar el empleado'
		end
END		


GO
/****** Object:  StoredProcedure [dbo].[Empleado_Insertar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 02/06/2018
-- Description:	Insertar Empleado
-- =============================================
CREATE PROCEDURE [dbo].[Empleado_Insertar] 
				@IdEmpleado int,
				@IdUsuario int,
				@Legajo varchar(29),
				@Nombre varchar(50),
				@Apellido varchar(50),
				@DNI int,
				@FechaNacimiento datetime,
				@Direccion varchar(50),
				@Telefono int,
				@Estado bit,
				@Sueldo	decimal(10,2) 
AS					   
BEGIN

	IF not exists(select IdEmpleado from Empleado where IdEmpleado = @IdEmpleado)
		begin
			insert into Empleado(IdEmpleado,IdUsuario,Legajo,Nombre,Apellido,DNI,FechaNacimiento,Direccion,Telefono,Estado,Sueldo )
			Values(@IdEmpleado,@IdUsuario, @Legajo ,@Nombre,@Apellido,@DNI,@FechaNacimiento,@Direccion,@Telefono,@Estado,@Sueldo)
		end 
	else
		begin
			return 'Error al intentar insertar'
		end
END		


GO
/****** Object:  StoredProcedure [dbo].[Empleado_Listar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 02/06/2018
-- Description:	Listar Empleado
-- =============================================
CREATE PROCEDURE [dbo].[Empleado_Listar] 

AS					   
BEGIN

	select IdEmpleado,a.IdUsuario,b.Usuario,Legajo,Nombre,Apellido,DNI,FechaNacimiento,Direccion,Telefono,Estado,Sueldo,
	c.IdTipoUsuario,c.Descripcion    
	from Empleado a
	inner join Usuario b on a.IdUsuario = b.IdUsuario
	inner join TipoUsuario c on b.IdTipoUsuario = c.IdTipoUsuario  
	where a.Estado = 1 

END		


GO
/****** Object:  StoredProcedure [dbo].[Empleado_Modificar ]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 02/06/2018
-- Description:	Update Empleado
-- =============================================
Create PROCEDURE [dbo].[Empleado_Modificar ] 
				@IdEmpleado int,
				@IdUsuario int,
				@Legajo varchar(29),
				@Nombre varchar(50),
				@Apellido varchar(50),
				@DNI int,
				@FechaNacimiento datetime,
				@Direccion varchar(50),
				@Telefono int,
				@Estado bit,
				@Sueldo	decimal(10,2) 
AS					   
BEGIN

	IF exists(select IdEmpleado from Empleado where IdEmpleado = @IdEmpleado)
		begin
			Update Empleado
			set Nombre = @Nombre,
				Apellido = @Apellido,
				DNI = @DNI,
				FechaNacimiento = @FechaNacimiento,
				Direccion = @Direccion,
				Telefono = @Telefono,
			    Estado = @Estado,
				Sueldo = @Sueldo
			where IdEmpleado = @IdEmpleado and IdUsuario = @IdUsuario and Legajo = @Legajo

		end 
	else
		begin
			return 'Error al intentar modificar el empleado'
		end
END		


GO
/****** Object:  StoredProcedure [dbo].[Empleado_ObtenerId]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 15/06/2018
-- Description:	Obtener Id Usuario
-- =============================================
CREATE PROCEDURE [dbo].[Empleado_ObtenerId] 
				
AS					   
BEGIN

	Select case when(Max(IdEmpleado)+1 is null) then 1 else Max(IdEmpleado)+1 end as idEmpleado
	from Empleado


END		


GO
/****** Object:  StoredProcedure [dbo].[Marca_Insertar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 10/05/2018
-- Description:	Insertar Tipo de Producto
-- =============================================
CREATE PROCEDURE [dbo].[Marca_Insertar] 
				@IdMarca int,
				@Descripcion varchar(50)
AS
BEGIN

	IF not exists(select * from Marca where IdMarca = @IdMarca)
		begin
			insert into Marca (IdMarca, Descripcion)
			Values(@IdMarca,@Descripcion)
		end 
	else
		begin
			return 'Error al intentar insertar'
		end
END		

GO
/****** Object:  StoredProcedure [dbo].[Marca_Listar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 10/05/2018
-- Description:	Insertar Producto
-- =============================================
Create PROCEDURE [dbo].[Marca_Listar] 

AS					   
BEGIN

	select IdMarca, Descripcion
	from Marca
	
END		

GO
/****** Object:  StoredProcedure [dbo].[Producto_BuscarxCodigo]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 10/05/2018
-- Description:	Insertar Producto
-- =============================================
CREATE PROCEDURE [dbo].[Producto_BuscarxCodigo] 
					@idProducto int

AS					   
BEGIN

	select a.IdProducto, a.IdTipoProducto, b.Descripcion as TipoProdDescrip,c.IdMarca, c.Descripcion as MarcaDescrip, a.Descripcion,a.Talle, Precio, Cantidad,a.Estado 
	from Producto a
	inner join TipoProducto b on a.IdTipoProducto = b.IdTipoProducto
	inner join Marca c on a.IdMarca =c.IdMarca 
	where IdProducto = @idProducto
	
END		

GO
/****** Object:  StoredProcedure [dbo].[Producto_BuscarxDescripcion]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 10/05/2018
-- Description:	Insertar Producto
-- =============================================
CREATE PROCEDURE [dbo].[Producto_BuscarxDescripcion] 
					@Descripcion varchar(100)

AS					   
BEGIN

	select a.IdProducto, a.IdTipoProducto, b.Descripcion as TipoProdDescrip,c.IdMarca ,c.Descripcion as MarcaDescrip, a.Descripcion,a.Talle, Precio, Cantidad,a.Estado 
	from Producto a
	inner join TipoProducto b on a.IdTipoProducto = b.IdTipoProducto
	inner join Marca c on a.IdMarca =c.IdMarca 
	where a.Descripcion like @Descripcion+'%'
	
END		

GO
/****** Object:  StoredProcedure [dbo].[Producto_Eliminar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 10/05/2018
-- Description:	Eliminar Producto de forma logica
-- =============================================
CREATE PROCEDURE [dbo].[Producto_Eliminar] 
				@IdProducto int
AS					   
BEGIN

	IF exists(select IdProducto from Producto where IdProducto = @IdProducto)
		begin
			Update Producto  set Estado = 0 where IdProducto = @IdProducto
		end 
	else
		begin
			return 'Error al intentar Eliminar el producto'
		end
END		

GO
/****** Object:  StoredProcedure [dbo].[Producto_Insertar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 10/05/2018
-- Description:	Insertar Producto
-- =============================================
CREATE PROCEDURE [dbo].[Producto_Insertar] 
				@IdProducto int,
				@IdTipoProducto int,
				@IdMarca int,
				@Descripcion varchar(50),
				@Talle varchar(50),
				@Precio money,
				@Cantidad int,
				@Estado bit
AS					   
BEGIN

	IF not exists(select * from Producto where IdProducto = @IdProducto)
		begin
			insert into Producto (IdProducto,IdTipoProducto, IdMarca,Descripcion,Talle,Precio,Cantidad,Estado)
			Values(@IdProducto,@IdTipoProducto, @IdMarca ,@Descripcion,@Talle,@Precio,@Cantidad,@Estado)
		end 
	else
		begin
			return 'Error al intentar insertar'
		end
END		

GO
/****** Object:  StoredProcedure [dbo].[Producto_Listar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 10/05/2018
-- Description:	Insertar Producto
-- =============================================
CREATE PROCEDURE [dbo].[Producto_Listar] 

AS					   
BEGIN

	select a.IdProducto, a.IdTipoProducto, b.Descripcion as TipoProdDescrip,c.IdMarca , c.Descripcion as MarcaDescrip, a.Descripcion,a.Talle, Precio, Cantidad,a.Estado 
	from Producto a
	inner join TipoProducto b on a.IdTipoProducto = b.IdTipoProducto
	inner join Marca c on a.IdMarca =c.IdMarca 
	where a.Estado = 1 
	
END		

GO
/****** Object:  StoredProcedure [dbo].[Producto_Modificar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 10/05/2018
-- Description:	Insertar Producto
-- =============================================
CREATE PROCEDURE [dbo].[Producto_Modificar] 
				@IdProducto int,
				@IdTipoProducto int,
				@IdMarca int,
				@Descripcion varchar(50),
				@Talle varchar(50),
				@Precio money,
				@Cantidad int
AS					   
BEGIN

	IF exists(select * from Producto where IdProducto = @IdProducto)
		begin
			update Producto 
			set IdTipoProducto = @IdTipoProducto,
		    IdMarca = @IdMarca,
			Descripcion = @Descripcion,
			Talle = @Talle,
			Precio = @Precio,
			Cantidad = @Cantidad
			where IdProducto = @IdProducto
		
		end 
	else
		begin
			return 'Error al intentar modificar producto'
		end
END		

GO
/****** Object:  StoredProcedure [dbo].[TipoProducto_Insertar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 10/05/2018
-- Description:	Insertar Tipo de Producto
-- =============================================
CREATE PROCEDURE [dbo].[TipoProducto_Insertar] 
				@IdTipoProducto int,
				@Descripcion varchar(50)
AS
BEGIN

	IF not exists(select * from TipoProducto where IdTipoProducto = @IdTipoProducto)
		begin
			insert into TipoProducto (IdTipoProducto, Descripcion)
			Values(@IdTipoProducto,@Descripcion)
		end 
	else
		begin
			return 'Error al intentar insertar'
		end
END		

GO
/****** Object:  StoredProcedure [dbo].[TipoProducto_Listar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 10/05/2018
-- Description:	Listar Producto
-- =============================================
CREATE PROCEDURE [dbo].[TipoProducto_Listar] 

AS					   
BEGIN

	select IdTipoProducto, Descripcion
	from TipoProducto
	
END		

GO
/****** Object:  StoredProcedure [dbo].[TipoUsuario_Listar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 08/06/2018
-- Description:	Listar TipoUsuario
-- =============================================
CREATE PROCEDURE [dbo].[TipoUsuario_Listar] 

AS					   
BEGIN

	select IdTipoUsuario, Descripcion, CodUsuario
	from TipoUsuario
	
END		

GO
/****** Object:  StoredProcedure [dbo].[Usuario_Autenticar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 17/06/2018
-- Description:	Autenticar Usuario
-- =============================================
CREATE PROCEDURE [dbo].[Usuario_Autenticar] 
				@Usuario varchar(25),
				@Pass varchar(50)

AS					   
BEGIN

	Select a.IdUsuario,a.Usuario, b.IdTipoUsuario,b.Descripcion,b.CodUsuario  
	from Usuario a
	inner join TipoUsuario b on a.IdTipoUsuario = b.IdTipoUsuario
	where a.Usuario = @Usuario and a.Password = @Pass 
	 

END		


GO
/****** Object:  StoredProcedure [dbo].[Usuario_Insertar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 02/06/2018
-- Description:	Insertar Usuario
-- =============================================
CREATE PROCEDURE [dbo].[Usuario_Insertar] 
				@Usuario varchar(25),
				@Pass varchar(50),
				@IdTipoUsuario int

AS					   
BEGIN
	 	IF not exists(select Usuario from Usuario where Usuario = @Usuario)
		begin
			insert into Usuario(Usuario,Password,IdTipoUsuario)
			values(@Usuario ,@Pass,@IdTipoUsuario)
		end
END		


GO
/****** Object:  StoredProcedure [dbo].[Usuario_Modificar]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 02/06/2018
-- Description:	Modificar Usuario
-- =============================================
Create PROCEDURE [dbo].[Usuario_Modificar] 
				@IdUsuario int,
				@Usuario varchar(25),
				@Pass varchar(50),
				@IdTipoUsuario int

AS					   
BEGIN
	 	IF exists(select @IdUsuario from Usuario where IdUsuario = @IdUsuario and Usuario = @Usuario)
		begin
			Update Usuario
			set usuario = @Usuario,
				IdTipoUsuario = @IdTipoUsuario,
				Password = @Pass
			where IdUsuario = @IdUsuario   
		end
END		


GO
/****** Object:  StoredProcedure [dbo].[Usuario_ObtenerId]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 15/06/2018
-- Description:	Obtener Id Usuario
-- =============================================
CREATE PROCEDURE [dbo].[Usuario_ObtenerId] 
				
AS					   
BEGIN

	Select case when(Max(IdUsuario)+1 is null) then 1 else Max(IdUsuario)+1 end as idUsuario
	from Usuario

END		


GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 21/06/2018 1:19:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Legajo] [varchar](20) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[DNI] [int] NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Estado] [int] NOT NULL,
	[Sueldo] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 21/06/2018 1:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marca](
	[IdMarca] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 21/06/2018 1:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] NOT NULL,
	[IdTipoProducto] [int] NOT NULL,
	[IdMarca] [int] NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Talle] [varchar](25) NOT NULL,
	[Precio] [money] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 21/06/2018 1:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedro] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [varchar](50) NOT NULL,
	[Cuil] [varchar](15) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 21/06/2018 1:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoProducto](
	[IdTipoProducto] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoProducto] PRIMARY KEY CLUSTERED 
(
	[IdTipoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 21/06/2018 1:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[IdTipoUsuario] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[CodUsuario] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TipoUsuario] PRIMARY KEY CLUSTERED 
(
	[IdTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 21/06/2018 1:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] NOT NULL,
	[Usuario] [varchar](25) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IdTipoUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Marca] ([IdMarca], [Descripcion]) VALUES (1, N'Adidas')
INSERT [dbo].[Marca] ([IdMarca], [Descripcion]) VALUES (2, N'Nike')
INSERT [dbo].[Marca] ([IdMarca], [Descripcion]) VALUES (3, N'Reebok')
INSERT [dbo].[Marca] ([IdMarca], [Descripcion]) VALUES (4, N'Puma')
INSERT [dbo].[Producto] ([IdProducto], [IdTipoProducto], [IdMarca], [Descripcion], [Talle], [Precio], [Cantidad], [Estado]) VALUES (100001, 3, 1, N'PantalonNeo', N'42', 15000.0000, 100, 1)
INSERT [dbo].[Producto] ([IdProducto], [IdTipoProducto], [IdMarca], [Descripcion], [Talle], [Precio], [Cantidad], [Estado]) VALUES (100002, 1, 1, N'Remera', N'XL', 280.0000, 40, 1)
INSERT [dbo].[Producto] ([IdProducto], [IdTipoProducto], [IdMarca], [Descripcion], [Talle], [Precio], [Cantidad], [Estado]) VALUES (100003, 1, 1, N'Remera News', N'L', 160.0000, 50, 1)
SET IDENTITY_INSERT [dbo].[Proveedor] ON 

INSERT [dbo].[Proveedor] ([IdProveedro], [RazonSocial], [Cuil], [Direccion], [Telefono], [Estado]) VALUES (1, N'Adidas', N'30-68514022-1', N'Cuyo 3532/3512, Martines, Buenos Aires', 42315487, 1)
INSERT [dbo].[Proveedor] ([IdProveedro], [RazonSocial], [Cuil], [Direccion], [Telefono], [Estado]) VALUES (2, N'Nike', N'30-65487454-1', N'Callao 2321, Buenos Aires', 42567899, 1)
INSERT [dbo].[Proveedor] ([IdProveedro], [RazonSocial], [Cuil], [Direccion], [Telefono], [Estado]) VALUES (3, N'Puma', N'30-45687998-1', N'Boedo 21321,Buenos Aires', 42546877, 1)
INSERT [dbo].[Proveedor] ([IdProveedro], [RazonSocial], [Cuil], [Direccion], [Telefono], [Estado]) VALUES (4, N'Reebok', N'30-45687894-1', N'Catamarca 123, Buenos Aries', 42654567, 1)
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (1, N'Remera')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (2, N'Pantalon Largo')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (3, N'Pantalon Corto')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (4, N'Zapatillas')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (5, N'Medias')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (6, N'Botines')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (7, N'Bolso Deportivo')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (8, N'Mochila Deportiva')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (9, N'Pelota')
INSERT [dbo].[TipoUsuario] ([IdTipoUsuario], [Descripcion], [CodUsuario]) VALUES (1, N'Administrador', N'ADMIN')
INSERT [dbo].[TipoUsuario] ([IdTipoUsuario], [Descripcion], [CodUsuario]) VALUES (2, N'Gerente', N'GEREN')
INSERT [dbo].[TipoUsuario] ([IdTipoUsuario], [Descripcion], [CodUsuario]) VALUES (3, N'Vendedor', N'VENDE')
INSERT [dbo].[TipoUsuario] ([IdTipoUsuario], [Descripcion], [CodUsuario]) VALUES (4, N'Administrador de Stock', N'STOCK')
INSERT [dbo].[TipoUsuario] ([IdTipoUsuario], [Descripcion], [CodUsuario]) VALUES (5, N'Administrador de Sistema', N'SISTE')
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Usuario]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Marca] FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marca] ([IdMarca])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Marca]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_TipoProducto] FOREIGN KEY([IdTipoProducto])
REFERENCES [dbo].[TipoProducto] ([IdTipoProducto])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_TipoProducto]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY([IdTipoUsuario])
REFERENCES [dbo].[TipoUsuario] ([IdTipoUsuario])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TipoUsuario]
GO
