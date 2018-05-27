USE [SportMaxDB]
GO
/****** Object:  StoredProcedure [dbo].[Marca_Insertar]    Script Date: 27/05/2018 20:28:26 ******/
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
/****** Object:  StoredProcedure [dbo].[Marca_Listar]    Script Date: 27/05/2018 20:28:26 ******/
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
/****** Object:  StoredProcedure [dbo].[Producto_BuscarxCodigo]    Script Date: 27/05/2018 20:28:26 ******/
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

	select a.IdProducto, a.IdTipoProducto, b.Descripcion as TipoProdDescrip, c.Descripcion as MarcaDescrip, a.Descripcion, Precio, Cantidad 
	from Producto a
	inner join TipoProducto b on a.IdTipoProducto = b.IdTipoProducto
	inner join Marca c on a.IdMarca =c.IdMarca 
	where IdProducto = @idProducto
	
END		

GO
/****** Object:  StoredProcedure [dbo].[Producto_BuscarxDescripcion]    Script Date: 27/05/2018 20:28:26 ******/
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

	select a.IdProducto, a.IdTipoProducto, b.Descripcion as TipoProdDescrip, c.Descripcion as MarcaDescrip, a.Descripcion, Precio, Cantidad 
	from Producto a
	inner join TipoProducto b on a.IdTipoProducto = b.IdTipoProducto
	inner join Marca c on a.IdMarca =c.IdMarca 
	where a.Descripcion like @Descripcion+'%'
	
END		

GO
/****** Object:  StoredProcedure [dbo].[Producto_Eliminar]    Script Date: 27/05/2018 20:28:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 10/05/2018
-- Description:	Insertar Producto
-- =============================================
Create PROCEDURE [dbo].[Producto_Eliminar] 
				@IdProducto int
AS					   
BEGIN

	IF exists(select * from Producto where IdProducto = @IdProducto)
		begin
			delete from Producto where IdProducto = @IdProducto
		end 
	else
		begin
			return 'Error al intentar insertar'
		end
END		

GO
/****** Object:  StoredProcedure [dbo].[Producto_Insertar]    Script Date: 27/05/2018 20:28:26 ******/
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
				@Precio money,
				@Cantidad int
AS					   
BEGIN

	IF not exists(select * from Producto where IdProducto = @IdProducto)
		begin
			insert into Producto (IdProducto,IdTipoProducto, IdMarca,Descripcion,Precio,Cantidad)
			Values(@IdProducto,@IdTipoProducto, @IdMarca ,@Descripcion,@Precio,@Cantidad)
		end 
	else
		begin
			return 'Error al intentar insertar'
		end
END		

GO
/****** Object:  StoredProcedure [dbo].[Producto_Listar]    Script Date: 27/05/2018 20:28:26 ******/
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

	select a.IdProducto, a.IdTipoProducto, b.Descripcion as TipoProdDescrip, c.Descripcion as MarcaDescrip, a.Descripcion, Precio, Cantidad 
	from Producto a
	inner join TipoProducto b on a.IdTipoProducto = b.IdTipoProducto
	inner join Marca c on a.IdMarca =c.IdMarca 
	
END		

GO
/****** Object:  StoredProcedure [dbo].[Producto_Modificar]    Script Date: 27/05/2018 20:28:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 10/05/2018
-- Description:	Insertar Producto
-- =============================================
Create PROCEDURE [dbo].[Producto_Modificar] 
				@IdProducto int,
				@IdTipoProducto int,
				@IdMarca int,
				@Descripcion varchar(50),
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
/****** Object:  StoredProcedure [dbo].[TipoProducto_Insertar]    Script Date: 27/05/2018 20:28:26 ******/
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
/****** Object:  StoredProcedure [dbo].[TipoProducto_Listar]    Script Date: 27/05/2018 20:28:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Diego Romero
-- Create date: 10/05/2018
-- Description:	Insertar Producto
-- =============================================
CREATE PROCEDURE [dbo].[TipoProducto_Listar] 

AS					   
BEGIN

	select IdTipoProducto, Descripcion
	from TipoProducto
	
END		

GO
/****** Object:  Table [dbo].[Marca]    Script Date: 27/05/2018 20:28:26 ******/
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
/****** Object:  Table [dbo].[Producto]    Script Date: 27/05/2018 20:28:27 ******/
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
	[Precio] [money] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoProducto]    Script Date: 27/05/2018 20:28:27 ******/
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
INSERT [dbo].[Marca] ([IdMarca], [Descripcion]) VALUES (1, N'Adidas')
INSERT [dbo].[Marca] ([IdMarca], [Descripcion]) VALUES (2, N'Nike')
INSERT [dbo].[Marca] ([IdMarca], [Descripcion]) VALUES (3, N'Reebok')
INSERT [dbo].[Marca] ([IdMarca], [Descripcion]) VALUES (4, N'Puma')
INSERT [dbo].[Producto] ([IdProducto], [IdTipoProducto], [IdMarca], [Descripcion], [Precio], [Cantidad]) VALUES (1, 1, 1, N'Remera adiaas XL', 15000.0000, 50)
INSERT [dbo].[Producto] ([IdProducto], [IdTipoProducto], [IdMarca], [Descripcion], [Precio], [Cantidad]) VALUES (2, 1, 1, N'Remera adidas L', 15000.0000, 50)
INSERT [dbo].[Producto] ([IdProducto], [IdTipoProducto], [IdMarca], [Descripcion], [Precio], [Cantidad]) VALUES (3, 1, 1, N'Remera adidas s', 10000.0000, 50)
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (1, N'Remera')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (2, N'Pantalon Largo')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (3, N'Pantalon Corto')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (4, N'Zapatillas')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (5, N'Medias')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (6, N'Botines')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (7, N'Bolso Deportivo')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (8, N'Mochila Deportiva')
INSERT [dbo].[TipoProducto] ([IdTipoProducto], [Descripcion]) VALUES (9, N'Pelota')
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
