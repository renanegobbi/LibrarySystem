using SistemaBiblioteca.Business.Core.Models;
using SistemaBiblioteca.Business.Models.Emprestimos;
using System;
using System.Collections.Generic;

namespace SistemaBiblioteca.Business.Models.Livros
{
    public class Livro: Entity
    {
        public string Imagem { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Editora { get; set; }
        public DateTime AnoPublicacao { get; set; }
        public DateTime DataCadastro { get; set; }

        /* EF Relations */
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
    }
}
