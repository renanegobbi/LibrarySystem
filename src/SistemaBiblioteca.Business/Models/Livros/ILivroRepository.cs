using SistemaBiblioteca.Business.Comandos.Entrada;
using SistemaBiblioteca.Business.Core.Data;
using SistemaBiblioteca.Business.Models.Emprestimos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Business.Models.Livros
{
    public interface ILivroRepository : IRepository<Livro>
    {
        Task<Livro> ObterLivroPorId(Guid id);
        Task<Livro> ObterLivroUsuario(Guid id);
        Task<IEnumerable<Livro>> ObterLivrosUsuarios();

        Task<Tuple<Livro[], double>> ProcurarLivro(ProcurarLivroEntrada entrada);

        Task RemoverLivro(IEnumerable<Emprestimo> emprestimo, Livro livro);
        Task RemoverLivro(Livro livro);
    }
}