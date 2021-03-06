USE [SportMaxDB]
GO
/****** Object:  StoredProcedure [dbo].[Cliente_BuscarxDNI]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 28/06/2018
-- Description:	Buscar Cliente por DNI
-- =============================================
cREATE PROCEDURE [dbo].[Cliente_BuscarxDNI] 
					@iDNI int

AS					   
BEGIN

	select IdCliente, Nombre, Apellido, DNI, FechaNacimiento, Direccion, Telefono, Tarjeta        
	from Cliente
	where DNI = @iDNI

END		


GO
/****** Object:  StoredProcedure [dbo].[Cliente_Insertar]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 28/06/2018
-- Description:	Insertar Cliente
-- =============================================
create PROCEDURE [dbo].[Cliente_Insertar] 
				@iIdCliente int,
				@sNombre varchar(50),
				@sApellido varchar(50),
				@iDNI int,
				@dFecha datetime,
				@sDireccion varchar(50),
				@iTelefono int,
				@iTarjeta bit 
AS					   
BEGIN

	IF not exists(select IdCliente from Cliente where IdCliente  = @iIdCliente)
		begin
			insert into Cliente(IdCliente,Nombre,Apellido,DNI,FechaNacimiento,Direccion,Telefono,Tarjeta)
			Values(@iIdCliente,@sNombre, @sApellido ,@iDNI,@dFecha,@sDireccion,@iTelefono,@iTarjeta)
		end 
	else
		begin
			return 'Error al intentar insertar'
		end
END		


GO
/****** Object:  StoredProcedure [dbo].[Cliente_ObtenerId]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 28/06/2018
-- Description:	Obtener Id Cliente
-- =============================================
Create PROCEDURE [dbo].[Cliente_ObtenerId] 
				
AS					   
BEGIN

	Select case when(Max(idCliente)+1 is null) then 1 else Max(idCliente)+1 end as idEmpleado
	from Cliente


END		


GO
/****** Object:  StoredProcedure [dbo].[DetalleVenta_Insertar]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 28/06/2018
-- Description:	Insertar Venta
-- =============================================
Create PROCEDURE [dbo].[DetalleVenta_Insertar] 
				@iIdDetalle int,
				@iIdVenta int,
				@iIdProducto int,
				@iCantidad int
AS					   
BEGIN

	IF not exists(select idDetalle from DetalleVemta where IdDetalle = @iIdDetalle)
		begin
			insert into DetalleVemta(IdDetalle, IdVenta, IdProducto, Cantidad)
			Values(@iIdDetalle,@iIdVenta, @iIdProducto ,@iCantidad)
		end 
	else
		begin
			return 'Error al intentar insertar'
		end
END		


GO
/****** Object:  StoredProcedure [dbo].[DetalleVenta_ObtenerId]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 28/06/2018
-- Description:	Obtener Id DetalleVenta
-- =============================================
CREATE PROCEDURE [dbo].[DetalleVenta_ObtenerId] 
				
AS					   
BEGIN

	Select case when(Max(IdDetalle)+1 is null) then 1 else Max(IdDetalle)+1 end as idDetalle
	from DetalleVemta 


END		


GO
/****** Object:  StoredProcedure [dbo].[Empleado_BuscarxDNI]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 02/06/2018
-- Description:	Listar Empleado	por DNI
-- =============================================
CREATE PROCEDURE [dbo].[Empleado_BuscarxDNI] 
					@iDNI int

AS					   
BEGIN

	select IdEmpleado,a.IdUsuario,b.Usuario,b.Password,Legajo,Nombre,Apellido,DNI,FechaNacimiento,Direccion,Telefono,Estado,Sueldo,
	c.IdTipoUsuario,c.Descripcion   
	from Empleado a
	inner join Usuario b on a.IdUsuario = b.IdUsuario
	inner join TipoUsuario c on b.IdTipoUsuario = c.IdTipoUsuario  
	where a.DNI = @iDNI

END		


GO
/****** Object:  StoredProcedure [dbo].[Empleado_BuscarxIdUsuario]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 02/06/2018
-- Description:	Listar Empleado	por IdUsuario
-- =============================================
CREATE PROCEDURE [dbo].[Empleado_BuscarxIdUsuario] 
					@iIdUsuario int

AS					   
BEGIN

	select IdEmpleado,a.IdUsuario,b.Usuario,b.Password,Legajo,Nombre,Apellido,DNI,FechaNacimiento,Direccion,Telefono,Estado,Sueldo,
	c.IdTipoUsuario,c.Descripcion   
	from Empleado a
	inner join Usuario b on a.IdUsuario = b.IdUsuario
	inner join TipoUsuario c on b.IdTipoUsuario = c.IdTipoUsuario  
	where b.IdUsuario = @iIdUsuario

END		


GO
/****** Object:  StoredProcedure [dbo].[Empleado_BuscarxLegajo]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 02/06/2018
-- Description:	Listar Empleado	por Legajo
-- =============================================
CREATE PROCEDURE [dbo].[Empleado_BuscarxLegajo] 
					@sLegajo varchar(20)

AS					   
BEGIN

	select IdEmpleado,a.IdUsuario,b.Usuario,b.Password,Legajo,Nombre,Apellido,DNI,FechaNacimiento,Direccion,Telefono,Estado,Sueldo,
	c.IdTipoUsuario,c.Descripcion   
	from Empleado a
	inner join Usuario b on a.IdUsuario = b.IdUsuario
	inner join TipoUsuario c on b.IdTipoUsuario = c.IdTipoUsuario  
	where a.Legajo = @sLegajo

END		


GO
/****** Object:  StoredProcedure [dbo].[Empleado_Eliminar]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[Empleado_Insertar]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[Empleado_Listar]    Script Date: 02/07/2018 8:27:40 ******/
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

	select IdEmpleado,a.IdUsuario,b.Usuario,b.Password,Legajo,Nombre,Apellido,DNI,FechaNacimiento,Direccion,Telefono,Estado,Sueldo,
	c.IdTipoUsuario,c.Descripcion    
	from Empleado a
	inner join Usuario b on a.IdUsuario = b.IdUsuario
	inner join TipoUsuario c on b.IdTipoUsuario = c.IdTipoUsuario  
	where a.Estado = 1 

