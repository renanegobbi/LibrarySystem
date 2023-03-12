using AutoMapper;
using SistemaBiblioteca.App.Mvc.Extensions;
using SistemaBiblioteca.App.Mvc.Helpers;
using SistemaBiblioteca.App.Mvc.Results;
using SistemaBiblioteca.App.Mvc.ViewModels;
using SistemaBiblioteca.Business.Comandos.Entrada;
using SistemaBiblioteca.Business.Core.Utils.ExtensionMethods;
using SistemaBiblioteca.Business.Enums;
using SistemaBiblioteca.Business.Models.Usuarios;
using SistemaBiblioteca.Business.Models.Usuarios.Services;
using SistemaBiblioteca.Business.Notificacoes;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SistemaBiblioteca.App.Mvc.Controllers
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly DatatablesHelper _datatablesHelper;

        public UsuarioController(IUsuarioRepository usuarioRepository,
                                IMapper mapper,
                                IUsuarioService usuarioService,
                                DatatablesHelper datatablesHelper,
                                INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _usuarioService = usuarioService;
            _datatablesHelper = datatablesHelper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var permissaoParaExluir = CustomAuthorization.ValidarClaimsUsuario("Administrador", "Excluir");
            var usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.PermissoaExclusaoUsuario = permissaoParaExluir;

            return PartialView("Index", usuarioViewModel);
        }

        [AllowAnonymous]
        [Route("obter-usuario-por-cpf")]
        public async Task<ActionResult> ObterUsuarioPorCpf(string cpf)
        {
            var ordenarPor = UsuarioOrdenarPor.Nome;

            Enum.TryParse(_datatablesHelper.OrdenarPor, true, out ordenarPor);

            var filtro = new ProcurarUsuarioEntrada(ordenarPor, _datatablesHelper.OrdenarSentido, _datatablesHelper.PaginaIndex, _datatablesHelper.PaginaTamanho)
            {
                Cpf = cpf.RemoverFormatacao(),
            };

            var pesquisa = await _usuarioRepository.ProcurarUsuarioPorId(filtro);

            return Json(
                new DatatablesResult(_datatablesHelper.Draw, (int)pesquisa.Item2, (int)pesquisa.Item2, pesquisa.Item1.Select(x => new
                {
                    id = x.Id.ToString(),
                    nome = x.Nome,
                    cpf = x.Cpf.FormatarCpf()
                }).ToArray()));
        }

        [AllowAnonymous]
        [Route("lista-de-usuarios")]
        public async Task<ActionResult> ListaUsuarios(string nome, string cpf)
        {
            var ordenarPor = UsuarioOrdenarPor.Nome;

            Enum.TryParse(_datatablesHelper.OrdenarPor, true, out ordenarPor);

            var filtro = new ProcurarUsuarioEntrada(ordenarPor, _datatablesHelper.OrdenarSentido, _datatablesHelper.PaginaIndex, _datatablesHelper.PaginaTamanho)
            {
                Pesquisa = _datatablesHelper.PalavraChave,
                Nome = nome,
                Cpf = cpf.RemoverFormatacao(),
            };

            var pesquisa = await _usuarioRepository.ProcurarUsuario(filtro);

            return Json(
                new DatatablesResult(_datatablesHelper.Draw, (int)pesquisa.Item2, (int)pesquisa.Item2, pesquisa.Item1.Select(x => new
                {
                    id = x.Id.ToString(),
                    nome = x.Nome,
                    cpf = x.Cpf.FormatarCpf()
                }).ToArray()));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("exibir-popup-detalhar-usuario")]
        public async Task<ActionResult> ExibirPopupDetalharUsuario(Guid? codigo)
        {
            if (!codigo.HasValue)
                return new FeedbackResult(new Feedback(TipoFeedback.Atencao, "O usuário não foi encontrado."));

            var usuario = await _usuarioService.ObterUsuarioPorId(codigo.Value);

            if (usuario == null)
                return new FeedbackResult(new Feedback(TipoFeedback.Atencao, "O usuário não foi encontrado."));

            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);

            return PartialView("PopupDetalhesUsuario", usuarioViewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("exibir-popup-usuario")]
        public async Task<ActionResult> ExibirPopupUsuario(Guid? codigo)
        {
            if (!codigo.HasValue)
                return PartialView("PopupUsuario", null);

            var usuario = await _usuarioService.ObterUsuarioPorId(codigo.Value);

            if (usuario == null)
                return new FeedbackResult(new Feedback(TipoFeedback.Atencao, "O usuário não foi encontrado."));

            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);

            return PartialView("PopupUsuario", usuarioViewModel);
        }

        [ClaimsAuthorize("Administrador", "Adicionar")]
        [Route("novo-usuario")]
        [HttpPost]
        public async Task<ActionResult> CadastrarUsuario(UsuarioViewModel model)
        {
            model.Cpf = model.Cpf.RemoverFormatacao();
            model.Endereco.Cep = model.Endereco.Cep.RemoverFormatacao();
            var usuario = _mapper.Map<Usuario>(model);

            await _usuarioService.Adicionar(usuario);

            return (!OperacaoValida())
                    ? new FeedbackResult(new Feedback(TipoFeedback.Atencao, "Ocorreu um erro ao cadastrar o usuário.", notificacoes, TipoAcaoAoOcultarFeedback.Ocultar))
                    : new FeedbackResult(new Feedback(TipoFeedback.Sucesso, "Usuário cadastrado com sucesso.", null, TipoAcaoAoOcultarFeedback.Ocultar));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("editar-usuario")]
        public async Task<ActionResult> EditarUsuario(UsuarioViewModel model)
        {
            model.Endereco.Id = model.Id;
            model.Cpf = model.Cpf.RemoverFormatacao();
            model.Endereco.Cep = model.Endereco.Cep.RemoverFormatacao();

            var usuario = _mapper.Map<Usuario>(model);
            var endereco = _mapper.Map<Endereco>(model.Endereco);

            await _usuarioService.AtualizarUsuario(usuario, endereco);

            return (!OperacaoValida())
                ? new FeedbackResult(new Feedback(TipoFeedback.Atencao, "Ocorreu um erro ao alterar o usuário.", notificacoes, TipoAcaoAoOcultarFeedback.Ocultar))
                : new FeedbackResult(new Feedback(TipoFeedback.Sucesso, "Usuário alterado com sucesso.", null, TipoAcaoAoOcultarFeedback.Ocultar));
        }

        [ClaimsAuthorize("Administrador", "Excluir")]
        [HttpPost]
        [Route("excluir-usuario")]
        public async Task<ActionResult> ExcluirUsuario(Guid codigo)
        {
            await _usuarioService.Remover(codigo);

            return (!OperacaoValida())
                    ? new FeedbackResult(new Feedback(TipoFeedback.Atencao, "Ocorreu um erro ao excluir o usuário.", notificacoes, TipoAcaoAoOcultarFeedback.Ocultar))
                    : new FeedbackResult(new Feedback(TipoFeedback.Sucesso, "Usuário excluído com sucesso.", null, TipoAcaoAoOcultarFeedback.Ocultar));
        }
    }
}