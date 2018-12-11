# CyonRemake version 1.1.0.0 <br>
Los dos clientes se conectan al emulador pero no se envia el primer mensa Hello Conect (HC) al cliente por que falta armar la clase RealmThread
![alt text](https://raw.githubusercontent.com/XaferDev/CyonRemake/master/2.png)
Ejemplo de traduccion de la clase principal de java a c#
![alt text](https://raw.githubusercontent.com/XaferDev/CyonRemake/master/5.png)
Ejemplo de la clase RealmServer
![alt text](https://raw.githubusercontent.com/XaferDev/CyonRemake/master/6.png)

Este proyecto es la traduccion de codigo Java a C# del emulador de dofus Cyon
Aun esta en fase alpha (es muy nuevo)<br>
<br>
Actualmente el emulador:<br>
1.- Utiliza una clase Runtime como en java para que arranque la consola y no se cierre a menos que haya alguna excepcion lo puedes 
encontrar en Cyon\Cyon\Utils\Java<br>
2.- Carga un archivo de texto dentro de la carpeta Cyon\Cyon\bin\Debug el cual es CyonConfig, esta es la configuracion del servidor(aun no la edito)<br>
3.- Una vez cargada la configuracion, se establece la conexion con la base de datos MySql<br>
4.- Una vez conectada la base de datos, carga el mundo, el cual solo muestra el mensaje en la consola pero no carga nada, solo estan generadas las clases en Cyon\Cyon\common<br>
5.- Se cargan los sockets del servidor, permite conectar multiples clientes de dofus 1.29.1<br>
<br>
Aun falta mucho, empece el proyecto ayer (10/12/2018)<br>

____________________________________________________________________________________________________________________________________<br>
<br>
Google Traductor English<br>
<br>
# CyonRemake version 1.1.0.0
This project is the translation of Java code to C # of the Cyon dofus emulator
It is still in alpha phase (it is very new)<br>
<br>
Currently the emulator:<br>
1.- Use a Runtime class like java to start the console and not close unless there is an exception you can
find in Cyon \ Cyon \ Utils \ Java<br>
2.- Load a text file inside the folder Cyon \ Cyon \ bin \ Debug which is CyonConfig, this is the server configuration (I do not edit it yet)<br>
3.- Once the configuration is loaded, the connection with the MySql database is established<br>
4.- Once the database is connected, it loads the world, which only shows the message in the console but does not load anything, only the classes in Cyon \ Cyon \ common are generated<br>
5.- Server sockets are loaded, allows connecting multiple dofus clients 1.29.1<br>
<br>
Still missing a lot, I started the project yesterday (10/12/2018)<br>
