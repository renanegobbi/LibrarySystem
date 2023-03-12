using SistemaBiblioteca.Business.Core.Services;
using SistemaBiblioteca.Business.Models.Emprestimos;
using SistemaBiblioteca.Business.Models.Emprestimos.Services;
using SistemaBiblioteca.Business.Notificacoes;

namespace SistemaBiblioteca.Business.Models.Livros.Services
{
    public class EmprestimoService : BaseService, IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository,
            INotificador notificador) : base(notificador)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public void Dispose()
        {
            _emprestimoRepository?.Dispose();
        }
    }
}