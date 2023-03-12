using SistemaBiblioteca.Business.Models.Emprestimos;
using System.Data.Entity.ModelConfiguration;

namespace SistemaBiblioteca.Infra.Data.Mappings
{
    public class EmprestimoConfig : EntityTypeConfiguration<Emprestimo>
    {
        public EmprestimoConfig()
        {
            ToTable("Emprestimos");
        }
    }
}