END		


GO
/****** Object:  StoredProcedure [dbo].[Empleado_Modificar ]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[Empleado_ObtenerId]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[Marca_Insertar]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[Marca_Listar]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[Producto_BuscarxCodigo]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[Producto_BuscarxDescripcion]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[Producto_Eliminar]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[Producto_Insertar]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[Producto_Listar]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[Producto_Modificar]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoProducto_Insertar]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoProducto_Listar]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoUsuario_Listar]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[Usuario_Autenticar]    Script Date: 02/07/2018 8:27:40 ******/
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

	Select a.IdUsuario,a.Usuario,a.Password, b.IdTipoUsuario,b.Descripcion,b.CodUsuario  
	from Usuario a
	inner join TipoUsuario b on a.IdTipoUsuario = b.IdTipoUsuario
	where a.Usuario = @Usuario and a.Password = @Pass 
	 

END		


GO
/****** Object:  StoredProcedure [dbo].[Usuario_CambiarContraseñña]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 02/06/2018
-- Description:	Modificar Contraseña
-- =============================================
Create PROCEDURE [dbo].[Usuario_CambiarContraseñña] 
				@IdUsuario int,
				@Pass varchar(50)

AS					   
BEGIN
	 	IF exists(select @IdUsuario from Usuario where IdUsuario = @IdUsuario)
		begin
			Update Usuario
			set Password = @Pass 
			where IdUsuario = @IdUsuario   
		end
END		


GO
/****** Object:  StoredProcedure [dbo].[Usuario_Insertar]    Script Date: 02/07/2018 8:27:40 ******/
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
				@IdUsuario int,
				@Usuario varchar(25),
				@Pass varchar(50),
				@IdTipoUsuario int

