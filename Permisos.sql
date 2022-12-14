grant select ON ADMIN.USUARIO TO USERCHECK;
grant update(JWT) ON ADMIN.USUARIO TO USERCHECK;
grant select ON ADMIN.PERMISO TO USERCHECK;
grant CREATE SESSION TO USERCHECK;

GRANT CREATE SESSION TO CUSTODIAADMADM;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.USUARIO TO CUSTODIAADM;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.INVENTARIO_GENERAL TO CUSTODIAADM;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.LDEPARTAMENTO TO CUSTODIAADM;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.LDOCUMENTO TO CUSTODIAADM;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.LDESCRIPCION1 TO CUSTODIAADM;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.LESTADO TO CUSTODIAADM;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.INVENTARIO_ANTERIOR TO CUSTODIAADM;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.AREA TO CUSTODIAADM;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.INVENTARIO_HISTORICO TO CUSTODIAADM;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.TMP_CARRITO TO CUSTODIAADM;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.PAGARE TO CUSTODIAADM;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.PAGARE_HISTORICO TO CUSTODIAADM;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.SISGO_CUENTASACTIVAS TO CUSTODIAADM;

GRANT CREATE SESSION TO CUSTODIA1;
GRANT SELECT ON ADMIN.USUARIO TO CUSTODIA1;
GRANT SELECT ON ADMIN.PERMISO TO CUSTODIA1;
GRANT UPDATE(ID_AREA_FK) ON ADMIN.USUARIO TO CUSTODIA1;
GRANT UPDATE(CAMBIAR_PASSWORD) ON ADMIN.USUARIO TO CUSTODIA1;
GRANT UPDATE(ULTIMA_ACTIVIDAD) ON ADMIN.USUARIO TO CUSTODIA1;
GRANT UPDATE(JWT) ON ADMIN.USUARIO TO CUSTODIA1;
GRANT UPDATE(PASSWORDHASH) ON ADMIN.USUARIO TO CUSTODIA1;
GRANT UPDATE(PASSWORDSALT) ON ADMIN.USUARIO TO CUSTODIA1;
GRANT UPDATE(EMAIL) ON ADMIN.USUARIO TO CUSTODIA1;
GRANT SELECT, UPDATE, INSERT ON ADMIN.INVENTARIO_GENERAL TO CUSTODIA1;
GRANT SELECT ON ADMIN.LDEPARTAMENTO TO CUSTODIA1;
GRANT SELECT ON ADMIN.LDOCUMENTO TO CUSTODIA1;
GRANT SELECT ON ADMIN.LDESCRIPCION1 TO CUSTODIA1;
GRANT SELECT ON ADMIN.LESTADO TO CUSTODIA1;
GRANT SELECT, INSERT ON ADMIN.INVENTARIO_ANTERIOR TO CUSTODIA1;
GRANT SELECT ON ADMIN.AREA TO CUSTODIA1;
GRANT SELECT, UPDATE, INSERT ON ADMIN.INVENTARIO_HISTORICO TO CUSTODIA1;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.TMP_CARRITO TO CUSTODIA1;
GRANT SELECT, UPDATE, INSERT ON ADMIN.PAGARE TO CUSTODIA1;
GRANT SELECT, UPDATE, INSERT ON ADMIN.PAGARE_HISTORICO TO CUSTODIA1;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.SISGO_CUENTASACTIVAS TO CUSTODIA1;

