using SistemaBiblioteca.Business.Core.Models;
using SistemaBiblioteca.Business.Models.Emprestimos;
using System.Collections.Generic;

namespace SistemaBiblioteca.Business.Models.Usuarios
{
    public class Usuario: Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Endereco Endereco { get; set; }

        /* EF Relations */
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
    }
}
