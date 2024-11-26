--------------------------------------------------------
-- Archivo creado  - domingo-noviembre-17-2024   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Sequence SEQ_COMPRAS
--------------------------------------------------------

   CREATE SEQUENCE  "NEGOCIO"."SEQ_COMPRAS"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 4 NOCACHE  NOORDER  NOCYCLE  NOKEEP  NOSCALE  GLOBAL ;
--------------------------------------------------------
--  DDL for Sequence SEQ_FACTURAS
--------------------------------------------------------

   CREATE SEQUENCE  "NEGOCIO"."SEQ_FACTURAS"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 4 NOCACHE  NOORDER  NOCYCLE  NOKEEP  NOSCALE  GLOBAL ;
--------------------------------------------------------
--  DDL for Sequence SEQ_VENTAS
--------------------------------------------------------

   CREATE SEQUENCE  "NEGOCIO"."SEQ_VENTAS"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 4 NOCACHE  NOORDER  NOCYCLE  NOKEEP  NOSCALE  GLOBAL ;
--------------------------------------------------------
--  DDL for Table CATEGORIAS
--------------------------------------------------------

  CREATE TABLE "NEGOCIO"."CATEGORIAS" 
   (	"IDCATEGORIA" VARCHAR2(5 BYTE), 
	"NOMBRECATEGORIA" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Table COMPRAS
--------------------------------------------------------

  CREATE TABLE "NEGOCIO"."COMPRAS" 
   (	"IDCOMPRA" NUMBER(*,0), 
	"IDPROVEEDOR" NUMBER(*,0), 
	"IDPRODUCTO" VARCHAR2(5 BYTE), 
	"CANTIDADCAJAS" NUMBER(*,0), 
	"PRECIOCAJA" NUMBER(10,2), 
	"TOTALCOMPRA" NUMBER(10,2), 
	"FECHACOMPRA" DATE, 
	"PAGOID" VARCHAR2(5 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Table FACTURAS
--------------------------------------------------------

  CREATE TABLE "NEGOCIO"."FACTURAS" 
   (	"IDFACTURA" NUMBER(*,0), 
	"IDPAGO" VARCHAR2(3 BYTE), 
	"FECHAFACTURA" DATE, 
	"TOTAL" NUMBER(10,2), 
	"MONTO" NUMBER(10,2), 
	"VUELTOS" NUMBER(10,2)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Table METODOPAGOS
--------------------------------------------------------

  CREATE TABLE "NEGOCIO"."METODOPAGOS" 
   (	"IDPAGO" VARCHAR2(5 BYTE), 
	"NOMBREMETODO" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Table PRODUCTOS
--------------------------------------------------------

  CREATE TABLE "NEGOCIO"."PRODUCTOS" 
   (	"IDPRODUCTO" VARCHAR2(5 BYTE), 
	"IDCATEGORIA" VARCHAR2(3 BYTE), 
	"NOMBREPRODUCTO" VARCHAR2(50 BYTE), 
	"PRECIOVENTA" NUMBER(10,2), 
	"CANTIDAD" NUMBER(11,3)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Table PROVEEDORES
--------------------------------------------------------

  CREATE TABLE "NEGOCIO"."PROVEEDORES" 
   (	"IDPROVEEDOR" NUMBER(*,0), 
	"TIPOID" VARCHAR2(3 BYTE), 
	"NOMBRE1" VARCHAR2(15 BYTE), 
	"NOMBRE2" VARCHAR2(15 BYTE), 
	"APELLIDO1" VARCHAR2(30 BYTE), 
	"APELLIDO2" VARCHAR2(30 BYTE), 
	"TELEFONO" NUMBER(*,0), 
	"EMAIL" VARCHAR2(40 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Table TIPOID
--------------------------------------------------------

  CREATE TABLE "NEGOCIO"."TIPOID" 
   (	"IDTIPO" VARCHAR2(3 BYTE), 
	"NOMBRE" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Table VENTAS
--------------------------------------------------------

  CREATE TABLE "NEGOCIO"."VENTAS" 
   (	"IDVENTA" NUMBER(*,0), 
	"IDPRODUCTO" VARCHAR2(5 BYTE), 
	"CANTIDADLIBRAS" NUMBER(10,2), 
	"PRECIOLIBRA" NUMBER(10,2), 
	"NOMBRECLIENTE" VARCHAR2(15 BYTE), 
	"APELLIDOCLIENTE" VARCHAR2(30 BYTE), 
	"IDFACTURA" NUMBER
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for View VISTACOMPRAS
--------------------------------------------------------

  CREATE OR REPLACE FORCE EDITIONABLE VIEW "NEGOCIO"."VISTACOMPRAS" ("IDCOMPRA", "FECHACOMPRA", "IDPRODUCTO", "NOMBREPRODUCTO", "CANTIDADCAJAS", "PRECIOCAJA", "TOTALCOMPRA", "IDPROVEEDOR", "NOMBRE1", "APELLIDO1", "TIPOID", "TELEFONO", "EMAIL", "PAGOID", "METODODEPAGO") AS 
  SELECT
    C.IDCompra,
    C.FechaCompra,
    C.IDProducto,
    P.NombreProducto,
    C.CantidadCajas,
    C.PrecioCaja,
    C.TotalCompra,
    C.IDProveedor,
    PR.Nombre1,
    PR.Apellido1,
    PR.TipoID,
    PR.Telefono,
    PR.Email,
    C.PagoID,
    M.NombreMetodo AS MetodoDePago
FROM
    Compras C
JOIN
    Productos P ON C.IDProducto = P.IDProducto
JOIN
    Proveedores PR ON C.IDProveedor = PR.IDProveedor
JOIN
    MetodoPagos M ON C.PagoID = M.IDPago
;
--------------------------------------------------------
--  DDL for View VISTACOMPRASDETALLE
--------------------------------------------------------

  CREATE OR REPLACE FORCE EDITIONABLE VIEW "NEGOCIO"."VISTACOMPRASDETALLE" ("IDCOMPRA", "FECHACOMPRA", "IDPRODUCTO", "NOMBREPRODUCTO", "CANTIDADCAJAS", "PRECIOCAJA", "TOTALCOMPRA", "IDPROVEEDOR", "NOMBRE1", "APELLIDO1", "TIPOID", "TELEFONO", "EMAIL", "PAGOID", "METODODEPAGO") AS 
  SELECT
    C.IDCompra,
    C.FechaCompra,
    C.IDProducto,
    P.NombreProducto,
    C.CantidadCajas,
    C.PrecioCaja,
    C.TotalCompra,
    C.IDProveedor,
    PR.Nombre1,
    PR.Apellido1,
    PR.TipoID,
    PR.Telefono,
    PR.Email,
    C.PagoID,
    M.NombreMetodo AS MetodoDePago
FROM
    Compras C
JOIN
    Productos P ON C.IDProducto = P.IDProducto
JOIN
    Proveedores PR ON C.IDProveedor = PR.IDProveedor
JOIN
    MetodoPagos M ON C.PagoID = M.IDPago
;
--------------------------------------------------------
--  DDL for View VISTAVENTAS
--------------------------------------------------------

  CREATE OR REPLACE FORCE EDITIONABLE VIEW "NEGOCIO"."VISTAVENTAS" ("IDVENTA", "IDPRODUCTO", "NOMBREPRODUCTO", "CANTIDADLIBRAS", "PRECIOLIBRA", "TOTALVENTA", "NOMBRECLIENTE", "APELLIDOCLIENTE", "IDFACTURA", "FECHAFACTURA", "TOTAL", "MONTO", "VUELTOS", "IDPAGO", "METODODEPAGO") AS 
  SELECT 
    V.IDVenta,
    V.IDProducto,
    P.NombreProducto,
    V.CantidadLibras,
    V.PrecioLibra,
    (V.CantidadLibras * V.PrecioLibra) AS TotalVenta,
    V.NombreCliente,
    V.ApellidoCliente,
    F.IDFactura,
    F.FechaFactura,
    F.Total,
    F.Monto,
    F.Vueltos,
    F.IDPago,
    M.NombreMetodo AS MetodoDePago
FROM 
    Ventas V
JOIN 
    Productos P ON V.IDProducto = P.IDProducto
JOIN 
    Facturas F ON V.IDFactura = F.IDFactura
JOIN 
    MetodoPagos M ON F.IDPago = M.IDPago
;
REM INSERTING into NEGOCIO.CATEGORIAS
SET DEFINE OFF;
Insert into NEGOCIO.CATEGORIAS (IDCATEGORIA,NOMBRECATEGORIA) values ('EC','Especias y condimentos');
Insert into NEGOCIO.CATEGORIAS (IDCATEGORIA,NOMBRECATEGORIA) values ('VA','Vegetales aromatizantes');
Insert into NEGOCIO.CATEGORIAS (IDCATEGORIA,NOMBRECATEGORIA) values ('FD','Frutos deshidratados');
REM INSERTING into NEGOCIO.COMPRAS
SET DEFINE OFF;
Insert into NEGOCIO.COMPRAS (IDCOMPRA,IDPROVEEDOR,IDPRODUCTO,CANTIDADCAJAS,PRECIOCAJA,TOTALCOMPRA,FECHACOMPRA,PAGOID) values ('2','1062396075','AJ001','5','90000','450000',to_date('16/11/24','DD/MM/RR'),'PE');
Insert into NEGOCIO.COMPRAS (IDCOMPRA,IDPROVEEDOR,IDPRODUCTO,CANTIDADCAJAS,PRECIOCAJA,TOTALCOMPRA,FECHACOMPRA,PAGOID) values ('3','1065593501','CN001','4','70000','280000',to_date('17/11/24','DD/MM/RR'),'PE');
REM INSERTING into NEGOCIO.FACTURAS
SET DEFINE OFF;
Insert into NEGOCIO.FACTURAS (IDFACTURA,IDPAGO,FECHAFACTURA,TOTAL,MONTO,VUELTOS) values ('1','PE',to_date('17/11/24','DD/MM/RR'),'13594,17','30000','16405,83');
Insert into NEGOCIO.FACTURAS (IDFACTURA,IDPAGO,FECHAFACTURA,TOTAL,MONTO,VUELTOS) values ('2','PE',to_date('17/11/24','DD/MM/RR'),'22656,95','30000','7343,05');
Insert into NEGOCIO.FACTURAS (IDFACTURA,IDPAGO,FECHAFACTURA,TOTAL,MONTO,VUELTOS) values ('3','PE',to_date('17/11/24','DD/MM/RR'),'28195,36','50000','21804,64');
REM INSERTING into NEGOCIO.METODOPAGOS
SET DEFINE OFF;
Insert into NEGOCIO.METODOPAGOS (IDPAGO,NOMBREMETODO) values ('PE','Pagos en efectivo');
Insert into NEGOCIO.METODOPAGOS (IDPAGO,NOMBREMETODO) values ('TE','Transferencias Electrónicas');
REM INSERTING into NEGOCIO.PRODUCTOS
SET DEFINE OFF;
Insert into NEGOCIO.PRODUCTOS (IDPRODUCTO,IDCATEGORIA,NOMBREPRODUCTO,PRECIOVENTA,CANTIDAD) values ('AJ001','VA','AJO','4531,39','102,231');
Insert into NEGOCIO.PRODUCTOS (IDPRODUCTO,IDCATEGORIA,NOMBREPRODUCTO,PRECIOVENTA,CANTIDAD) values ('CN001','EC','Canela','3524,42','80,185');
Insert into NEGOCIO.PRODUCTOS (IDPRODUCTO,IDCATEGORIA,NOMBREPRODUCTO,PRECIOVENTA,CANTIDAD) values ('CL001','EC','Clavito','0','0');
Insert into NEGOCIO.PRODUCTOS (IDPRODUCTO,IDCATEGORIA,NOMBREPRODUCTO,PRECIOVENTA,CANTIDAD) values ('AE001','EC','Anis estrellado','0','0');
Insert into NEGOCIO.PRODUCTOS (IDPRODUCTO,IDCATEGORIA,NOMBREPRODUCTO,PRECIOVENTA,CANTIDAD) values ('UP001','FD','Frutos deshidratados','0','0');
REM INSERTING into NEGOCIO.PROVEEDORES
SET DEFINE OFF;
Insert into NEGOCIO.PROVEEDORES (IDPROVEEDOR,TIPOID,NOMBRE1,NOMBRE2,APELLIDO1,APELLIDO2,TELEFONO,EMAIL) values ('1062396075','CC','Dairo',null,'Duran',null,'3216059737','dairodu123@gmail.com');
Insert into NEGOCIO.PROVEEDORES (IDPROVEEDOR,TIPOID,NOMBRE1,NOMBRE2,APELLIDO1,APELLIDO2,TELEFONO,EMAIL) values ('1065593501','CC','Juan',null,'Peñuela',null,'3106718480',null);
Insert into NEGOCIO.PROVEEDORES (IDPROVEEDOR,TIPOID,NOMBRE1,NOMBRE2,APELLIDO1,APELLIDO2,TELEFONO,EMAIL) values ('1111112','CC','Carlos',null,'Rivera',null,'3217489592',null);
REM INSERTING into NEGOCIO.TIPOID
SET DEFINE OFF;
Insert into NEGOCIO.TIPOID (IDTIPO,NOMBRE) values ('TI','Tarjeta de identidad');
Insert into NEGOCIO.TIPOID (IDTIPO,NOMBRE) values ('CE','Cédula de Extranjería');
Insert into NEGOCIO.TIPOID (IDTIPO,NOMBRE) values ('PP','Pasaporte');
Insert into NEGOCIO.TIPOID (IDTIPO,NOMBRE) values ('CC','Cedula de ciudadania');
REM INSERTING into NEGOCIO.VENTAS
SET DEFINE OFF;
Insert into NEGOCIO.VENTAS (IDVENTA,IDPRODUCTO,CANTIDADLIBRAS,PRECIOLIBRA,NOMBRECLIENTE,APELLIDOCLIENTE,IDFACTURA) values ('1','AJ001','3','4531,39','Jorge','Romero','1');
Insert into NEGOCIO.VENTAS (IDVENTA,IDPRODUCTO,CANTIDADLIBRAS,PRECIOLIBRA,NOMBRECLIENTE,APELLIDOCLIENTE,IDFACTURA) values ('2','AJ001','5','4531,39','Jorge','Romero','2');
Insert into NEGOCIO.VENTAS (IDVENTA,IDPRODUCTO,CANTIDADLIBRAS,PRECIOLIBRA,NOMBRECLIENTE,APELLIDOCLIENTE,IDFACTURA) values ('3','CN001','8','3524,42','Sebastian','Figueroa','3');
REM INSERTING into NEGOCIO.VISTACOMPRAS
SET DEFINE OFF;
Insert into NEGOCIO.VISTACOMPRAS (IDCOMPRA,FECHACOMPRA,IDPRODUCTO,NOMBREPRODUCTO,CANTIDADCAJAS,PRECIOCAJA,TOTALCOMPRA,IDPROVEEDOR,NOMBRE1,APELLIDO1,TIPOID,TELEFONO,EMAIL,PAGOID,METODODEPAGO) values ('2',to_date('16/11/24','DD/MM/RR'),'AJ001','AJO','5','90000','450000','1062396075','Dairo','Duran','CC','3216059737','dairodu123@gmail.com','PE','Pagos en efectivo');
Insert into NEGOCIO.VISTACOMPRAS (IDCOMPRA,FECHACOMPRA,IDPRODUCTO,NOMBREPRODUCTO,CANTIDADCAJAS,PRECIOCAJA,TOTALCOMPRA,IDPROVEEDOR,NOMBRE1,APELLIDO1,TIPOID,TELEFONO,EMAIL,PAGOID,METODODEPAGO) values ('3',to_date('17/11/24','DD/MM/RR'),'CN001','Canela','4','70000','280000','1065593501','Juan','Peñuela','CC','3106718480',null,'PE','Pagos en efectivo');
REM INSERTING into NEGOCIO.VISTACOMPRASDETALLE
SET DEFINE OFF;
Insert into NEGOCIO.VISTACOMPRASDETALLE (IDCOMPRA,FECHACOMPRA,IDPRODUCTO,NOMBREPRODUCTO,CANTIDADCAJAS,PRECIOCAJA,TOTALCOMPRA,IDPROVEEDOR,NOMBRE1,APELLIDO1,TIPOID,TELEFONO,EMAIL,PAGOID,METODODEPAGO) values ('2',to_date('16/11/24','DD/MM/RR'),'AJ001','AJO','5','90000','450000','1062396075','Dairo','Duran','CC','3216059737','dairodu123@gmail.com','PE','Pagos en efectivo');
Insert into NEGOCIO.VISTACOMPRASDETALLE (IDCOMPRA,FECHACOMPRA,IDPRODUCTO,NOMBREPRODUCTO,CANTIDADCAJAS,PRECIOCAJA,TOTALCOMPRA,IDPROVEEDOR,NOMBRE1,APELLIDO1,TIPOID,TELEFONO,EMAIL,PAGOID,METODODEPAGO) values ('3',to_date('17/11/24','DD/MM/RR'),'CN001','Canela','4','70000','280000','1065593501','Juan','Peñuela','CC','3106718480',null,'PE','Pagos en efectivo');
REM INSERTING into NEGOCIO.VISTAVENTAS
SET DEFINE OFF;
Insert into NEGOCIO.VISTAVENTAS (IDVENTA,IDPRODUCTO,NOMBREPRODUCTO,CANTIDADLIBRAS,PRECIOLIBRA,TOTALVENTA,NOMBRECLIENTE,APELLIDOCLIENTE,IDFACTURA,FECHAFACTURA,TOTAL,MONTO,VUELTOS,IDPAGO,METODODEPAGO) values ('1','AJ001','AJO','3','4531,39','13594,17','Jorge','Romero','1',to_date('17/11/24','DD/MM/RR'),'13594,17','30000','16405,83','PE','Pagos en efectivo');
Insert into NEGOCIO.VISTAVENTAS (IDVENTA,IDPRODUCTO,NOMBREPRODUCTO,CANTIDADLIBRAS,PRECIOLIBRA,TOTALVENTA,NOMBRECLIENTE,APELLIDOCLIENTE,IDFACTURA,FECHAFACTURA,TOTAL,MONTO,VUELTOS,IDPAGO,METODODEPAGO) values ('2','AJ001','AJO','5','4531,39','22656,95','Jorge','Romero','2',to_date('17/11/24','DD/MM/RR'),'22656,95','30000','7343,05','PE','Pagos en efectivo');
Insert into NEGOCIO.VISTAVENTAS (IDVENTA,IDPRODUCTO,NOMBREPRODUCTO,CANTIDADLIBRAS,PRECIOLIBRA,TOTALVENTA,NOMBRECLIENTE,APELLIDOCLIENTE,IDFACTURA,FECHAFACTURA,TOTAL,MONTO,VUELTOS,IDPAGO,METODODEPAGO) values ('3','CN001','Canela','8','3524,42','28195,36','Sebastian','Figueroa','3',to_date('17/11/24','DD/MM/RR'),'28195,36','50000','21804,64','PE','Pagos en efectivo');
--------------------------------------------------------
--  DDL for Index PK_CATEGORIAS_IDCATEGORIA
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_CATEGORIAS_IDCATEGORIA" ON "NEGOCIO"."CATEGORIAS" ("IDCATEGORIA") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_COMPRAS_IDCOMPRA
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_COMPRAS_IDCOMPRA" ON "NEGOCIO"."COMPRAS" ("IDCOMPRA") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_FACTURAS_IDFACTURA
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_FACTURAS_IDFACTURA" ON "NEGOCIO"."FACTURAS" ("IDFACTURA") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_METODOPAGOS_IDPAGO
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_METODOPAGOS_IDPAGO" ON "NEGOCIO"."METODOPAGOS" ("IDPAGO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_PRODUCTOS_IDPRODUCTO
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_PRODUCTOS_IDPRODUCTO" ON "NEGOCIO"."PRODUCTOS" ("IDPRODUCTO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_PROVEEDORES_IDPROVEEDOR
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_PROVEEDORES_IDPROVEEDOR" ON "NEGOCIO"."PROVEEDORES" ("IDPROVEEDOR") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_TIPOID_IDTIPO
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_TIPOID_IDTIPO" ON "NEGOCIO"."TIPOID" ("IDTIPO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_VENTAS_IDVENTA
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_VENTAS_IDVENTA" ON "NEGOCIO"."VENTAS" ("IDVENTA") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_CATEGORIAS_IDCATEGORIA
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_CATEGORIAS_IDCATEGORIA" ON "NEGOCIO"."CATEGORIAS" ("IDCATEGORIA") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_COMPRAS_IDCOMPRA
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_COMPRAS_IDCOMPRA" ON "NEGOCIO"."COMPRAS" ("IDCOMPRA") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_FACTURAS_IDFACTURA
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_FACTURAS_IDFACTURA" ON "NEGOCIO"."FACTURAS" ("IDFACTURA") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_METODOPAGOS_IDPAGO
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_METODOPAGOS_IDPAGO" ON "NEGOCIO"."METODOPAGOS" ("IDPAGO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_PRODUCTOS_IDPRODUCTO
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_PRODUCTOS_IDPRODUCTO" ON "NEGOCIO"."PRODUCTOS" ("IDPRODUCTO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_PROVEEDORES_IDPROVEEDOR
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_PROVEEDORES_IDPROVEEDOR" ON "NEGOCIO"."PROVEEDORES" ("IDPROVEEDOR") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_TIPOID_IDTIPO
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_TIPOID_IDTIPO" ON "NEGOCIO"."TIPOID" ("IDTIPO") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Index PK_VENTAS_IDVENTA
--------------------------------------------------------

  CREATE UNIQUE INDEX "NEGOCIO"."PK_VENTAS_IDVENTA" ON "NEGOCIO"."VENTAS" ("IDVENTA") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA" ;
--------------------------------------------------------
--  DDL for Trigger TRG_ACUALIZARINVENTARIO
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE TRIGGER "NEGOCIO"."TRG_ACUALIZARINVENTARIO" 
AFTER INSERT ON Ventas
FOR EACH ROW
BEGIN
    UPDATE Productos
    SET Cantidad = Cantidad - :NEW.CantidadLibras
    WHERE IDProducto = :NEW.IDProducto;
END;

/
ALTER TRIGGER "NEGOCIO"."TRG_ACUALIZARINVENTARIO" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRG_CANTIDADPRODUCTO
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE TRIGGER "NEGOCIO"."TRG_CANTIDADPRODUCTO" 
AFTER INSERT ON Compras
FOR EACH ROW
BEGIN
    UPDATE Productos
    SET Cantidad = Cantidad + (:NEW.CantidadCajas * 22.0462) -- Convierto los kilos por caja a libras
    WHERE IDPRODUCTO = :NEW.IDPRODUCTO;
END;
/
ALTER TRIGGER "NEGOCIO"."TRG_CANTIDADPRODUCTO" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRG_PRECIOVENTA
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE TRIGGER "NEGOCIO"."TRG_PRECIOVENTA" 
AFTER INSERT OR UPDATE ON Compras
FOR EACH ROW
BEGIN
    UPDATE Productos
    SET PrecioVenta = (:NEW.PrecioCaja / 22.0462) * 1.11 -- Precio por libra más un 11% de ganancia
    WHERE IDPRODUCTO = :NEW.IDPRODUCTO;
END;

/
ALTER TRIGGER "NEGOCIO"."TRG_PRECIOVENTA" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRG_TOTALCOMPRA
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE TRIGGER "NEGOCIO"."TRG_TOTALCOMPRA" 
BEFORE INSERT OR UPDATE ON Compras
FOR EACH ROW
BEGIN
    :NEW.TotalCompra := :NEW.CantidadCajas * :NEW.PrecioCaja;
END;
/
ALTER TRIGGER "NEGOCIO"."TRG_TOTALCOMPRA" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRG_TOTALCOMPRA
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE TRIGGER "NEGOCIO"."TRG_TOTALCOMPRA" 
BEFORE INSERT OR UPDATE ON Compras
FOR EACH ROW
BEGIN
    :NEW.TotalCompra := :NEW.CantidadCajas * :NEW.PrecioCaja;
END;
/
ALTER TRIGGER "NEGOCIO"."TRG_TOTALCOMPRA" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRG_CANTIDADPRODUCTO
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE TRIGGER "NEGOCIO"."TRG_CANTIDADPRODUCTO" 
AFTER INSERT ON Compras
FOR EACH ROW
BEGIN
    UPDATE Productos
    SET Cantidad = Cantidad + (:NEW.CantidadCajas * 22.0462) -- Convierto los kilos por caja a libras
    WHERE IDPRODUCTO = :NEW.IDPRODUCTO;
END;
/
ALTER TRIGGER "NEGOCIO"."TRG_CANTIDADPRODUCTO" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRG_PRECIOVENTA
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE TRIGGER "NEGOCIO"."TRG_PRECIOVENTA" 
AFTER INSERT OR UPDATE ON Compras
FOR EACH ROW
BEGIN
    UPDATE Productos
    SET PrecioVenta = (:NEW.PrecioCaja / 22.0462) * 1.11 -- Precio por libra más un 11% de ganancia
    WHERE IDPRODUCTO = :NEW.IDPRODUCTO;
END;

/
ALTER TRIGGER "NEGOCIO"."TRG_PRECIOVENTA" ENABLE;
--------------------------------------------------------
--  DDL for Trigger TRG_ACUALIZARINVENTARIO
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE TRIGGER "NEGOCIO"."TRG_ACUALIZARINVENTARIO" 
AFTER INSERT ON Ventas
FOR EACH ROW
BEGIN
    UPDATE Productos
    SET Cantidad = Cantidad - :NEW.CantidadLibras
    WHERE IDProducto = :NEW.IDProducto;
END;

/
ALTER TRIGGER "NEGOCIO"."TRG_ACUALIZARINVENTARIO" ENABLE;
--------------------------------------------------------
--  DDL for Package PKG_GESTIONCOMPRAS
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE PACKAGE "NEGOCIO"."PKG_GESTIONCOMPRAS" AS
    PROCEDURE InsertarCompra(
        p_id_proveedor IN NUMBER,
        p_id_producto IN VARCHAR2,
        p_cantidad_cajas IN NUMBER,
        p_precio_caja IN NUMBER,
        p_fecha_compra IN DATE,
        p_pago_id IN VARCHAR2
        );

    PROCEDURE ModificarCompra(
        p_id_compra IN NUMBER,
        p_id_proveedor IN NUMBER,
        p_id_producto IN VARCHAR2,
        p_cantidad_cajas IN NUMBER,
        p_precio_caja IN NUMBER,
        p_fecha_compra IN DATE,
        p_pago_id IN VARCHAR2
        );

    PROCEDURE EliminarCompra(
        p_id_compra IN NUMBER
        );
END PKG_GestionCompras;

/
--------------------------------------------------------
--  DDL for Package PKG_GESTIONPRODUCTOS
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE PACKAGE "NEGOCIO"."PKG_GESTIONPRODUCTOS" AS
    PROCEDURE InsertarProducto(
        p_id_producto IN VARCHAR2,
        p_id_categoria IN VARCHAR2,
        p_nombre_producto IN VARCHAR2
        );

    PROCEDURE ModificarProducto(
        p_id_producto IN VARCHAR2,
        p_id_categoria IN VARCHAR2,
        p_nombre_producto IN VARCHAR2,
        p_precio_venta IN NUMBER,
        p_cantidad IN NUMBER
        );

    PROCEDURE EliminarProducto(
        p_id_producto IN VARCHAR2
        );

END PKG_GestionProductos;

/
--------------------------------------------------------
--  DDL for Package PKG_GESTIONPROVEEDOR
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE PACKAGE "NEGOCIO"."PKG_GESTIONPROVEEDOR" AS
    PROCEDURE InsertarProveedor(
        p_id_proveedor IN NUMBER,
        p_tipo_id IN VARCHAR2,
        p_nombre1 IN VARCHAR2,
        p_nombre2 IN VARCHAR2,
        p_apellido1 IN VARCHAR2,
        p_apellido2 IN VARCHAR2,
        p_telefono IN NUMBER,
        p_email IN VARCHAR2
        );

    PROCEDURE ModificarProveedor(
        p_id_proveedor IN NUMBER,
        p_tipo_id IN VARCHAR2,
        p_nombre1 IN VARCHAR2,
        p_nombre2 IN VARCHAR2,
        p_apellido1 IN VARCHAR2,
        p_apellido2 IN VARCHAR2,
        p_telefono IN NUMBER,
        p_email IN VARCHAR2);

    PROCEDURE EliminarProveedor(
        p_id_proveedor IN NUMBER);

END PKG_GestionProveedor;

/
--------------------------------------------------------
--  DDL for Package PKG_GESTIONVENTAS
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE PACKAGE "NEGOCIO"."PKG_GESTIONVENTAS" AS
    PROCEDURE HacerVenta(
        p_id_producto IN VARCHAR2,
        p_cantidad IN NUMBER,
        p_nombre_cliente IN VARCHAR2,
        p_apellido_cliente IN VARCHAR2,
        p_monto IN NUMBER,
        p_id_metodo_pago IN VARCHAR2
    );
END PKG_GestionVentas;

/
--------------------------------------------------------
--  DDL for Package Body PKG_GESTIONCOMPRAS
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE PACKAGE BODY "NEGOCIO"."PKG_GESTIONCOMPRAS" AS
    PROCEDURE InsertarCompra(
        p_id_proveedor IN NUMBER,
        p_id_producto IN VARCHAR2,
        p_cantidad_cajas IN NUMBER,
        p_precio_caja IN NUMBER,
        p_fecha_compra IN DATE,
        p_pago_id IN VARCHAR2
        ) IS
    BEGIN

        IF p_id_proveedor IS NULL THEN
            DBMS_OUTPUT.PUT_LINE('Error: ID del proveedor es obligatorio.');
            RETURN;
        END IF;

        IF p_id_producto IS NULL OR LENGTH(p_id_producto) > 5 THEN
            DBMS_OUTPUT.PUT_LINE('Error: Verifique el ID del producto.');
            RETURN;
        END IF;

        IF p_cantidad_cajas IS NULL OR p_cantidad_cajas <= 0 THEN
            DBMS_OUTPUT.PUT_LINE('Error: La cantidad de cajas debe ser un número positivo.');
            RETURN;
        END IF;

        IF p_precio_caja IS NULL OR p_precio_caja <= 0 THEN
            DBMS_OUTPUT.PUT_LINE('Error: El precio por caja debe ser un número positivo.');
            RETURN;
        END IF;

        IF p_fecha_compra IS NULL THEN
            DBMS_OUTPUT.PUT_LINE('Error: La fecha de compra es obligatoria.');
            RETURN;
        END IF;

        IF p_pago_id IS NULL OR LENGTH(p_pago_id) > 5 THEN
            DBMS_OUTPUT.PUT_LINE('Error: Verifique el ID del pago.');
            RETURN;
        END IF;

        INSERT INTO Compras (IDCOMPRA, IDPROVEEDOR, IDPRODUCTO, CANTIDADCAJAS, PRECIOCAJA, TOTALCOMPRA, FECHACOMPRA, PAGOID)
        VALUES (SEQ_Compras.NEXTVAL, p_id_proveedor, p_id_producto, p_cantidad_cajas, p_precio_caja, NULL, p_fecha_compra, p_pago_id);
        DBMS_OUTPUT.PUT_LINE('Compra insertada correctamente.');
    END InsertarCompra;

    PROCEDURE ModificarCompra(
        p_id_compra IN NUMBER,
        p_id_proveedor IN NUMBER,
        p_id_producto IN VARCHAR2,
        p_cantidad_cajas IN NUMBER,
        p_precio_caja IN NUMBER,
        p_fecha_compra IN DATE,
        p_pago_id IN VARCHAR2) IS
    BEGIN

        IF p_id_compra IS NULL THEN
            DBMS_OUTPUT.PUT_LINE('Error: ID de la compra es obligatorio.');
            RETURN;
        END IF;

        IF p_id_proveedor IS NULL THEN
            DBMS_OUTPUT.PUT_LINE('Error: ID del proveedor es obligatorio.');
            RETURN;
        END IF;

        IF p_id_producto IS NULL OR LENGTH(p_id_producto) > 5 THEN
            DBMS_OUTPUT.PUT_LINE('Error: Verifique el ID del producto.');
            RETURN;
        END IF;

        IF p_cantidad_cajas IS NULL OR p_cantidad_cajas <= 0 THEN
            DBMS_OUTPUT.PUT_LINE('Error: La cantidad de cajas debe ser un número positivo.');
            RETURN;
        END IF;

        IF p_precio_caja IS NULL OR p_precio_caja <= 0 THEN
            DBMS_OUTPUT.PUT_LINE('Error: El precio por caja debe ser un número positivo.');
            RETURN;
        END IF;

        IF p_fecha_compra IS NULL THEN
            DBMS_OUTPUT.PUT_LINE('Error: La fecha de compra es obligatoria.');
            RETURN;
        END IF;

        IF p_pago_id IS NULL OR LENGTH(p_pago_id) > 20 THEN
            DBMS_OUTPUT.PUT_LINE('Error: Verifique el ID del pago.');
            RETURN;
        END IF;

        UPDATE Compras
        SET IDPROVEEDOR = p_id_proveedor,
            IDPRODUCTO = p_id_producto,
            CANTIDADCAJAS = p_cantidad_cajas,
            PRECIOCAJA = p_precio_caja,
            FECHACOMPRA = p_fecha_compra,
            PAGOID = p_pago_id
        WHERE IDCOMPRA = p_id_compra;
        DBMS_OUTPUT.PUT_LINE('Compra modificada correctamente.');
    END ModificarCompra;

    PROCEDURE EliminarCompra(
    p_id_compra IN NUMBER
    ) IS
    BEGIN
        DELETE FROM Compras
        WHERE IDCOMPRA = p_id_compra;
        DBMS_OUTPUT.PUT_LINE('Compra eliminada correctamente.');
    END EliminarCompra;

END PKG_GestionCompras;

/
--------------------------------------------------------
--  DDL for Package Body PKG_GESTIONPRODUCTOS
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE PACKAGE BODY "NEGOCIO"."PKG_GESTIONPRODUCTOS" AS

    PROCEDURE InsertarProducto(
        p_id_producto IN VARCHAR2,
        p_id_categoria IN VARCHAR2,
        p_nombre_producto IN VARCHAR2
       ) IS
    BEGIN

        IF p_id_producto IS NULL OR LENGTH(p_id_producto) > 5 THEN
            DBMS_OUTPUT.PUT_LINE('Error: Verifique el ID del producto.');
            RETURN;
        END IF;

        IF p_id_categoria IS NULL OR LENGTH(p_id_categoria) > 3 THEN
            DBMS_OUTPUT.PUT_LINE('Error: Verifique el ID de la categoría.');
            RETURN;
        END IF;

        IF p_nombre_producto IS NULL OR LENGTH(p_nombre_producto) > 50 THEN
            DBMS_OUTPUT.PUT_LINE('Error: Verifique el nombre del producto.');
            RETURN;
        END IF;

        DECLARE
            v_categoriaexistente NUMBER;
        BEGIN
            SELECT COUNT(*)
            INTO v_categoriaexistente
            FROM Categorias
            WHERE IDCATEGORIA = p_id_categoria;

            IF v_categoriaexistente = 0 THEN
                DBMS_OUTPUT.PUT_LINE('Error: La categoría no es válida.');
                RETURN;
            END IF;
        END;


        INSERT INTO Productos (IDPRODUCTO, IDCATEGORIA, NOMBREPRODUCTO, PRECIOVENTA, CANTIDAD)
        VALUES (p_id_producto, p_id_categoria, p_nombre_producto, 0, 0);
        DBMS_OUTPUT.PUT_LINE('Producto insertado correctamente.');
    END InsertarProducto;

    PROCEDURE ModificarProducto(
        p_id_producto IN VARCHAR2,
        p_id_categoria IN VARCHAR2,
        p_nombre_producto IN VARCHAR2,
        p_precio_venta IN NUMBER,
        p_cantidad IN NUMBER
        ) IS
    BEGIN

        IF p_id_producto IS NULL OR LENGTH(p_id_producto) > 5 THEN
            DBMS_OUTPUT.PUT_LINE('Error: Verifique el ID del producto.');
            RETURN;
        END IF;

        IF p_id_categoria IS NULL OR LENGTH(p_id_categoria) > 3 THEN
            DBMS_OUTPUT.PUT_LINE('Error: Verifique el ID de la categoría.');
            RETURN;
        END IF;

        IF p_nombre_producto IS NULL OR LENGTH(p_nombre_producto) > 50 THEN
            DBMS_OUTPUT.PUT_LINE('Error: Verifique el nombre del producto.');
            RETURN;
        END IF;

        IF p_precio_venta <= 0 THEN
            DBMS_OUTPUT.PUT_LINE('Error: Verifique el precio de venta.');
            RETURN;
        END IF;

        IF p_cantidad <= 0 THEN
            DBMS_OUTPUT.PUT_LINE('Error: Verifique la cantidad del producto.');
            RETURN;
        END IF;

        DECLARE
            v_categoriaexistente NUMBER;
        BEGIN
            SELECT COUNT(*)
            INTO v_categoriaexistente
            FROM Categorias
            WHERE IDCATEGORIA = p_id_categoria;

            IF v_categoriaexistente = 0 THEN
                DBMS_OUTPUT.PUT_LINE('Error: La categoría no es válida.');
                RETURN;
            END IF;
        END;

        -- Validar existencia del producto
        DECLARE 
            v_productoexistente NUMBER; 
        BEGIN  
            SELECT COUNT(*)
            INTO v_productoexistente
            FROM Productos
            WHERE IDPRODUCTO = p_id_producto;

            IF v_productoexistente = 0 THEN 
                DBMS_OUTPUT.PUT_LINE('Error: El ID del producto no existe.');
                RETURN;
            END IF; 
        END; 

        -- Actualización de datos
        UPDATE Productos
        SET IDCATEGORIA = p_id_categoria,
            NOMBREPRODUCTO = p_nombre_producto,
            PRECIOVENTA = p_precio_venta,
            CANTIDAD = p_cantidad
        WHERE IDPRODUCTO = p_id_producto;
        DBMS_OUTPUT.PUT_LINE('Producto modificado correctamente.');
    END ModificarProducto;

    PROCEDURE EliminarProducto(p_id_producto IN VARCHAR2) IS
    BEGIN

        DECLARE 
            v_productoexistente NUMBER; 
        BEGIN  
            SELECT COUNT(*)
            INTO v_productoexistente
            FROM Productos
            WHERE IDPRODUCTO = p_id_producto;

            IF v_productoexistente = 0 THEN 
                DBMS_OUTPUT.PUT_LINE('Error: El ID del producto no existe.');
                RETURN;
            END IF; 
        END; 

        DELETE FROM Productos
        WHERE IDPRODUCTO = p_id_producto;
        DBMS_OUTPUT.PUT_LINE('Producto eliminado correctamente.');
    END EliminarProducto;

END PKG_GestionProductos;

/
--------------------------------------------------------
--  DDL for Package Body PKG_GESTIONPROVEEDOR
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE PACKAGE BODY "NEGOCIO"."PKG_GESTIONPROVEEDOR" AS

    PROCEDURE InsertarProveedor(
        p_id_proveedor IN NUMBER,
        p_tipo_id IN VARCHAR2,
        p_nombre1 IN VARCHAR2,
        p_nombre2 IN VARCHAR2,
        p_apellido1 IN VARCHAR2,
        p_apellido2 IN VARCHAR2,
        p_telefono IN NUMBER,
        p_email IN VARCHAR2
        ) IS 
        BEGIN

            IF  LENGTH(p_id_proveedor) > 15 OR LENGTH(p_id_proveedor) < 5 THEN 
                DBMS_OUTPUT.PUT_LINE('Error: Verifique el numero de identificacion.');
                RETURN;
            END IF;
            IF LENGTH(p_nombre1) > 15 OR LENGTH(p_nombre1) < 3 THEN 
                DBMS_OUTPUT.PUT_LINE('Error: Verifique el nombre.');
                RETURN;
            END IF; 
            IF LENGTH(p_apellido1) > 15 OR LENGTH(p_apellido1) < 3 THEN
                DBMS_OUTPUT.PUT_LINE('Error: Primer apellido es obligatorio.');
                RETURN;
            END IF; 
            IF LENGTH(p_telefono) > 10 OR p_telefono IS NULL THEN 
                DBMS_OUTPUT.PUT_LINE('Error: Verifique el telefono.');
                RETURN;
            END IF; 

            DECLARE
                v_tipoid NUMBER;
            BEGIN
                SELECT COUNT(*)
                INTO v_tipoid
                FROM TipoID
                WHERE idtipo = p_tipo_id; 

                IF v_tipoid = 0 THEN 
                     DBMS_OUTPUT.PUT_LINE('Error: El tipo id debe ser valido.');
                     RETURN;
                END IF; 
            END; 

            INSERT INTO Proveedores(IDProveedor, TipoID, Nombre1, Nombre2, Apellido1, Apellido2, Telefono, Email)
            VALUES(p_id_proveedor, p_tipo_id, p_nombre1, p_nombre2, p_apellido1, p_apellido2, p_telefono, p_email);
            DBMS_OUTPUT.PUT_LINE('El proveedor se ha agregado correctamente.');

END InsertarProveedor;

PROCEDURE ModificarProveedor(
        p_id_proveedor IN NUMBER,
        p_tipo_id IN VARCHAR2,
        p_nombre1 IN VARCHAR2,
        p_nombre2 IN VARCHAR2,
        p_apellido1 IN VARCHAR2,
        p_apellido2 IN VARCHAR2,
        p_telefono IN NUMBER,
        p_email IN VARCHAR2
        ) IS 
        BEGIN 

            IF p_id_proveedor IS NULL OR LENGTH(TO_CHAR(p_id_proveedor)) > 15 OR LENGTH(TO_CHAR(p_id_proveedor)) < 5 THEN 
                DBMS_OUTPUT.PUT_LINE('Error: Verifique el numero de identificacion.'); 
                RETURN; 
            END IF;
            IF LENGTH(p_nombre1) > 15 OR LENGTH(p_nombre1) < 3 THEN 
                DBMS_OUTPUT.PUT_LINE('Error: Verifique el nombre.');
                RETURN;
            END IF; 
            IF LENGTH(p_apellido1) > 15 OR LENGTH(p_apellido1) < 3 THEN
                DBMS_OUTPUT.PUT_LINE('Error: Primer apellido es obligatorio.');
                RETURN;
            END IF; 
            IF LENGTH(TO_CHAR(p_telefono)) > 10 OR p_telefono IS NULL THEN 
                DBMS_OUTPUT.PUT_LINE('Error: Verifique el telefono.');
                RETURN;
            END IF; 

            DECLARE
                v_tipoid NUMBER;
            BEGIN
                SELECT COUNT(*)
                INTO v_tipoid
                FROM TipoID
                WHERE idtipo = p_tipo_id; 

                IF v_tipoid = 0 THEN 
                     DBMS_OUTPUT.PUT_LINE('Error: El tipo id debe ser valido.');
                     RETURN;
                END IF; 
            END;

            DECLARE 
                v_idproveedororiginal NUMBER; 
            BEGIN  
                SELECT IDProveedor
                INTO v_idproveedororiginal
                FROM Proveedores
                WHERE IDProveedor = p_id_proveedor;

                IF v_idproveedororiginal != p_id_proveedor THEN 
                     DBMS_OUTPUT.PUT_LINE('Error: El numero de identificacion no existe en la base de datos.');
                     RETURN;
                END IF; 
            END; 

            UPDATE Proveedores
            SET TipoID = p_tipo_id,
                Nombre1 = p_nombre1,
                Nombre2 = p_nombre2,
                Apellido1 = p_apellido1,
                Apellido2 = p_apellido2,
                Telefono = p_telefono,
                Email = p_email
            WHERE IDProveedor = p_id_proveedor; 
            DBMS_OUTPUT.PUT_LINE('El proveedor se ha modificado correctamente.');

END ModificarProveedor; 

PROCEDURE EliminarProveedor(
        p_id_proveedor IN NUMBER
        )IS 
        BEGIN
            DELETE FROM Proveedores
            WHERE IDProveedor = p_id_proveedor; 
             DBMS_OUTPUT.PUT_LINE('El proveedor se ha eliminado correctamente.');
END EliminarProveedor; 

END PKG_GestionProveedor;

/
--------------------------------------------------------
--  DDL for Package Body PKG_GESTIONVENTAS
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE PACKAGE BODY "NEGOCIO"."PKG_GESTIONVENTAS" AS

    PROCEDURE HacerVenta(
        p_id_producto IN VARCHAR2,
        p_cantidad IN NUMBER,
        p_nombre_cliente IN VARCHAR2,
        p_apellido_cliente IN VARCHAR2,
        p_monto IN NUMBER,
        p_id_metodo_pago IN VARCHAR2
        ) IS
        
        v_id_factura NUMBER;
        v_total_venta NUMBER;
        v_vueltos NUMBER;
        v_precio_libra NUMBER;
        v_cantidaddisponible NUMBER;
        v_metodopagoexistente NUMBER;

    BEGIN

        IF p_cantidad <= 0 THEN 
            DBMS_OUTPUT.PUT_LINE('Error: La cantidad debe ser mayor que 0.'); 
            RETURN;
        END IF;

        BEGIN SELECT Cantidad, PrecioVenta 
        INTO v_cantidaddisponible, v_precio_libra 
        FROM Productos 
        WHERE IDProducto = p_id_producto; 
        EXCEPTION 
            WHEN NO_DATA_FOUND THEN 
            DBMS_OUTPUT.PUT_LINE('Error: El ID del producto no existe.'); 
            RETURN; 
        END;

         IF v_cantidaddisponible < p_cantidad THEN 
            DBMS_OUTPUT.PUT_LINE('Error: No hay suficiente cantidad.'); 
            RETURN; 
        END IF;

        v_total_venta := p_cantidad * v_precio_libra;

        IF p_monto < v_total_venta THEN 
            DBMS_OUTPUT.PUT_LINE('Error: El monto de pago no puede ser menor que el total de la venta.'); 
            RETURN; 
        END IF;

        v_vueltos := p_monto - v_total_venta;

        SELECT COUNT(*) 
        INTO v_metodopagoexistente 
        FROM MetodoPagos 
        WHERE IDPago = p_id_metodo_pago; 

        IF v_metodopagoexistente = 0 THEN 
            DBMS_OUTPUT.PUT_LINE('Error: El método de pago no existe.'); 
            RETURN; 
        END IF;

        INSERT INTO Facturas (IDFactura, IDPago, FechaFactura, Total, Monto, Vueltos) 
        VALUES (SEQ_Facturas.NEXTVAL, p_id_metodo_pago, SYSDATE, v_total_venta, p_monto,v_vueltos)
        RETURNING IDFactura INTO v_id_factura;

        INSERT INTO Ventas (IDVenta, IDProducto, CantidadLibras, PrecioLibra, NombreCliente, ApellidoCliente, IDFactura)
        VALUES (SEQ_Ventas.NEXTVAL, p_id_producto, p_cantidad, v_precio_libra, p_nombre_cliente, p_apellido_cliente, v_id_factura);

        DBMS_OUTPUT.PUT_LINE('Venta y factura generadas correctamente.');
    END HacerVenta;

END PKG_GestionVentas;

/
--------------------------------------------------------
--  Constraints for Table CATEGORIAS
--------------------------------------------------------

  ALTER TABLE "NEGOCIO"."CATEGORIAS" ADD CONSTRAINT "PK_CATEGORIAS_IDCATEGORIA" PRIMARY KEY ("IDCATEGORIA")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA"  ENABLE;
--------------------------------------------------------
--  Constraints for Table COMPRAS
--------------------------------------------------------

  ALTER TABLE "NEGOCIO"."COMPRAS" MODIFY ("CANTIDADCAJAS" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."COMPRAS" MODIFY ("PRECIOCAJA" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."COMPRAS" MODIFY ("FECHACOMPRA" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."COMPRAS" ADD CONSTRAINT "PK_COMPRAS_IDCOMPRA" PRIMARY KEY ("IDCOMPRA")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA"  ENABLE;
--------------------------------------------------------
--  Constraints for Table FACTURAS
--------------------------------------------------------

  ALTER TABLE "NEGOCIO"."FACTURAS" MODIFY ("FECHAFACTURA" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."FACTURAS" MODIFY ("TOTAL" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."FACTURAS" MODIFY ("MONTO" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."FACTURAS" MODIFY ("VUELTOS" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."FACTURAS" ADD CONSTRAINT "PK_FACTURAS_IDFACTURA" PRIMARY KEY ("IDFACTURA")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA"  ENABLE;
--------------------------------------------------------
--  Constraints for Table METODOPAGOS
--------------------------------------------------------

  ALTER TABLE "NEGOCIO"."METODOPAGOS" ADD CONSTRAINT "PK_METODOPAGOS_IDPAGO" PRIMARY KEY ("IDPAGO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA"  ENABLE;
--------------------------------------------------------
--  Constraints for Table PRODUCTOS
--------------------------------------------------------

  ALTER TABLE "NEGOCIO"."PRODUCTOS" MODIFY ("NOMBREPRODUCTO" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."PRODUCTOS" MODIFY ("PRECIOVENTA" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."PRODUCTOS" MODIFY ("CANTIDAD" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."PRODUCTOS" ADD CONSTRAINT "PK_PRODUCTOS_IDPRODUCTO" PRIMARY KEY ("IDPRODUCTO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA"  ENABLE;
--------------------------------------------------------
--  Constraints for Table PROVEEDORES
--------------------------------------------------------

  ALTER TABLE "NEGOCIO"."PROVEEDORES" MODIFY ("NOMBRE1" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."PROVEEDORES" MODIFY ("APELLIDO1" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."PROVEEDORES" MODIFY ("TELEFONO" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."PROVEEDORES" ADD CONSTRAINT "PK_PROVEEDORES_IDPROVEEDOR" PRIMARY KEY ("IDPROVEEDOR")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA"  ENABLE;
--------------------------------------------------------
--  Constraints for Table TIPOID
--------------------------------------------------------

  ALTER TABLE "NEGOCIO"."TIPOID" ADD CONSTRAINT "PK_TIPOID_IDTIPO" PRIMARY KEY ("IDTIPO")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA"  ENABLE;
--------------------------------------------------------
--  Constraints for Table VENTAS
--------------------------------------------------------

  ALTER TABLE "NEGOCIO"."VENTAS" MODIFY ("CANTIDADLIBRAS" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."VENTAS" MODIFY ("PRECIOLIBRA" NOT NULL ENABLE);
  ALTER TABLE "NEGOCIO"."VENTAS" ADD CONSTRAINT "PK_VENTAS_IDVENTA" PRIMARY KEY ("IDVENTA")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "PROYECTOAULA"  ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table COMPRAS
--------------------------------------------------------

  ALTER TABLE "NEGOCIO"."COMPRAS" ADD CONSTRAINT "FK_ID_PAGO" FOREIGN KEY ("PAGOID")
	  REFERENCES "NEGOCIO"."METODOPAGOS" ("IDPAGO") ENABLE;
  ALTER TABLE "NEGOCIO"."COMPRAS" ADD CONSTRAINT "FK_COMPRAS_IDPROVEDOR" FOREIGN KEY ("IDPROVEEDOR")
	  REFERENCES "NEGOCIO"."PROVEEDORES" ("IDPROVEEDOR") ENABLE;
  ALTER TABLE "NEGOCIO"."COMPRAS" ADD CONSTRAINT "FK_COMPRAS_IDPRODUCTOS" FOREIGN KEY ("IDPRODUCTO")
	  REFERENCES "NEGOCIO"."PRODUCTOS" ("IDPRODUCTO") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table FACTURAS
--------------------------------------------------------

  ALTER TABLE "NEGOCIO"."FACTURAS" ADD CONSTRAINT "FK_FACTURAS_IDPAGO" FOREIGN KEY ("IDPAGO")
	  REFERENCES "NEGOCIO"."METODOPAGOS" ("IDPAGO") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table PRODUCTOS
--------------------------------------------------------

  ALTER TABLE "NEGOCIO"."PRODUCTOS" ADD CONSTRAINT "FK_PRODUCTOS_IDCATEGORIA" FOREIGN KEY ("IDCATEGORIA")
	  REFERENCES "NEGOCIO"."CATEGORIAS" ("IDCATEGORIA") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table PROVEEDORES
--------------------------------------------------------

  ALTER TABLE "NEGOCIO"."PROVEEDORES" ADD CONSTRAINT "FK_PROVEEDORES_TIPOID" FOREIGN KEY ("TIPOID")
	  REFERENCES "NEGOCIO"."TIPOID" ("IDTIPO") ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table VENTAS
--------------------------------------------------------

  ALTER TABLE "NEGOCIO"."VENTAS" ADD CONSTRAINT "FK_VENTAS_IDPRODUCTOS" FOREIGN KEY ("IDPRODUCTO")
	  REFERENCES "NEGOCIO"."PRODUCTOS" ("IDPRODUCTO") ENABLE;