GRANT CREATE SESSION TO CUSTODIA2;
GRANT SELECT ON ADMIN.USUARIO TO CUSTODIA2;
GRANT SELECT ON ADMIN.PERMISO TO CUSTODIA2;
GRANT UPDATE(ID_AREA_FK) ON ADMIN.USUARIO TO CUSTODIA2;
GRANT UPDATE(CAMBIAR_PASSWORD) ON ADMIN.USUARIO TO CUSTODIA2;
GRANT UPDATE(ULTIMA_ACTIVIDAD) ON ADMIN.USUARIO TO CUSTODIA2;
GRANT UPDATE(JWT) ON ADMIN.USUARIO TO CUSTODIA2;
GRANT UPDATE(PASSWORDHASH) ON ADMIN.USUARIO TO CUSTODIA2;
GRANT UPDATE(PASSWORDSALT) ON ADMIN.USUARIO TO CUSTODIA2;
GRANT UPDATE(EMAIL) ON ADMIN.USUARIO TO CUSTODIA2;
GRANT SELECT, UPDATE, INSERT ON ADMIN.INVENTARIO_GENERAL TO CUSTODIA2;
GRANT SELECT ON ADMIN.LDEPARTAMENTO TO CUSTODIA2;
GRANT SELECT ON ADMIN.LDOCUMENTO TO CUSTODIA2;
GRANT SELECT ON ADMIN.LDESCRIPCION1 TO CUSTODIA2;
GRANT SELECT ON ADMIN.LESTADO TO CUSTODIA2;
GRANT SELECT, INSERT ON ADMIN.INVENTARIO_ANTERIOR TO CUSTODIA2;
GRANT SELECT ON ADMIN.AREA TO CUSTODIA2;
GRANT SELECT, UPDATE, INSERT ON ADMIN.INVENTARIO_HISTORICO TO CUSTODIA2;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.TMP_CARRITO TO CUSTODIA2;
GRANT SELECT, UPDATE, INSERT ON ADMIN.PAGARE TO CUSTODIA2;
GRANT SELECT, UPDATE, INSERT ON ADMIN.PAGARE_HISTORICO TO CUSTODIA2;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.SISGO_CUENTASACTIVAS TO CUSTODIA2;

GRANT CREATE SESSION TO CUSTODIA3;
GRANT SELECT ON ADMIN.USUARIO TO CUSTODIA3;
GRANT SELECT ON ADMIN.PERMISO TO CUSTODIA3;
GRANT UPDATE(ID_AREA_FK) ON ADMIN.USUARIO TO CUSTODIA3;
GRANT UPDATE(CAMBIAR_PASSWORD) ON ADMIN.USUARIO TO CUSTODIA3;
GRANT UPDATE(ULTIMA_ACTIVIDAD) ON ADMIN.USUARIO TO CUSTODIA3;
GRANT UPDATE(JWT) ON ADMIN.USUARIO TO CUSTODIA3;
GRANT UPDATE(PASSWORDHASH) ON ADMIN.USUARIO TO CUSTODIA3;
GRANT UPDATE(PASSWORDSALT) ON ADMIN.USUARIO TO CUSTODIA3;
GRANT UPDATE(EMAIL) ON ADMIN.USUARIO TO CUSTODIA3;
GRANT SELECT, UPDATE, INSERT ON ADMIN.INVENTARIO_GENERAL TO CUSTODIA3;
GRANT SELECT ON ADMIN.LDEPARTAMENTO TO CUSTODIA3;
GRANT SELECT ON ADMIN.LDOCUMENTO TO CUSTODIA3;
GRANT SELECT ON ADMIN.LDESCRIPCION1 TO CUSTODIA3;
GRANT SELECT ON ADMIN.LESTADO TO CUSTODIA3;
GRANT SELECT, INSERT ON ADMIN.INVENTARIO_ANTERIOR TO CUSTODIA3;
GRANT SELECT ON ADMIN.AREA TO CUSTODIA3;
GRANT SELECT, UPDATE, INSERT ON ADMIN.INVENTARIO_HISTORICO TO CUSTODIA3;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.TMP_CARRITO TO CUSTODIA3;
GRANT SELECT, UPDATE, INSERT ON ADMIN.PAGARE TO CUSTODIA3;
GRANT SELECT, UPDATE, INSERT ON ADMIN.PAGARE_HISTORICO TO CUSTODIA3;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.SISGO_CUENTASACTIVAS TO CUSTODIA3;

