using System;

namespace SistemaBiblioteca.Business.Models.Emprestimos
{
    public class EmprestimoResumo
    {
        public Guid Id { get; set; }
        public string Usuario { get; set; }
        public string Livro { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public EmprestimoResumo(Emprestimo emprestimo)
        {
            this.Id = emprestimo.Id;
            this.Usuario = emprestimo.Usuario.Nome;
            this.Livro = emprestimo.Livro.Titulo;
            this.DataRetirada = emprestimo.DataRetirada;
            this.DataDevolucao = emprestimo.DataDevolucao;
        }

        public EmprestimoResumo(Guid id, string usuario, string livro, DateTime dataRetirada, DateTime? dataDevolucao)
        {
            this.Id = id;
            this.Usuario = usuario;
            this.Livro = livro;
            this.DataRetirada = dataRetirada;
            this.DataDevolucao = dataDevolucao;
        }
    }
}
