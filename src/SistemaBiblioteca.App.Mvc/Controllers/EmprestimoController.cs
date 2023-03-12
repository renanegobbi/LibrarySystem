using SistemaBiblioteca.App.Mvc.Helpers;
using SistemaBiblioteca.App.Mvc.Results;
using SistemaBiblioteca.Business.Comandos.Entrada;
using SistemaBiblioteca.Business.Core.Utils.ExtensionMethods;
using SistemaBiblioteca.Business.Enums;
using SistemaBiblioteca.Business.Models.Emprestimos;
using SistemaBiblioteca.Business.Notificacoes;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SistemaBiblioteca.App.Mvc.Controllers
{
    [Authorize]
    public class EmprestimoController : BaseController
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly DatatablesHelper _datatablesHelper;

        public EmprestimoController(IEmprestimoRepository emprestimoRepository,
                                    DatatablesHelper datatablesHelper,
                                    INotificador notificador) : base(notificador)
        {
            _emprestimoRepository = emprestimoRepository;
            _datatablesHelper = datatablesHelper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View("Index");
        }

        [AllowAnonymous]
        [Route("lista-de-emprestimos")]
        public async Task<ActionResult> ListaEmprestimos()
        {
            var ordenarPor = EmprestimoOrdenarPor.Nome ;

            Enum.TryParse(_datatablesHelper.OrdenarPor, true, out ordenarPor);

            var filtro = new ProcurarEmprestimoEntrada(ordenarPor, _datatablesHelper.OrdenarSentido, _datatablesHelper.PaginaIndex, _datatablesHelper.PaginaTamanho)
            {
                Pesquisa = _datatablesHelper.PalavraChave,
            };

            var pesquisa = await _emprestimoRepository.ProcurarEmprestimo(filtro);

            return Json(
                new DatatablesResult(_datatablesHelper.Draw, (int)pesquisa.Item2, (int)pesquisa.Item2, pesquisa.Item1.Select(x => new
                {
                    id = x.Id.ToString(),
                    nome = x.Usuario,
                    titulo = x.Livro.LimitarCaracteresSeMaiorQue(60),
                    dataRetirada = x.DataRetirada.ToString("dd/MM/yyy"),
                    dataDevolucao = x.DataDevolucao?.ToString("dd/MM/yyy")
                }).ToArray()));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _emprestimoRepository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}