GRANT CREATE SESSION TO DEFAULT1;
GRANT SELECT ON ADMIN.USUARIO TO DEFAULT1;
GRANT UPDATE(CAMBIAR_PASSWORD) ON ADMIN.USUARIO TO DEFAULT1;
GRANT UPDATE(ULTIMA_ACTIVIDAD) ON ADMIN.USUARIO TO DEFAULT1;
GRANT UPDATE(JWT) ON ADMIN.USUARIO TO DEFAULT1;
GRANT UPDATE(PASSWORDHASH) ON ADMIN.USUARIO TO DEFAULT1;
GRANT UPDATE(PASSWORDSALT) ON ADMIN.USUARIO TO DEFAULT1;
GRANT SELECT, UPDATE ON ADMIN.INVENTARIO_GENERAL TO DEFAULT1;
GRANT SELECT ON ADMIN.LDEPARTAMENTO TO DEFAULT1;
GRANT SELECT ON ADMIN.LDOCUMENTO TO DEFAULT1;
GRANT SELECT ON ADMIN.LDESCRIPCION1 TO DEFAULT1;
GRANT SELECT ON ADMIN.LESTADO TO DEFAULT1;
GRANT SELECT, INSERT ON ADMIN.INVENTARIO_ANTERIOR TO DEFAULT1;
GRANT SELECT ON ADMIN.AREA TO DEFAULT1;
GRANT SELECT, UPDATE, INSERT ON ADMIN.INVENTARIO_HISTORICO TO DEFAULT1;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.TMP_CARRITO TO DEFAULT1;
GRANT SELECT ON ADMIN.PAGARE TO DEFAULT1;
GRANT UPDATE(ID_USUARIO_POSEE) ON ADMIN.PAGARE TO DEFAULT1;
GRANT UPDATE(FECHA_POSEE) ON ADMIN.PAGARE TO DEFAULT1;
GRANT SELECT, INSERT ON ADMIN.PAGARE_HISTORICO TO DEFAULT1;
GRANT UPDATE(ID_USUARIO_ENTREGA_FK) ON ADMIN.PAGARE_HISTORICO TO DEFAULT1;
GRANT UPDATE(ID_USUARIO_RECIBE_FK) ON ADMIN.PAGARE_HISTORICO TO DEFAULT1;
GRANT UPDATE(FECHA_INICIO) ON ADMIN.PAGARE_HISTORICO TO DEFAULT1;
GRANT UPDATE(FECHA_FIN) ON ADMIN.PAGARE_HISTORICO TO DEFAULT1;
GRANT UPDATE(RECIBIDO) ON ADMIN.PAGARE_HISTORICO TO DEFAULT1;
GRANT UPDATE(OBSERVACION_ENTREGA) ON ADMIN.PAGARE_HISTORICO TO DEFAULT1;
GRANT UPDATE(OBSERVACION_RECIBE) ON ADMIN.PAGARE_HISTORICO TO DEFAULT1;

GRANT CREATE SESSION TO DEFAULT2;
GRANT SELECT ON ADMIN.USUARIO TO DEFAULT2;
GRANT UPDATE(CAMBIAR_PASSWORD) ON ADMIN.USUARIO TO DEFAULT2;
GRANT UPDATE(ULTIMA_ACTIVIDAD) ON ADMIN.USUARIO TO DEFAULT2;
GRANT UPDATE(JWT) ON ADMIN.USUARIO TO DEFAULT2;
GRANT UPDATE(PASSWORDHASH) ON ADMIN.USUARIO TO DEFAULT2;
GRANT UPDATE(PASSWORDSALT) ON ADMIN.USUARIO TO DEFAULT2;
GRANT SELECT, UPDATE ON ADMIN.INVENTARIO_GENERAL TO DEFAULT2;
GRANT SELECT ON ADMIN.LDEPARTAMENTO TO DEFAULT2;
GRANT SELECT ON ADMIN.LDOCUMENTO TO DEFAULT2;
GRANT SELECT ON ADMIN.LDESCRIPCION1 TO DEFAULT2;
GRANT SELECT ON ADMIN.LESTADO TO DEFAULT2;
GRANT SELECT, INSERT ON ADMIN.INVENTARIO_ANTERIOR TO DEFAULT2;
GRANT SELECT ON ADMIN.AREA TO DEFAULT2;
GRANT SELECT, UPDATE, INSERT ON ADMIN.INVENTARIO_HISTORICO TO DEFAULT2;
GRANT SELECT, UPDATE, INSERT, DELETE ON ADMIN.TMP_CARRITO TO DEFAULT2;
GRANT SELECT ON ADMIN.PAGARE TO DEFAULT2;
GRANT UPDATE(ID_USUARIO_POSEE) ON ADMIN.PAGARE TO DEFAULT2;
GRANT UPDATE(FECHA_POSEE) ON ADMIN.PAGARE TO DEFAULT2;
GRANT SELECT, INSERT ON ADMIN.PAGARE_HISTORICO TO DEFAULT2;
GRANT UPDATE(ID_USUARIO_ENTREGA_FK) ON ADMIN.PAGARE_HISTORICO TO DEFAULT2;
GRANT UPDATE(ID_USUARIO_RECIBE_FK) ON ADMIN.PAGARE_HISTORICO TO DEFAULT2;
GRANT UPDATE(FECHA_INICIO) ON ADMIN.PAGARE_HISTORICO TO DEFAULT2;
GRANT UPDATE(FECHA_FIN) ON ADMIN.PAGARE_HISTORICO TO DEFAULT2;
GRANT UPDATE(RECIBIDO) ON ADMIN.PAGARE_HISTORICO TO DEFAULT2;
GRANT UPDATE(OBSERVACION_ENTREGA) ON ADMIN.PAGARE_HISTORICO TO DEFAULT2;
GRANT UPDATE(OBSERVACION_RECIBE) ON ADMIN.PAGARE_HISTORICO TO DEFAULT2;

