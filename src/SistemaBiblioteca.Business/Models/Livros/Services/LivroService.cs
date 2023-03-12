using SistemaBiblioteca.Business.Core.Services;
using SistemaBiblioteca.Business.Models.Emprestimos;
using SistemaBiblioteca.Business.Models.Emprestimos.Validations;
using SistemaBiblioteca.Business.Models.Livros.Validations;
using SistemaBiblioteca.Business.Notificacoes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Business.Models.Livros.Services
{
    public class LivroService : BaseService, ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IEmprestimoRepository _emprestimoRepository;

        public LivroService(ILivroRepository livroRepository,
            IEmprestimoRepository emprestimoRepository,
            INotificador notificador) : base(notificador)
        {
            _livroRepository = livroRepository;
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task<Livro> ObterLivroPorId(Guid id)
        {
            var livro = await _livroRepository.ObterPorId(id);

            if (livro == null) return null;

            return livro;
        }

        public async Task RealizarEmprestimo(Emprestimo emprestimo)
        {
            var datahoje = DateTime.Now;
            emprestimo.DataRetirada = datahoje;

            if (!ExecutarValidacao(new EmprestimoValidation(), emprestimo)) return;

            await _emprestimoRepository.Adicionar(emprestimo);
        }

        public async Task RealizarDevolucao(Emprestimo emprestimo)
        {
            if (!ExecutarValidacao(new EmprestimoValidation(), emprestimo)) return;

            var datahoje = DateTime.Now;

            emprestimo.DataDevolucao = datahoje;

            await _emprestimoRepository.Atualizar(emprestimo);
        }

        public async Task Adicionar(Livro livro)
        {
            if (!ExecutarValidacao(new LivroValidation(), livro)) return;

            await _livroRepository.Adicionar(livro);
        }

        public async Task Atualizar(Livro livro)
        {
            if (!ExecutarValidacao(new LivroValidation(), livro)) return;

            await _livroRepository.Atualizar(livro);
        }

        public async Task Remover(Guid id)
        {
            var livro = await _livroRepository.ObterLivroPorId(id);

            if (livro == null)
            {
                Notificar("Livro não encontrado!");
                return;
            }

            var livroEmprestado = livro.Emprestimos.Where(e => e.DataDevolucao == null);

            if (livroEmprestado.Any())
            {
                Notificar("Existe livro emprestado!");
                return;
            }

            var emprestimos = livro.Emprestimos;

            foreach (var emprestimo in emprestimos)
            {
                await _emprestimoRepository.Remover(emprestimo.Id);
            }

            await _livroRepository.Remover(id);
        }

        public void Dispose()
        {
            _livroRepository?.Dispose();
        }
    }
}