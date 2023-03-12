using SistemaBiblioteca.Business.Models.Usuarios;
using System.Data.Entity.ModelConfiguration;

namespace SistemaBiblioteca.Infra.Data.Mappings
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(200);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(e => e.Complemento)
                .HasMaxLength(250);

            Property(e => e.Bairro)
                .IsRequired();

            Property(e => e.Cidade)
                .IsRequired();

            Property(e => e.Estado)
                .IsRequired();

            ToTable("Enderecos");
        }
    }
}