update usuario set connuser = 'SicaADM' where ID_USUARIO = 1;
update usuario set connuser = 'Custodia1' where ID_USUARIO = 61;
update usuario set connuser = 'Custodia2' where ID_USUARIO = 62;
update usuario set connuser = 'Custodia3' where ID_USUARIO = 63;
update usuario set connuser = 'Default1' where ID_USUARIO = 64;
update usuario set connuser = 'Default2' where ID_USUARIO = 65;

select * from USUARIO;
select * from INVENTARIO_GENERAL;
select * from INVENTARIO_HISTORICO;
select * from ARMAR_CAJA_HISTORICO;
select * from permiso;
update permiso set nivel = 1 where id_usuario_fk = 1;
delete permiso where id_usuario_fk = 3;
delete permiso where id_usuario_fk = 44;
delete usuario where id_usuario = 3;
delete usuario where id_usuario = 44;
truncate table inventario_general;
truncate table INVENTARIO_ANTERIOR;
truncate table INVENTARIO_historico;
truncate table Pagare;
truncate table Pagare_Historico;
select * from Area;

update usuario set cambiar_password = 1 where id_usuario = 61;
update usuario set nombre_usuario = 'RIESGO1' where id_usuario = 64;
update permiso set pagare_recibir = 0, pagare_entregar = 0 where id_usuario_fk = 65;

INSERT INTO USUARIO (NOMBRE_USUARIO, ID_AREA_FK, REAL, CAMBIAR_PASSWORD, ACCESO_PERMITIDO, ORDEN, CERRAR_SESION, DATAMANAGER, ULTIMA_ACTIVIDAD, JWT, PASSWORDHASH, PASSWORDSALT, EMAIL)
VALUES ('RIESGO1', 4, 1, 1, 1, 5, 0, 0, NULL, '', '', '', 'mail');
INSERT INTO USUARIO (NOMBRE_USUARIO, ID_AREA_FK, REAL, CAMBIAR_PASSWORD, ACCESO_PERMITIDO, ORDEN, CERRAR_SESION, DATAMANAGER, ULTIMA_ACTIVIDAD, JWT, PASSWORDHASH, PASSWORDSALT, EMAIL)
VALUES ('AGENCIA1', 5, 1, 1, 1, 5, 0, 0, NULL, '', '', '', 'mail');
INSERT INTO USUARIO (NOMBRE_USUARIO, ID_AREA_FK, REAL, CAMBIAR_PASSWORD, ACCESO_PERMITIDO, ORDEN, CERRAR_SESION, DATAMANAGER, ULTIMA_ACTIVIDAD, JWT, PASSWORDHASH, PASSWORDSALT, EMAIL)
VALUES ('CUSTODIA1', 1, 1, 1, 1, 5, 0, 0, NULL, '', '', '', 'mail');
INSERT INTO USUARIO (NOMBRE_USUARIO, ID_AREA_FK, REAL, CAMBIAR_PASSWORD, ACCESO_PERMITIDO, ORDEN, CERRAR_SESION, DATAMANAGER, ULTIMA_ACTIVIDAD, JWT, PASSWORDHASH, PASSWORDSALT, EMAIL)
VALUES ('CUSTODIA2', 1, 1, 1, 1, 10, 0, 0, NULL, '', '', '', 'mail');
INSERT INTO USUARIO (NOMBRE_USUARIO, ID_AREA_FK, REAL, CAMBIAR_PASSWORD, ACCESO_PERMITIDO, ORDEN, CERRAR_SESION, DATAMANAGER, ULTIMA_ACTIVIDAD, JWT, PASSWORDHASH, PASSWORDSALT, EMAIL)
VALUES ('CUSTODIA3', 1, 1, 1, 1, 15, 0, 0, NULL, '', '', '', 'mail');

