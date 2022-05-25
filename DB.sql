USE master;  
GO

---------------------- DB CREATION ----------------------
PRINT 'CREATING DATABASE.....';
IF DB_ID (N'BDCrudTest') IS NOT NULL  
    DROP DATABASE BDCrudTest;  
GO

CREATE DATABASE BDCrudTest COLLATE Latin1_General_100_CS_AS_SC;  
GO  
 
USE BDCrudTest;
GO
PRINT 'DATABASE CREATED.';

---------------------- TABLES CREATION ----------------------
PRINT 'CREATING TABLES.....';
CREATE TABLE coCategoria (
	nIdCategori INT NOT NULL PRIMARY KEY,
	cNombCateg VARCHAR(255) NOT NULL,
	cEsActiva BIT DEFAULT 0
);

CREATE TABLE coProducto (
	nIdProduct INT NOT NULL PRIMARY KEY,
	cNombProdu VARCHAR(255),
	nPrecioProd NUMERIC(18,0),
	nIdCategori INT NOT NULL,
	CONSTRAINT UC_ProductoCategoria UNIQUE(nIdProduct,nIdCategori),
	CONSTRAINT FK_coCategoriaId FOREIGN KEY (nIdCategori) REFERENCES coCategoria(nIdCategori)
);
PRINT 'CREATED TABLES.';

---------------------- INSERT SECTION ----------------------
PRINT 'INSERTING ROWS.....';
---------------------- CATEGORIAS
INSERT INTO coCategoria VALUES (12,'Herramienta',1);
INSERT INTO coCategoria VALUES (13,'Alimento',1);

---------------------- PRODUCTOS
INSERT INTO coProducto VALUES (50,'Cinta metrica',10000,12);
INSERT INTO coProducto VALUES (51,'Taladro',20000,12);
INSERT INTO coProducto VALUES (52,'Caja destornilladores',15000,12);
INSERT INTO coProducto VALUES (60,'Leche',1000,13);
INSERT INTO coProducto VALUES (61,'Azucar',1200,13);
INSERT INTO coProducto VALUES (62,'Arroz',2500,13);

PRINT 'INSERTED ROWS.';

---------------------- PROCEDURES SECTION ----------------------
PRINT 'CREATING PROCEDURES.....';

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

---------------------- PRODUCTO
CREATE OR ALTER PROCEDURE Usp_List_Productos
AS
BEGIN
 SELECT prod.nIdProduct, prod.cNombProdu, prod.nPrecioProd, cat.cNombCateg
 FROM coProducto prod
 INNER JOIN coCategoria cat
 ON prod.nIdCategori = cat.nIdCategori
END
GO

CREATE OR ALTER PROCEDURE Usp_Get_Producto (@IDPRODUCTO INT )
AS
BEGIN
 SELECT prod.nIdProduct, prod.cNombProdu, prod.nPrecioProd, cat.nIdCategori
 FROM coProducto prod
 INNER JOIN coCategoria cat
 ON prod.nIdCategori = cat.nIdCategori
 WHERE prod.nIdProduct = @IDPRODUCTO;
END
GO

CREATE OR ALTER PROCEDURE Usp_Insert_Producto (@IDPRODUCTO INT, @NOMBPRODUCTO VARCHAR(255), @PRECIOPRODUCTO NUMERIC(18,0), @IDCATEGORIA INT)
AS
BEGIN
 INSERT INTO coProducto VALUES (@IDPRODUCTO,@NOMBPRODUCTO,@PRECIOPRODUCTO,@IDCATEGORIA);
END
GO

CREATE OR ALTER PROCEDURE Usp_Update_Producto (@IDPRODUCTO INT, @NOMBPRODUCTO VARCHAR(255), @PRECIOPRODUCTO NUMERIC(18,0), @IDCATEGORIA INT)
AS
BEGIN
 UPDATE coProducto
 SET cNombProdu = @NOMBPRODUCTO, nPrecioProd = @PRECIOPRODUCTO, nIdCategori = @IDCATEGORIA
 WHERE nIdProduct = @IDPRODUCTO;
END
GO

CREATE OR ALTER PROCEDURE Usp_Delete_Producto (@IDPRODUCTO INT)
AS
BEGIN
 DELETE FROM coProducto WHERE nIdProduct = @IDPRODUCTO;
END
GO

CREATE OR ALTER PROCEDURE Usp_Sel_Co_Productos ( @IDCATEGORIA INT)
AS
BEGIN
 SELECT prod.nIdProduct, prod.cNombProdu, prod.nPrecioProd, cat.cNombCateg
 FROM coProducto prod
 INNER JOIN coCategoria cat
 ON prod.nIdCategori = cat.nIdCategori
 WHERE prod.nIdCategori = @IDCATEGORIA;
END
GO

---------------------- CATEGORIA
CREATE OR ALTER PROCEDURE Usp_List_Categorias
AS
BEGIN
 SELECT *
 FROM coCategoria
END
GO

CREATE OR ALTER PROCEDURE Usp_Get_Categoria (@IDCATEGORIA INT )
AS
BEGIN
 SELECT *
 FROM coCategoria 
 WHERE nIdCategori = @IDCATEGORIA;
END
GO

CREATE OR ALTER PROCEDURE Usp_Update_Categoria (@IDCATEGORIA INT, @NOMBCATEGORIA VARCHAR(255), @ESTADO BIT)
AS
BEGIN
 UPDATE coCategoria
 SET cNombCateg =  @NOMBCATEGORIA, cEsActiva = @ESTADO
 WHERE nIdCategori = @IDCATEGORIA
END
GO

CREATE OR ALTER PROCEDURE Usp_Delete_Categoria (@IDCATEGORIA INT)
AS
BEGIN
 DELETE FROM coCategoria WHERE nIdCategori = @IDCATEGORIA;
END
GO

CREATE OR ALTER PROCEDURE Usp_Ins_Co_Categoria (@IDCATEGORIA INT, @NOMBCATEGORIA VARCHAR(255), @ESTADO BIT)
AS
BEGIN
	INSERT INTO coCategoria VALUES (@IDCATEGORIA, @NOMBCATEGORIA, @ESTADO);
END

PRINT 'CREATED PROCEDURES.';