using System.ComponentModel;

namespace SistemaBiblioteca.Business.Enums
{
    public enum EmprestimoOrdenarPor
    {
        [Description("Id")]
        Id,

        [Description("Nome")]
        Nome,

        [Description("Titulo")]
        Titulo,

        [Description("Data de retirada")]
        DataRetirada,

        [Description("Data de devolução")]
        DataDevolucao,
    }
}
