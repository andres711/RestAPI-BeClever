# RestAPI-BeClever
<h1>Instrucciones para iniciar proyecto </h1>
<h3>APi REST realizada en c# en entorno .net version 6, utilizando como orm Entity Framework version 6 y gestor de base de datos SQL Server.</h3>
<ol>
<li>Desde terminal ejecutar comando dotnet restore</li>
<li>Configurar el string de conexion a la base de datos,en el archivo Program.cs, con credenciales propias </li>
<li>Desde terminal ejecutar comando dotnet run</li>
<li>Copiar desde terminal url host</li>
<li>Para crear la base de datos hacer una peticion get a urlhost/DBconection</li>
</ol>
<h4>
Endpoints disponibles:
Service 1 :[POST] urlHost/api/register \n
Service 2 :[GET] urlHost/api/search \n
Para probar los endpoint puede utlizar alguna herrmaineta como Postman o ThunderClient
</h4>
