# Práctica Profesionalizante

Integrantes:

1. Nuñez Juan Ignacio
2. Arce Agurto Abril Mailen
3. Salcedo Emiliano
4. Agustin Nicolas Moguilevsky

*Objetivo*: Se quiere desarrollar una aplicación de administración de peluquería para ayudar a controlar de manera más efectiva sus turnos y clientes. 
La aplicación podría permitir al negocio registrar a los clientes, actualizar sus datos y darlos de baja si por alguna razón ya no desean usar los servicios de la peluquería. También permite a los clientes reservar turnos, modificarlos o cancelarlos. 
De esta manera, se permite reducir los errores y malentendidos que pueden surgir de una mala gestión y brindar una mejor experiencia al cliente.

## Alcance

### Funcionalidades alcanzadas dentro del proyecto

1. CRUD Clientes
2. CRUD Turnos
3. CRUD Peluqueros
4. CRUD Usuarios
5. CRUD Servicios
6. Alta usuarios
7. Baja de usuario
8. Login usuarios
9. Logout usuarios
10. Sign up Clientes
11. Baja de cliente
12. Login cliente
13. Logout cliente
14. Creación de Turno
15. Modificación de Turno
16. Eliminación de Turno
17. Alta de peluquero
18. Actualización de peluquero
19. Baja de peluquero
20. Visualizar turnos más solicitados
21. Visualizar Peluqueros más solicitados
22. Visualizar servicios más solicitados

### Funcionalidades fuera del alcance del proyecto
23. Actualización de cliente
24. Actualización de usuario
25. Visualizar frecuencia de clientes
26. Bloqueo de usuario
27. Desbloqueo de usuario
28. CRUD sedes
…

## Detalles de Funcionalidades

### CRUD (Turnos, Clientes, Peluqueros, Servicios)

El Sistema permitirá a los usuarios con distintos roles (Administrador, Cliente, Empleado), realizar las tareas de Creación, Lectura, Actualización y Eliminación desde una pantalla centralizada (Conceptualmente los manejadores, al cual le corresponde una pantalla a cada uno).
Los usuarios ingresarán al sistema mediante pantallas de autenticación que los dirigirán a la pantalla principal que les corresponda según su rol.
   1. Alta: Permitirá la creación de usuarios (sea desde la funcionalidad “Alta de usuario” o “Autoregistración de usuario”), cuentas cliente (desde lo que sería un “Sign up” del cliente, luego podrá loguearse desde un “Login”), peluqueros y turnos. El formulario contemplará la recepción de los campos (Nombre, Apellido, email, DNI, contraseña).
   2. Lectura (Obtención): La obtención de clientes, peluqueros y turnos soportará la obtención de listados sin la especificación de campos (filtros), o por medio del uso de filtros. En todos los casos devolverá todos los campos disponibles para cada entidad.
   3. Baja: Permitirá la eliminación de los registros de las distintas entidades.

### Visualizaciones

El sistema mostrará por pantalla al administrador, información sobre los usuarios mediante tablas y/o gráficos , tanto por los usuarios profesionales como por los usuarios de cliente.
Algunos de los ejemplos que se mostraran de los profesionales serían, la cantidad de turnos que realizaron, días con horarios disponibles para realizar turnos, servicios más solicitados, filtrado por servicio, turnos más solicitados . Por parte de los clientes se observaría el historial de turnos finalizados, de esta forma el administrador va a poder sacar conclusiones, comparativas, estadísticas sobre la efectividad de los profesionales, datos de su clientela, datos sobre qué servicio funciona mejor para su público, etc.

## Priorización

1. CRUD Clientes
2. CRUD Turnos
3. CRUD Peluqueros
4. CRUD Usuarios
5. CRUD Servicios
6. Alta usuarios
7. Baja de usuario
8. Login usuarios
9. Logout usuarios
10. Sign up Clientes
11. Baja de cliente
12. Login cliente
13. Logout cliente
14. Creación de Turno
15. Modificación de Turno
16. Eliminación de Turno
17. Alta de peluquero
18. Actualización de peluquero
19. Baja de peluquero
20. Visualizar turnos más solicitados
21. Visualizar Peluqueros más solicitados
22. Visualizar servicios más solicitados

## Validaciones

1. Cliente – Alta:
  1. Nombre: validación tipo de dato String.
  2. Apellido: validación tipo de dato String.
  3. Email: validación del tipo dirección de correo, que debe seguir una expresión regular del tipo <caracteresPermitidos>@<caracteresPermitidos>.<caracteresPermitidosDe2a5>
  4. Dni: validación del tipo de dato integer.
  5. Dirección: validación tipo de dato String.
  6. Teléfono: validación del tipo telefono, que debe seguir una expresión regular del tipo ^\d{10}$ 
  7. Contraseña: validación del tipo String, que debe seguir una expresión regular del tipo ^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$ (debe tener entre 8 y 16 caracteres, al menos un dígito, al menos una minúscula y al menos una mayúscula). NO puede tener otros símbolos.
2. Cliente - Baja
  1. Se muestran Nombre, Apellido, Email, DNI, Dirección, Teléfono. 
3. Cliente - Modificación
  1. Nombre: validación tipo de dato String.
  2. Apellido: validación tipo de dato String.
  3. Email: validación del tipo dirección de correo, que debe seguir una expresión regular del tipo <caracteresPermitidos>@<caracteresPermitidos>.<caracteresPermitidosDe2a5>
  4. Dni: validación del tipo de dato integer.
  5. Dirección: validación tipo de dato String.
  6. Teléfono: validación del tipo telefono, que debe seguir una expresión regular del tipo ^\d{10}$ 

## Pantallas

Para el rol de _CLIENTE_: 
Solo se debe poder ver el administrador de turnos.

Para el rol de _PELUQUERO_: 
Solo se deben poder ver el administrador de turnos.
Las opciones de visualizadores se explicaron anteriormente.