update usuario set PASSWORDSALT = 'VVdXs1Mdp249LbwRKBZf61Bbt3jwmKfpOnUK2QbrXycpStrKvKuAAWBYB0cCtHDnuigReDNYYuNedjbA30okhC/eYm0esGoF3MPY0nF0TTM9EeJFJ2dx4hXZWKTEgQTQv7xNSLyLqEBQX/DExtypFEdp6/54WA0Q43eNhVz7dzQ=',
PASSWORDHASH = 'Fo42qRwTc3rzWMuDDtynaglThlT3pdkNm9FpeiMogGDeEVyk1201dpggPVdNLBLM9K3S5+Z3dnnKot+jtchs4w==' where ID_USUARIO = 65;

INSERT INTO PERMISO (ID_USUARIO_FK, BUSQUEDA, BUSQUEDA_HISTORICO, BUSQUEDA_EDITAR, ENTREGAR, ENTREGAR_EXPEDIENTE, ENTREGAR_DOCUMENTO, RECIBIR, RECIBIR_NUEVO, RECIBIR_REINGRESO, RECIBIR_CONFIRMAR, RECIBIR_MANUAL, PAGARE, PAGARE_BUSCAR, PAGARE_RECIBIR, PAGARE_ENTREGAR, LETRA, LETRA_NUEVO, LETRA_ENTREGAR, LETRA_REINGRESO, LETRA_BUSCAR, IRONMOUNTAIN, IRONMOUNTAIN_SOLICITAR, IRONMOUNTAIN_RECIBIR, IRONMOUNTAIN_ARMAR, IRONMOUNTAIN_ENVIAR, IRONMOUNTAIN_ENTREGAR, IRONMOUNTAIN_CARGO, BOVEDA, BOVEDA_CAJA_RETIRAR, BOVEDA_CAJA_GUARDAR, BOVEDA_DOCUMENTO_RETIRAR, BOVEDA_DOCUMENTO_GUARDAR, MANTENIMIENTO, IMPORTAR, IMPORTAR_ACTIVAS, IMPORTAR_PASIVAS, NIVEL)
VALUES (65, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3);
update usuario set orden = 10 where id_usuario = 62;
INSERT INTO PERMISO (ID_USUARIO_FK, BUSQUEDA, BUSQUEDA_HISTORICO, BUSQUEDA_EDITAR, ENTREGAR, ENTREGAR_EXPEDIENTE, ENTREGAR_DOCUMENTO, RECIBIR, RECIBIR_NUEVO, RECIBIR_REINGRESO, RECIBIR_CONFIRMAR, RECIBIR_MANUAL, PAGARE, PAGARE_BUSCAR, PAGARE_RECIBIR, PAGARE_ENTREGAR, LETRA, LETRA_NUEVO, LETRA_ENTREGAR, LETRA_REINGRESO, LETRA_BUSCAR, IRONMOUNTAIN, IRONMOUNTAIN_SOLICITAR, IRONMOUNTAIN_RECIBIR, IRONMOUNTAIN_ARMAR, IRONMOUNTAIN_ENVIAR, IRONMOUNTAIN_ENTREGAR, IRONMOUNTAIN_CARGO, BOVEDA, BOVEDA_CAJA_RETIRAR, BOVEDA_CAJA_GUARDAR, BOVEDA_DOCUMENTO_RETIRAR, BOVEDA_DOCUMENTO_GUARDAR, MANTENIMIENTO, IMPORTAR, IMPORTAR_ACTIVAS, IMPORTAR_PASIVAS, NIVEL)
VALUES (63, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 2);

grant CREATE SESSION TO CAJERO;

REVOKE select, update, insert, delete ON INVENTARIO_GENERAL FROM USERCHECK;