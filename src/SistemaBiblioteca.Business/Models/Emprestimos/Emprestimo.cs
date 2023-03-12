using SistemaBiblioteca.Business.Core.Models;
using SistemaBiblioteca.Business.Models.Livros;
using SistemaBiblioteca.Business.Models.Usuarios;
using System;

namespace SistemaBiblioteca.Business.Models.Emprestimos
{
    public class Emprestimo: Entity
    {
        public Guid UsuarioID { get; set; }
        public Guid LivroID { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime? DataDevolucao { get; set; }

        /* EF Relations */
        public virtual Usuario Usuario { get; set; }
        public virtual Livro Livro { get; set; }
    }
}
