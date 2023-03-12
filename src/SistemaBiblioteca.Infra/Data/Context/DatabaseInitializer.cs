using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SistemaBiblioteca.Business.Models.Emprestimos;
using SistemaBiblioteca.Business.Models.Livros;
using SistemaBiblioteca.Business.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SistemaBiblioteca.Infra.Data.Context
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<SistemaBibliotecaContext>
    {
        protected override void Seed(SistemaBibliotecaContext context)
        {
            //1 - Usuários
            IList<Usuario> usuarios = new List<Usuario>();

            var id_usuario_1 = Guid.NewGuid();
            var id_usuario_2 = Guid.NewGuid();
            var id_usuario_3 = Guid.NewGuid();
            var id_usuario_4 = Guid.NewGuid();
            var id_usuario_5 = Guid.NewGuid();
            var id_usuario_6 = Guid.NewGuid();
            var id_usuario_7 = Guid.NewGuid();
            var id_usuario_8 = Guid.NewGuid();
            var id_usuario_9 = Guid.NewGuid();
            var id_usuario_10 = Guid.NewGuid();
            var id_usuario_11 = Guid.NewGuid();
            var id_usuario_12 = Guid.NewGuid();

            usuarios.Add(new Usuario() { Id = id_usuario_1, Cpf = "13490372069", Nome = "João Silva" });
            usuarios.Add(new Usuario() { Id = id_usuario_3, Cpf = "56991398004", Nome = "Ronaldo Kuster" });
            usuarios.Add(new Usuario() { Id = id_usuario_4, Cpf = "75037919002", Nome = "Flavio Amaro" });
            usuarios.Add(new Usuario() { Id = id_usuario_2, Cpf = "10878482024", Nome = "Alberto Celestino" });
            usuarios.Add(new Usuario() { Id = id_usuario_5, Cpf = "52443660095", Nome = "Higor Albor" });
            usuarios.Add(new Usuario() { Id = id_usuario_6, Cpf = "40002863405", Nome = "Fabiano Moura" });
            usuarios.Add(new Usuario() { Id = id_usuario_7, Cpf = "35446468465", Nome = "Vinícius Barbosa" });
            usuarios.Add(new Usuario() { Id = id_usuario_8, Cpf = "08505584414", Nome = "Eliana Yamada" });
            usuarios.Add(new Usuario() { Id = id_usuario_9, Cpf = "31680717499", Nome = "Vânia Meireles" });
            usuarios.Add(new Usuario() { Id = id_usuario_10, Cpf = "97034954437", Nome = "Gisele Fagundes" });
            usuarios.Add(new Usuario() { Id = id_usuario_11, Cpf = "56492088409", Nome = "Bárbara Rodrigues" });
            usuarios.Add(new Usuario() { Id = id_usuario_12, Cpf = "29281994461", Nome = "Osmar Branco" });

            context.Usuarios.AddRange(usuarios);


            //2 - Endereços
            IList<Endereco> enderecos = new List<Endereco>();

            enderecos.Add(new Endereco() { Id = id_usuario_1, Cep = "57073444", Numero = "10000", Logradouro = "Quadra D0", Complemento = "Lot Cascadura", Cidade = "Maceió", Bairro = "Cidade Universitária", Estado = "AL" });
            enderecos.Add(new Endereco() { Id = id_usuario_3, Cep = "78144750", Numero = "20000", Logradouro = "Rua Desembargador Simão Aureliano de Barros Filho", Complemento = "Lot Jd Petrópolis", Cidade = "Várzea Grande", Bairro = "Petrópolis", Estado = "MT" });
            enderecos.Add(new Endereco() { Id = id_usuario_4, Cep = "57040187", Numero = "30000", Logradouro = "Travessa Nogueira", Complemento = "Cj Luiz Pedro V", Cidade = "Maceió", Bairro = "Cidade Universitária", Estado = "AL" });
            enderecos.Add(new Endereco() { Id = id_usuario_2, Cep = "57057370", Numero = "40000", Logradouro = "Rua José Maria dos Santos", Complemento = "Cj Monte Alegre", Cidade = "Maceió", Bairro = "Pinheiro", Estado = "AL" });
            enderecos.Add(new Endereco() { Id = id_usuario_5, Cep = "57304000", Numero = "50000", Logradouro = "Rua Paulo Afonso", Complemento = "de 71 a 587 - lado ímpar", Cidade = "Arapiraca", Bairro = "Primavera", Estado = "AL" });
            enderecos.Add(new Endereco() { Id = id_usuario_6, Cep = "57082382", Numero = "60000", Logradouro = "Rua Carteiro José Florentino", Complemento = "Praça 7", Cidade = "Maceió", Bairro = "Santa Lúcia", Estado = "AL" });
            enderecos.Add(new Endereco() { Id = id_usuario_7, Cep = "57030170", Numero = "70000", Logradouro = "Avenida Doutor Antônio Gouveia", Complemento = "Estátua do Governador", Cidade = "Maceió", Bairro = "Pajuçara", Estado = "AL" });
            enderecos.Add(new Endereco() { Id = id_usuario_8, Cep = "57315109", Numero = "80000", Logradouro = "Rua Maria Sampaio da Silva", Complemento = "Praça Mauá", Cidade = "Arapiraca", Bairro = "Senador Arnon de Melo", Estado = "AL" });
            enderecos.Add(new Endereco() { Id = id_usuario_9, Cep = "57303739", Numero = "90000", Logradouro = "Rua Adalberto Ferreira da Silva", Complemento = "Praça do Relógio", Cidade = "Arapiraca", Bairro = "Guaribas", Estado = "AL" });
            enderecos.Add(new Endereco() { Id = id_usuario_10, Cep = "57071340", Numero = "10000", Logradouro = "Rua Eronildes de Oliveira", Complemento = "Parque da Cidade", Cidade = "Maceió", Bairro = "Clima Bom", Estado = "AL" });
            enderecos.Add(new Endereco() { Id = id_usuario_11, Cep = "57075045", Numero = "11000", Logradouro = "Rua Santa Rosa", Complemento = "Parque Horto", Cidade = "Maceió", Bairro = "Santos Dumont", Estado = "AL" });
            enderecos.Add(new Endereco() { Id = id_usuario_12, Cep = "57039520", Numero = "12000", Logradouro = "Rua Antônio Felinto", Complemento = "Universidade", Cidade = "Maceió", Bairro = "Riacho Doce", Estado = "AL" });

            context.Enderecos.AddRange(enderecos);

            //3 -Livros
            IList<Livro> livros = new List<Livro>();

            var id_livro_1 = Guid.NewGuid();
            var id_livro_2 = Guid.NewGuid();
            var id_livro_3 = Guid.NewGuid();
            var id_livro_4 = Guid.NewGuid();
            var id_livro_5 = Guid.NewGuid();
            var id_livro_6 = Guid.NewGuid();

            var guid_livro_1 = new Guid("8F1139FD-37DF-41D9-A21C-80EC214D3B75");
            var guid_livro_2 = new Guid("0283C6C0-9F6B-42A6-BFFD-BAC1C7BAC4A4");
            var guid_livro_3 = new Guid("C8F0E891-BED5-43ED-9AAE-28C17C28A8FB");
            var guid_livro_4 = new Guid("9DC7068D-AB05-4E9D-BD90-805DAEDE65D8");
            var guid_livro_5 = new Guid("09303E33-5F0D-4F9B-A5AF-48D6B1BC83F7");
            var guid_livro_6 = new Guid("AC8B9091-DC10-45AD-A27C-405FBE2E4826");

            livros.Add(new Livro() { Id = id_livro_1, Imagem = guid_livro_1.ToString() + "_CleanCode.jpg", Titulo = "Clean Code", Descricao = "Clean Code ou código limpo se refere a um conjunto de boas práticas na escrita de software que você pode aplicar para obter uma maior legibilidade e manutenabilidade do seu código.", Editora = "Pearson", DataCadastro = DateTime.Now, AnoPublicacao = new DateTime(2008, 08, 01, 0, 0, 0) });
            livros.Add(new Livro() { Id = id_livro_2, Imagem = guid_livro_2.ToString() + "_DomainDrivenDesign.jpg", Titulo = "Domain-Driven Design: Tackling Complexity in the Heart of Software (English Edition)", Descricao = "O Domain-Driven Design preenche essa necessidade. Este não é um livro sobre tecnologias específicas. Ele oferece aos leitores uma abordagem sistemática do design orientado por domínio, apresentando um amplo conjunto de melhores práticas de design, técnicas baseadas em experiência e princípios fundamentais que facilitam o desenvolvimento de projetos de software voltados para domínios complexos.", Editora = "Addison-Wesley Professional", DataCadastro = DateTime.Now, AnoPublicacao = new DateTime(2003, 08, 22, 0, 0, 0) });
            livros.Add(new Livro() { Id = id_livro_3, Imagem = guid_livro_3.ToString() + "_PatternsOfEnterprise.jpg", Titulo = "Patterns of Enterprise Application Architecture", Descricao = "A prática de desenvolvimento de aplicativos corporativos se beneficiou do surgimento de muitas novas tecnologias facilitadoras. Plataformas orientadas a objetos multicamadas, como Java e .NET, tornaram-se comuns. Essas novas ferramentas e tecnologias são capazes de criar aplicativos poderosos, mas não são facilmente implementadas. Falhas comuns em aplicativos corporativos geralmente ocorrem porque seus desenvolvedores não entendem as lições de arquitetura que os desenvolvedores de objetos experientes aprenderam. Padrões de Arquitetura de Aplicativo Corporativofoi escrito em resposta direta aos rígidos desafios enfrentados pelos desenvolvedores de aplicativos corporativos.", Editora = "Addison-Wesley Professional", DataCadastro = DateTime.Now, AnoPublicacao = new DateTime(2002, 11, 15, 0, 0, 0) });
            livros.Add(new Livro() { Id = id_livro_4, Imagem = guid_livro_4.ToString() + "_DesignPatterns.jpg", Titulo = "Design Patterns", Descricao = "Os padrões permitem que os designers criem designs mais flexíveis, elegantes e reutilizáveis, sem ter que redescobrir as próprias soluções de design. Altamente influente, Design Patterns é um clássico moderno que apresenta o que são os padrões e como eles podem ajudá-lo a projetar software orientado a objetos e fornece um catálogo de soluções simples para aqueles que já programam em pelo menos uma linguagem de programação orientada a objetos.", Editora = "Profissional Addison-Wesley", DataCadastro = DateTime.Now, AnoPublicacao = new DateTime(1994, 10, 31, 0, 0, 0) });
            livros.Add(new Livro() { Id = id_livro_5, Imagem = guid_livro_5.ToString() + "_Refactoring.jpg", Titulo = "Refactoring: Improving the Design of Existing Code", Descricao = "A refatoração melhora o design do código existente e aumenta a capacidade de manutenção do software, além de tornar o código existente mais fácil de entender. O signatário original do Manifesto Ágil e líder em desenvolvimento de software, Martin Fowler, fornece um catálogo de refatorações que explica por que você deve refatorar; como reconhecer código que precisa de refatoração; e como realmente fazê-lo com sucesso, não importa o idioma que você usa.", Editora = "Profissional Addison-Wesley", DataCadastro = DateTime.Now, AnoPublicacao = new DateTime(2018, 11, 20, 0, 0, 0) });
            livros.Add(new Livro() { Id = id_livro_6, Imagem = guid_livro_6.ToString() + "_CleanArchitecture.jpg", Titulo = "Clean Architecture: A Craftsman's Guide to Software Structure and Design", Descricao = "Martin's Clean Architecture não apresenta apenas opções. Baseando-se em mais de meio século de experiência em ambientes de software de todos os tipos imagináveis, Martin diz quais escolhas fazer e por que elas são críticas para o seu sucesso. Como você espera do tio Bob, este livro está repleto de soluções diretas e objetivas para os desafios reais que você enfrentará - aqueles que farão ou destruirão seus projetos.", Editora = "Pearson", DataCadastro = DateTime.Now, AnoPublicacao = new DateTime(2017, 12, 12, 0, 0, 0) });

            context.Livros.AddRange(livros);


            //4 - Empréstimos
            IList<Emprestimo> emprestimos = new List<Emprestimo>();

            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_1, LivroID = id_livro_1, DataRetirada = DateTime.Now, DataDevolucao = null }); // Livro id_livro_1 emprestado ao usuário id_usuario_1
            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_2, LivroID = id_livro_3, DataRetirada = DateTime.Now, DataDevolucao = DateTime.Now });
            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_3, LivroID = id_livro_4, DataRetirada = DateTime.Now, DataDevolucao = DateTime.Now });
            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_4, LivroID = id_livro_5, DataRetirada = DateTime.Now, DataDevolucao = DateTime.Now });
            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_5, LivroID = id_livro_6, DataRetirada = DateTime.Now, DataDevolucao = DateTime.Now });
            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_6, LivroID = id_livro_2, DataRetirada = DateTime.Now, DataDevolucao = DateTime.Now });
            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_7, LivroID = id_livro_3, DataRetirada = DateTime.Now, DataDevolucao = DateTime.Now });
            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_8, LivroID = id_livro_4, DataRetirada = DateTime.Now, DataDevolucao = DateTime.Now });
            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_9, LivroID = id_livro_5, DataRetirada = DateTime.Now, DataDevolucao = DateTime.Now });
            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_1, LivroID = id_livro_6, DataRetirada = DateTime.Now, DataDevolucao = DateTime.Now });
            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_2, LivroID = id_livro_2, DataRetirada = DateTime.Now, DataDevolucao = null }); // Livro id_livro_2 emprestado ao usuário id_usuario_2
            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_3, LivroID = id_livro_3, DataRetirada = DateTime.Now, DataDevolucao = null }); // Livro id_livro_3 emprestado ao usuário id_usuario_3
            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_4, LivroID = id_livro_4, DataRetirada = DateTime.Now, DataDevolucao = DateTime.Now });
            emprestimos.Add(new Emprestimo() { Id = Guid.NewGuid(), UsuarioID = id_usuario_5, LivroID = id_livro_5, DataRetirada = DateTime.Now, DataDevolucao = DateTime.Now });

            context.Emprestimos.AddRange(emprestimos);


            //5 - Funcionários do sistema
            const string Password_Administrador = "Admin@123";
            const string Password_Funcionario_1 = "Func@123";
            var id_administrador = Guid.NewGuid();
            var id_funcionario_1 = Guid.NewGuid();
            Func<string> GenerateSecurityStamp = delegate ()
            {
                var guid = Guid.NewGuid();
                return String.Concat(Array.ConvertAll(guid.ToByteArray(), b => b.ToString("X2")));
            };

            var UserManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            var PasswordHash = new PasswordHasher();

            IList<IdentityUser> funcionarios = new List<IdentityUser>();

            //5.1 - Administrador
            var administrador = new IdentityUser
            {
                Id = id_administrador.ToString(),
                AccessFailedCount = 5,
                Email = "admin@email.com",
                EmailConfirmed = true,
                LockoutEnabled = true,
                PasswordHash = PasswordHash.HashPassword(Password_Administrador),
                PhoneNumberConfirmed = true,
                SecurityStamp = GenerateSecurityStamp(),
                TwoFactorEnabled = false,
                UserName = "admin@email.com",
            };

            //5.2 - Funcionário 1
            var funcionario_1 = new IdentityUser
            {
                Id = id_funcionario_1.ToString(),
                AccessFailedCount = 5,
                Email = "func@email.com",
                EmailConfirmed = true,
                LockoutEnabled = true,
                PasswordHash = PasswordHash.HashPassword(Password_Funcionario_1),
                PhoneNumberConfirmed = true,
                SecurityStamp = GenerateSecurityStamp(),
                TwoFactorEnabled = false,
                UserName = "func@email.com",
            };


            //6 - Claims 
            const string ClaimType_Administrador = "Administrador";
            const string ClaimValue_Administrador = "Ler,Adicionar,Atualizar,Excluir";
            const string ClaimType_Funcionario_1 = "Funcionario";
            const string ClaimValue_Funcionario_1 = "Ler,Atualizar";

            var administrador_claims = new IdentityUserClaim
            {
                UserId = id_administrador.ToString(),
                ClaimType = ClaimType_Administrador,
                ClaimValue = ClaimValue_Administrador,
            };

            var funcionario_1_claims = new IdentityUserClaim
            {
                UserId = id_funcionario_1.ToString(),
                ClaimType = ClaimType_Funcionario_1,
                ClaimValue = ClaimValue_Funcionario_1,
            };


            administrador.Claims.Add(administrador_claims);
            funcionario_1.Claims.Add(funcionario_1_claims);

            context.Users.Add(administrador);
            context.Users.Add(funcionario_1);

            context.SaveChanges();
        }
    }
}