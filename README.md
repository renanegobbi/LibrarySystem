# Library System

<a href="https://github.com/renanegobbi/SistemaBiblioteca/edit/main/README.pt-BR.md">Leia esta página em Português</a> <img alt="English" src="https://user-images.githubusercontent.com/64235143/225525114-8e2210f2-915e-405d-9879-354d7a8dc78a.png" width="30" height="30"> 
:---------

Simple project of a library system, developed for the purpose of studying the functionalities of the .NET Framework 4.8 technology.

<h4 align="center"> 
  <a href="#Tools-and-technologies">Tools and technologies</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp; 
  <a href="#About-the-project">About the project</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#Demo">Demo</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  </br>
  <a href="#How-to-use">How to use</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#License">License</a>
</h4>

<br/>

<p align="center">
  <a href="https://opensource.org/licenses/MIT">
    <img src="https://img.shields.io/badge/License-MIT-blue.svg" alt="License MIT">
  </a>
</p>

<div id='Tools-and-technologies'/>

# Tools and technologies

The project was developed with the following tools and technologies:

- [Visual Studio 2019 Community](https://visualstudio.microsoft.com/vs/older-downloads/) - IDE used to develop the solution..
- [.Net Framework 4.8](https://dotnet.microsoft.com/pt-br/download/dotnet-framework/net48) - a development platform for creating applications for the web, Windows and Microsoft Azure.
- [Entity Framework](https://learn.microsoft.com/pt-br/ef/ef6/fundamentals/install) - object database mapper for .NET.
- [AutoMapper](https://automapper.org/) - library that resolves mapping from one object to another.
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/) -  .NET library for building validation rules.  

<div id='About-the-project'/>

# About the project

This project, for study purposes, allows you to list, consult, detail, register, change and delete both user and book. The loan screen allows you to list the status of each book loan to the user and track the history of the book's withdrawal and return date.

When running for the first time, if you do not create the database using the script.sql file, which is located inside the sql folder, Entity Framework will take care of creating the database and performing Seed Data (filling its tables with data initials).

The application was created thinking that the person who will make the loan will only be an employee (with or without administrator permission).

The system has authorization based on claims. Initially, the seed will be responsible for creating two employees in the AspNetUsers table, one with an Administrator profile, capable of viewing the registration and deletion buttons on the screens, and an employee without permission to register and delete.

Name | Password | Administrator Profile
:--------- | :------ | :-------:
func@email.com | Func@123 | no
admin@email.com | Admin@123 | yes

Below is the database diagram used in this project:

<p align="center">
  <img src="https://github.com/renanegobbi/SistemaBiblioteca/blob/main/docs/prints/banco_de_dados_diagrama_mssms.PNG"/>
</p>


# Demo

The figure below shows the visualization of the modal to loan a book to a user registered in the system.

<p align="center">
  <img src="https://github.com/renanegobbi/SistemaBiblioteca/blob/main/docs/prints/livro_popup_emprestimo.png"/>
</p>

The figure below illustrates the editing screen for the user belonging to the group of people who can make the loan.

<p align="center">
  <img src="https://github.com/renanegobbi/SistemaBiblioteca/blob/main/docs/prints/usuario_popup_edicao.png"/>
</p>

The figure below illustrates the list of loans, listing the loaned book to the user, as well as the date of collection and return of this book.

<p align="center">
  <img src="https://github.com/renanegobbi/SistemaBiblioteca/blob/main/docs/prints/emprestimos_lista.png"/>
</p>

# How to use

Clone the project:
```
git clone https://github.com/renanegobbi/SistemaBiblioteca.git
```         

After running the application, enter the following url to view in the browser:

NOTE:
* When running for the first time, if you do not find the path <em>... bin\roslyn\csc.exe</em>, run in the package manager console:
   <strong>Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r</strong>
* When run for the first time, it will create the database if it does not exist and populate the database tables, as described in the DatabaseInitializer.cs class.
* If you want to create the database manually, the script can be found in the <em>sql</em> folder of this solution.
```
https://localhost:44397/
```

# License
This project is under the MIT license.
