# Sistema Biblioteca
Projeto simples de um sistema de biblioteca, desenvolvido para fins de estudo de funcionalidades da tecnologia .NET Framework 4.8.

<h4 align="center"> 
  <a href="#Tecnologias-e-ferramentas">Tecnologias e ferramentas</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp; 
  <a href="#Sobre-o-projeto">Sobre o projeto</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#Demonstração">Demonstração</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  </br>
  <a href="#Como-usar">Como usar</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href="#Licença">Licença</a>
</h4>

<br/>

<p align="center">
  <a href="https://opensource.org/licenses/MIT">
    <img src="https://img.shields.io/badge/License-MIT-blue.svg" alt="License MIT">
  </a>
</p>

<div id='Tecnologias-e-Ferramentas'/>

# Tecnologias e ferramentas 

O projeto foi desenvolvido com as seguintes tecnologias e ferramentas:

- [Visual Studio 2019 Community](https://visualstudio.microsoft.com/vs/older-downloads/) - IDE utilizada para desenvolver a solução.
- [.Net Framework 4.8](https://dotnet.microsoft.com/pt-br/download/dotnet-framework/net48) - uma plataforma de desenvolvimento para criar aplicativos para web, Windows e Microsoft Azure.
- [Entity Framework](https://learn.microsoft.com/pt-br/ef/ef6/fundamentals/install) - mapeador de banco de dados de objeto para .NET.
- [AutoMapper](https://automapper.org/) - biblioteca que resolve mapeamento de um objeto para outro.
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/) -  biblioteca .NET para construir regras de validação.      

<div id='Sobre-o-projeto'/>

# Sobre o projeto

Este projeto, para fins de estudo, permite listar, consultar, detalhar, cadastrar, alterar e deletar tanto usuário quanto livro. A tela de empréstimo permite listar a situação de cada empréstimo do livro ao usuário e acompanhar o histórico de data de retirada e devolução deste livro.    

Ao executar pela primeira vez, caso não crie o banco de dados pelo arquivo script.sql, que se encontra dentro da pasta sql, o Entity Framework se encarregará de criar o banco de dados e realizar o Seed Data (preenchimento de suas tabelas com dados iniciais).

A aplicação foi criada pensando que quem realizará o empréstimo será somente funcionário (com ou sem a permissão de administrador).

O sistema conta com autorização baseada em claims. Inicialmente, o seed se encarregará de criar dois funcionários na tabela AspNetUsers, um com perfil de Administrador, capaz de visualizar os botões de cadastro e exclução das telas, e um funcionário sem permissão para cadastrar e excluir. As claims que os usuários possuem estão na tabela AspNetUserClaims. A tabela abaixo mostra os dois funcionários criados pelo preenchimento dos dados iniciais.

Nome | Senha | Perfil Administrador | ClaimType | ClaimValue
:--------- | :------ | :-------: | :------ | :-------                                  
func@email.com | Func@123 | não | Funcionario | Ler,Atualizar
admin@email.com | Admin@123 | sim | Administrador | Ler,Adicionar,Atualizar,Excluir

Abaixo, está o diagrama do banco de dados utilizado neste projeto:

<p align="center">
  <img src="https://github.com/renanegobbi/SistemaBiblioteca/blob/main/docs/prints/banco_de_dados_diagrama_mssms.PNG"/>
</p>


# Demonstração

A figura abaixo mostra a visualização do modal para realizar o empréstimo de um livro a um usuário cadastrado no sistema.

<p align="center">
  <img src="https://github.com/renanegobbi/SistemaBiblioteca/blob/main/docs/prints/livro_popup_emprestimo.png"/>
</p>

A figura abaixo ilustra a tela de edição do usuário pertencente ao grupo de funcionários que poderão realizar os empréstimos.

<p align="center">
  <img src="https://github.com/renanegobbi/SistemaBiblioteca/blob/main/docs/prints/usuario_popup_edicao.png"/>
</p>

A figura abaixo ilustra a lista de empréstimos, relacionando ao usuário a descrição do livro emprestado, assim como a a data de retirada e devolução deste livro.

<p align="center">
  <img src="https://github.com/renanegobbi/SistemaBiblioteca/blob/main/docs/prints/emprestimos_lista.png"/>
</p>

# Como usar

Clonar o projeto:
```
git clone https://github.com/renanegobbi/SistemaBiblioteca.git
```         

Após executar a aplicação, insira a seguinte url para visualizar no browser:   
```
https://localhost:44397/
```
<strong>OBS:</strong>
* Ao executar pela primeira vez, caso a solução não encontre o caminho <em>... bin\roslyn\csc.exe</em>, executar no console do gerenciador de pacotes (Package Manager Console):
  <strong>Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r</strong>
* Ao executar pela primeira vez, criará o banco de dados, se o mesmo não existir, e populará as tabelas do banco de dados, conforme descrito na classe DatabaseInitializer.cs.
* Caso queira criar o banco de dados de forma manual, o script se encontra na pasta <em>sql</em> deste projeto.


# Licença
Este projeto está sob a licença do MIT. Consulte a [LICENÇA](https://github.com/TesteReteste/lim/blob/master/LICENSE) para obter mais informações.
