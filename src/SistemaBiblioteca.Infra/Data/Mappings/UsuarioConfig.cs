using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using SistemaBiblioteca.Business.Models.Usuarios;

namespace SistemaBiblioteca.Infra.Data.Mappings
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(u => u.Id);

            Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(u => u.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnAnnotation("IX_Cpf",
                    new IndexAnnotation(new IndexAttribute { IsUnique = true }));

            HasRequired(u => u.Endereco)
                .WithRequiredPrincipal(e => e.Usuario);

            ToTable("Usuarios");
        }
    }
}