AS					   
BEGIN
	 	IF not exists(select @IdUsuario from Usuario where IdUsuario = @IdUsuario and Usuario = @Usuario)
		begin
			insert into Usuario(IdUsuario,Usuario,Password,IdTipoUsuario)
			values(@IdUsuario,@Usuario ,@Pass,@IdTipoUsuario)
		end
END		


GO
/****** Object:  StoredProcedure [dbo].[Usuario_Modificar]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 02/06/2018
-- Description:	Modificar Usuario
-- =============================================
CREATE PROCEDURE [dbo].[Usuario_Modificar] 
				@IdUsuario int,
				@Usuario varchar(25),
				@IdTipoUsuario int

AS					   
BEGIN
	 	IF exists(select @IdUsuario from Usuario where IdUsuario = @IdUsuario and Usuario = @Usuario)
		begin
			Update Usuario
			set usuario = @Usuario,
				IdTipoUsuario = @IdTipoUsuario
			where IdUsuario = @IdUsuario   
		end
END		


GO
/****** Object:  StoredProcedure [dbo].[Usuario_ObtenerId]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  StoredProcedure [dbo].[Venta_Insertar]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 28/06/2018
-- Description:	Insertar Venta
-- =============================================
Create PROCEDURE [dbo].[Venta_Insertar] 
				@iIdVenta int,
				@iIdVendedor int,
				@iIdCliente int,
				@iIdFormaPago int,
				@dFechaVenta datetime,
				@dMontoTotal decimal(10,2)
AS					   
BEGIN

	IF not exists(select idVenta from Venta where idVenta = @iIdVenta)
		begin
			insert into Venta(IdVenta, IdVendedor, IdCliente, IdFormaPago, FechaVenta, MontoTotal)
			Values(@iIdVenta,@iIdVendedor, @iIdCliente ,@iIdFormaPago,@dFechaVenta,@dMontoTotal)
		end 
	else
		begin
			return 'Error al intentar insertar'
		end
END		


GO
/****** Object:  StoredProcedure [dbo].[Venta_ObtenerId]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Diego Romero
-- Create date: 28/06/2018
-- Description:	Obtener Id Venta
-- =============================================
CREATE PROCEDURE [dbo].[Venta_ObtenerId] 
				
AS					   
BEGIN

	Select case when(Max(IdVenta)+1 is null) then 1 else Max(IdVenta)+1 end as idVenta
	from Venta


END		


GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[DNI] [int] NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Tarjeta] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[IdCompra] [int] NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[IdFormaPago] [int] NOT NULL,
	[FechaCompra] [datetime] NOT NULL,
	[MontoTotal] [money] NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetalleCompra]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCompra](
	[IdDetalle] [int] NOT NULL,
	[IdCompra] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_DetalleCompra] PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DetalleVemta]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVemta](
	[IdDetalle] [int] NOT NULL,
	[IdVenta] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_DetalleVemta] PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  Table [dbo].[Marca]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  Table [dbo].[Producto]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  Table [dbo].[Proveedor]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 02/07/2018 8:27:40 ******/
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
/****** Object:  Table [dbo].[Venta]    Script Date: 02/07/2018 8:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] NOT NULL,
	[IdVendedor] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdFormaPago] [int] NOT NULL,
	[FechaVenta] [datetime] NOT NULL,
	[MontoTotal] [money] NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Empleado] ([IdEmpleado], [IdUsuario], [Legajo], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Estado], [Sueldo]) VALUES (1, 1, N'1001', N'Diego', N'Romero', 36605300, CAST(0x0000833801599C90 AS DateTime), N'Isla Decepcion 171', 1121776728, 1, CAST(2400.00 AS Decimal(10, 2)))
INSERT [dbo].[Empleado] ([IdEmpleado], [IdUsuario], [Legajo], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Estado], [Sueldo]) VALUES (2, 2, N'10002', N'Nicolas ', N'Carabajal', 36605199, CAST(0x0000831701599C90 AS DateTime), N'san felipe 30', 42814510, 1, CAST(18000.00 AS Decimal(10, 2)))
INSERT [dbo].[Empleado] ([IdEmpleado], [IdUsuario], [Legajo], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Estado], [Sueldo]) VALUES (3, 3, N'10003', N'Jonathan', N'Ojeda', 38228648, CAST(0x000083A301599C90 AS DateTime), N'La Rioja 39', 42904578, 1, CAST(20000.00 AS Decimal(10, 2)))
INSERT [dbo].[Empleado] ([IdEmpleado], [IdUsuario], [Legajo], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Estado], [Sueldo]) VALUES (4, 4, N'1002', N'Andres', N'Chimuris', 29456789, CAST(0x00007BCD01599C90 AS DateTime), N'ezeiza 1010', 421546, 1, CAST(240000.00 AS Decimal(10, 2)))
INSERT [dbo].[Empleado] ([IdEmpleado], [IdUsuario], [Legajo], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Estado], [Sueldo]) VALUES (5, 5, N'1003', N'Andres', N'Chimuris', 31456786, CAST(0x000081640005472C AS DateTime), N'ezeiza1010', 4257879, 1, CAST(24000.00 AS Decimal(10, 2)))
INSERT [dbo].[Empleado] ([IdEmpleado], [IdUsuario], [Legajo], [Nombre], [Apellido], [DNI], [FechaNacimiento], [Direccion], [Telefono], [Estado], [Sueldo]) VALUES (6, 6, N'1004', N'Andres', N'Chimuris', 36598412, CAST(0x00007CA101599C90 AS DateTime), N'ezeiza1401', 4254789, 1, CAST(24000.00 AS Decimal(10, 2)))
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
INSERT [dbo].[Usuario] ([IdUsuario], [Usuario], [Password], [IdTipoUsuario]) VALUES (1, N'dromero', N'sijvu17Bw6XIoaISgHZyndcdZes=', 1)
INSERT [dbo].[Usuario] ([IdUsuario], [Usuario], [Password], [IdTipoUsuario]) VALUES (2, N'ncarabajal', N'n0Jatp8YD62wz8N+jdwWcQU0H90=', 3)
INSERT [dbo].[Usuario] ([IdUsuario], [Usuario], [Password], [IdTipoUsuario]) VALUES (3, N'joeda', N'gx/d4lgtRW7zWvLTvPVbVij0k2Y=', 4)
INSERT [dbo].[Usuario] ([IdUsuario], [Usuario], [Password], [IdTipoUsuario]) VALUES (4, N'andres.admin', N'gspdhJeGUo9QgzenvTycCoDJEFs=', 1)
INSERT [dbo].[Usuario] ([IdUsuario], [Usuario], [Password], [IdTipoUsuario]) VALUES (5, N'andres.gerente', N'xj9jItoyLze5QY6V2XUKDK9oxMQ=', 2)
INSERT [dbo].[Usuario] ([IdUsuario], [Usuario], [Password], [IdTipoUsuario]) VALUES (6, N'andres.vendedor', N'ihXV3G7o7kBY/wfLKCznpC4Isj8=', 3)
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedro])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Proveedor]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCompra_Compra] FOREIGN KEY([IdCompra])
REFERENCES [dbo].[Compra] ([IdCompra])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DetalleCompra_Compra]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCompra_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DetalleCompra_Producto]
GO
ALTER TABLE [dbo].[DetalleVemta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVemta_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleVemta] CHECK CONSTRAINT [FK_DetalleVemta_Producto]
GO
ALTER TABLE [dbo].[DetalleVemta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVemta_Venta] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[DetalleVemta] CHECK CONSTRAINT [FK_DetalleVemta_Venta]
GO
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
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Empleado] FOREIGN KEY([IdVendedor])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Empleado]
GO
