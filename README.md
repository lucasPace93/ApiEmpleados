# ApiEmpleados
Primer Api



crear una api a la que pueda enviarle esta info:

User:
name : "..."
surname:"..."
identifier:"..." (tiene que validar que sea el unico usuario con ese identificador, como el dni)

type: "Boss" || "Employee" (2 unicos valores)

Sucursal: "Principal" (tiene que validar que el nombre de la sucursal exista, en esta primera version podria ser una lista en memoria)

Cuando la api recibe eso, retorna un mensaje de tipo 200 (elijo cual)


Tiene que disponibilizar los siguientes endpoints:

Post: .../Employees (guarda un empleado, con campos validos sino retorna un 400 Bad Request)

Delete: ../Employees (elimina un empleado)

Get:.../employees/:identifier (retorna un empleado por identificador)

Get;.../Employees (retorna todos los empleados)



AGREGAR CREACION DE DB PARA CLASE BRANCH
AGREGAR REQUEST PARA CLASE BRANCH
AGREGAR METODOS HTTP PARA CLASE BRANCH
AGREGAR VALIDACION DE EN LOS METODOS HTTP DE LA CLASE BRANCH PARA NOMBRE DE SUCURSALES 