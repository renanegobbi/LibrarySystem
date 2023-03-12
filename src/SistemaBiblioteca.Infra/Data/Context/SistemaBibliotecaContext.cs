using Microsoft.AspNet.Identity.EntityFramework;
using SistemaBiblioteca.Business.Models.Emprestimos;
using SistemaBiblioteca.Business.Models.Livros;
using SistemaBiblioteca.Business.Models.Usuarios;
using SistemaBiblioteca.Infra.Data.Mappings;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Infra.Data.Context
{
    public class SistemaBibliotecaContext : IdentityDbContext<IdentityUser>
    {
        public SistemaBibliotecaContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Emprestimo>()
                .HasKey(e => new { e.UsuarioID, e.LivroID });

            modelBuilder.Entity<Emprestimo>()
                .HasRequired(e => e.Usuario)
                .WithMany(e => e.Emprestimos)
                .HasForeignKey(e => e.UsuarioID);

            modelBuilder.Entity<Emprestimo>()
                .HasRequired(e => e.Livro)
                .WithMany(e => e.Emprestimos)
                .HasForeignKey(e => e.LivroID);

            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new EmprestimoConfig());
            modelBuilder.Configurations.Add(new LivroConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataRetirada") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataRetirada").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataRetirada").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}