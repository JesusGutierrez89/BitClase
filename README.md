📚 Sistema de Gestión de Aulas para Instituto (C# - WinForms)
Este proyecto fue desarrollado en C# utilizando Visual Studio con el objetivo de simular un sistema de gestión de aulas para un instituto ficticio. A través de una aplicación de escritorio (Windows Forms), tanto profesores como administradores pueden gestionar aspectos clave como la asistencia del alumnado y el material disponible en las aulas.

🎯 Objetivo del Proyecto
Facilitar a los profesores de un instituto ficticio el acceso a un sistema en el cual puedan:

Registrarse usando su NRP (Número de Registro Personal).

Completar su información personal mediante un formulario de registro (nombre, apellidos, contraseña).

Iniciar sesión con una contraseña que se almacena encriptada en la base de datos para garantizar la seguridad.

Acceder al sistema y gestionar las aulas, distribuidas en diferentes plantas de un pabellón.

Controlar la asistencia de los alumnos, el uso de material propio o del aula.

Registrar los datos de asistencia y materiales por alumno.

Exportar los registros en formatos Excel y JSON.

Guardar toda la información en la base de datos asociada al profesor.

👨‍🏫 Funcionalidades para Profesores
Registro con NRP.

Inicio de sesión seguro (contraseña cifrada).

Visualización y acceso a aulas por planta.

Gestión de asistencia diaria por alumno y mesa.

Registro del material utilizado (personal o del aula).

Exportación de datos a Excel y JSON.

Guardado automático en base de datos.

🛠️ Funcionalidades para Administradores
Mediante un formulario exclusivo, los administradores pueden:

Modificar los materiales disponibles en cada aula.

Editar las descripciones de los periféricos:

Pantallas

Teclados

Ratones

🧰 Tecnologías Utilizadas
Lenguaje: C#

IDE: Visual Studio

Framework: Windows Forms (WinForms)

Base de datos: SQL Server

Exportación de archivos: Excel (.xlsx) y JSON (.json)

Seguridad: Hashing/encriptación de contraseñas

📁 Estructura del Proyecto
![Captura de pantalla 2025-05-22 131458](https://github.com/user-attachments/assets/8219b962-1414-40e4-8793-0b8e7dc90729)


🔐 Seguridad
Las contraseñas de los profesores se almacenan encriptadas en la base de datos, impidiendo su visualización directa y asegurando una autenticación segura.

📦 Futuras Mejoras (Ideas)
Implementar roles con más granularidad (coordinadores, dirección, etc.).

Incorporar autenticación por token o 2FA.

Mejora en interfaz visual con tecnologías modernas como WPF.

Acceso remoto o multiplataforma mediante migración a app web.

📌 Requisitos
Visual Studio 2019 o superior

.NET Framework instalado

SQL Server (LocalDB o servidor completo)

Biblioteca para manejo de Excel (por ejemplo: EPPlus o ClosedXML)

🧑‍💻 Autor
Proyecto desarrollado con fines académicos para la gestión de aulas, asistencia y materiales de un instituto ficticio.
