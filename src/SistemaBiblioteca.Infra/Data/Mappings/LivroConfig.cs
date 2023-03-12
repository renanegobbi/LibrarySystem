using SistemaBiblioteca.Business.Models.Livros;
using System.Data.Entity.ModelConfiguration;

namespace SistemaBiblioteca.Infra.Data.Mappings
{
    public class LivroConfig : EntityTypeConfiguration<Livro>
    {
        public LivroConfig()
        {
            HasKey(l => l.Id);

            Property(l => l.Imagem)
                .IsRequired()
                .HasMaxLength(100);

            Property(l => l.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            Property(l => l.Descricao)
                .IsRequired()
                .HasMaxLength(1000);

            Property(l => l.Editora)
                .IsRequired()
                .HasMaxLength(200);

            ToTable("Livros");
        }
    }
}