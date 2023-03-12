using SistemaBiblioteca.Business.Notificacoes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaBiblioteca.App.Mvc.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotificador _notificador;
        public List<string> notificacoes;

        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            if (!_notificador.TemNotificacao()) return true;

            var _notificacoes = _notificador.ObterNotificacoes();
            notificacoes = new List<string>();
            foreach (var notificacao in _notificacoes)
            {
                notificacoes.Add(notificacao.Mensagem);
            }
            _notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Mensagem));

            return false;
        }
    }
}