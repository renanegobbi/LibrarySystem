using SistemaBiblioteca.Business.Comandos.Entrada;
using SistemaBiblioteca.Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Business.Models.Emprestimos
{
    public interface IEmprestimoRepository : IRepository<Emprestimo>
    {
        Emprestimo ObterEmprestimoPorIdLivro(Guid idLivro);

        Emprestimo ObterPorIdLivro(Guid idLivro);

        Task<bool> VerificarPossibilidadeEmprestimo(Guid idLivro);

        Task<bool> VerificarExistenciaLivroEmprestado(IEnumerable<Emprestimo> emprestimos);

        Task<bool> VerificarExistenciaLivroEmprestado(Guid idLivro);

        Task<Tuple<EmprestimoResumo[], double>> ProcurarEmprestimo(ProcurarEmprestimoEntrada entrada);

        Task RealizarEmprestimo(Emprestimo emprestimo);

        Task RemoverEmprestimos(IEnumerable<Emprestimo> emprestimos);
    }
}

