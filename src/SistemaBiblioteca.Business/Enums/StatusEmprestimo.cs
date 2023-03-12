using System.ComponentModel;

namespace SistemaBiblioteca.Business.Enums
{
    public enum StatusEmprestimo
    {
        [Description("Disponível para empréstimo")]
        Disponivel,

        [Description("Indisponível para empréstimo")]
        Indisponivel,
    }
}
