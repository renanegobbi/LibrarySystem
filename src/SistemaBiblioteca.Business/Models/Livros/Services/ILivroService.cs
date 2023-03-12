using SistemaBiblioteca.Business.Models.Emprestimos;
using System;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Business.Models.Livros.Services
{
    public interface ILivroService : IDisposable
    {
        Task<Livro> ObterLivroPorId(Guid id);
        Task RealizarEmprestimo(Emprestimo emprestimo);
        Task RealizarDevolucao(Emprestimo emprestimo);
        Task Adicionar(Livro livro);
        Task Atualizar(Livro livro);
        Task Remover(Guid id);
    }
}