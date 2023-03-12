namespace SistemaBiblioteca.Infra.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emprestimos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UsuarioID = c.Guid(nullable: false),
                        LivroID = c.Guid(nullable: false),
                        DataRetirada = c.DateTime(nullable: false),
                        DataDevolucao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Livros", t => t.LivroID)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID)
                .Index(t => t.UsuarioID)
                .Index(t => t.LivroID);
            
            CreateTable(
                "dbo.Livros",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Imagem = c.String(nullable: false, maxLength: 100),
                        Titulo = c.String(nullable: false, maxLength: 200),
                        Descricao = c.String(nullable: false, maxLength: 1000),
                        Editora = c.String(nullable: false, maxLength: 200),
                        AnoPublicacao = c.DateTime(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 200),
                        Cpf = c.String(nullable: false, maxLength: 11,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "IX_Cpf",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Logradouro = c.String(nullable: false, maxLength: 200),
                        Numero = c.String(nullable: false, maxLength: 50),
                        Complemento = c.String(maxLength: 250),
                        Cep = c.String(nullable: false, maxLength: 8, fixedLength: true),
                        Bairro = c.String(nullable: false),
                        Cidade = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Enderecos", "Id", "dbo.Usuarios");
            DropForeignKey("dbo.Emprestimos", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Emprestimos", "LivroID", "dbo.Livros");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Enderecos", new[] { "Id" });
            DropIndex("dbo.Emprestimos", new[] { "LivroID" });
            DropIndex("dbo.Emprestimos", new[] { "UsuarioID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Enderecos");
            DropTable("dbo.Usuarios",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Cpf",
                        new Dictionary<string, object>
                        {
                            { "IX_Cpf", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Livros");
            DropTable("dbo.Emprestimos");
        }
    }
}
