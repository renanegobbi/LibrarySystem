using AutoMapper;
using SistemaBiblioteca.App.Mvc.Extensions;
using SistemaBiblioteca.App.Mvc.Helpers;
using SistemaBiblioteca.App.Mvc.Results;
using SistemaBiblioteca.App.Mvc.ViewModels;
using SistemaBiblioteca.Business.Comandos.Entrada;
using SistemaBiblioteca.Business.Core.Utils.ExtensionMethods;
using SistemaBiblioteca.Business.Enums;
using SistemaBiblioteca.Business.Models.Emprestimos;
using SistemaBiblioteca.Business.Models.Livros;
using SistemaBiblioteca.Business.Models.Livros.Services;
using SistemaBiblioteca.Business.Notificacoes;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SistemaBiblioteca.App.Mvc.Controllers
{
    [Authorize]
    public class LivroController : BaseController
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly ILivroService _livroService;
        private readonly IMapper _mapper;
        private readonly DatatablesHelper _datatablesHelper;

        public LivroController(ILivroRepository livroRepository,
                                IEmprestimoRepository emprestimoRepository,
                                IMapper mapper,
                                ILivroService livroService,
                                DatatablesHelper datatablesHelper,
                                INotificador notificador) : base(notificador)
        {
            _livroRepository = livroRepository;
            _emprestimoRepository = emprestimoRepository;
            _mapper = mapper;
            _livroService = livroService;
            _datatablesHelper = datatablesHelper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var permissaoParaExluir = CustomAuthorization.ValidarClaimsUsuario("Administrador", "Excluir");
            var livroViewModel = new LivroViewModel();
            livroViewModel.PermissoaExclusaoLivro = permissaoParaExluir;

            return PartialView("Index", livroViewModel);
        }

        [AllowAnonymous]
        [Route("lista-de-livros")]
        public async Task<ActionResult> ListaLivros(string titulo, string descricao)
        {
            var ordenarPor = LivroOrdenarPor.Titulo;

            Enum.TryParse(_datatablesHelper.OrdenarPor, true, out ordenarPor);

            var filtro = new ProcurarLivroEntrada(ordenarPor, _datatablesHelper.OrdenarSentido, _datatablesHelper.PaginaIndex, _datatablesHelper.PaginaTamanho)
            {
                Pesquisa = _datatablesHelper.PalavraChave,
                Titulo = titulo,
                Descricao = descricao,
            };

            var pesquisa = await _livroRepository.ProcurarLivro(filtro);

            return Json(new DatatablesResult(_datatablesHelper.Draw, (int)pesquisa.Item2, (int)pesquisa.Item2, pesquisa.Item1.Select(x => new
                {
                    id = x.Id.ToString(),
                    imagem = x.Imagem,
                    titulo = x.Titulo.LimitarCaracteresSeMaiorQue(60),
                    descricao = x.Descricao.LimitarCaracteresSeMaiorQue(50),
                }).ToArray()));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("exibir-popup-detalhar-livro")]
        public async Task<ActionResult> ExibirPopupDetalharLivro(Guid? codigo)
        {
            if (!codigo.HasValue)
                return new FeedbackResult(new Feedback(TipoFeedback.Atencao, "O livro não foi encontrado."));

            var livro = await _livroService.ObterLivroPorId(codigo.Value);

            if (livro == null)
                return new FeedbackResult(new Feedback(TipoFeedback.Atencao, "O livro não foi encontrado."));

            var livroViewModel = _mapper.Map<LivroViewModel>(livro);

            return PartialView("PopupDetalhesLivro", livroViewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("exibir-popup-emprestar-livro")]
        public async Task<ActionResult> ExibirPopupEmprestarUsuario(Guid? codigo)
        {
            if (!codigo.HasValue)
                return new FeedbackResult(new Feedback(TipoFeedback.Atencao, "O livro não foi encontrado."));

            var livro = await _livroService.ObterLivroPorId(codigo.Value);

            if (livro == null)
                return new FeedbackResult(new Feedback(TipoFeedback.Atencao, "O livro não foi encontrado."));

            var livroViewModel = _mapper.Map<LivroViewModel>(livro);

            var livroDisponivel = await _emprestimoRepository.VerificarPossibilidadeEmprestimo(codigo.Value);
            livroViewModel.StatusEmprestimo = livroDisponivel == true ? EnumeratorsExtensions.GetDescription(StatusEmprestimo.Disponivel) : EnumeratorsExtensions.GetDescription(StatusEmprestimo.Indisponivel);

            return PartialView("PopupEmprestarLivro", livroViewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("exibir-popup-livro")]
        public async Task<ActionResult> ExibirPopupLivro(Guid? codigo)
        {
            if (!codigo.HasValue)
                return PartialView("Create", null);

            var livro = await _livroService.ObterLivroPorId(codigo.Value);

            if (livro == null)
                return new FeedbackResult(new Feedback(TipoFeedback.Atencao, "O livro não foi encontrado."));

            var livroViewModel = _mapper.Map<LivroViewModel>(livro);

            return PartialView("Edit", livroViewModel);
        }

        [ClaimsAuthorize("Administrador", "Adicionar")]
        [Route("novo-livro")]
        [HttpPost]
        public async Task<ActionResult> CadastrarLivro(LivroViewModel model)
        {
            var imgPrefixo = Guid.NewGuid() + "_";
            if (!UploadImagem(model.ImagemUpload, imgPrefixo, model.Imagem))
            {
                return new FeedbackResult(new Feedback(TipoFeedback.Atencao, "Ocorreu um erro ao cadastrar o livro.", new[] { "Nenhuma imagem foi adicionada." }, TipoAcaoAoOcultarFeedback.Ocultar));
            }

            model.Imagem = imgPrefixo + model.Imagem;
            await _livroService.Adicionar(_mapper.Map<Livro>(model));

            return (!OperacaoValida())
                ? new FeedbackResult(new Feedback(TipoFeedback.Atencao, "Ocorreu um erro ao cadastrar o livro.", notificacoes, TipoAcaoAoOcultarFeedback.Ocultar))
                : new FeedbackResult(new Feedback(TipoFeedback.Sucesso, "Livro cadastrado com sucesso.", null, TipoAcaoAoOcultarFeedback.Ocultar));
        }

        [AllowAnonymous]
        [Route("editar-livro")]
        [HttpPost]
        public async Task<ActionResult> EditarLivro(LivroViewModel model)
        {
            var livroAtualizacao = await _livroRepository.ObterLivroPorId(model.Id);

            if(livroAtualizacao == null)
                return new FeedbackResult(new Feedback(TipoFeedback.Atencao, "Nenhum livro encontrado.", new[] { "Nenhum livro encontrado." }, TipoAcaoAoOcultarFeedback.Ocultar));


            model.Imagem = livroAtualizacao.Imagem;

            if (model.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!UploadImagem(model.ImagemUpload, imgPrefixo, model.ImagemUpload.FileName))
                {
                    return new FeedbackResult(new Feedback(TipoFeedback.Atencao, "Ocorreu um erro ao alterar o livro.", new[] { "Nenhuma imagem foi alterada." }, TipoAcaoAoOcultarFeedback.Ocultar));
                }

                livroAtualizacao.Imagem = imgPrefixo + model.ImagemUpload.FileName;
            }

            livroAtualizacao.Titulo = model.Titulo;
            livroAtualizacao.Descricao = model.Descricao;
            livroAtualizacao.Editora = model.Editora;
            livroAtualizacao.AnoPublicacao = model.AnoPublicacao;
            livroAtualizacao.DataCadastro = model.DataCadastro;

            await _livroService.Atualizar(_mapper.Map<Livro>(livroAtualizacao));

            return (!OperacaoValida())
                ? new FeedbackResult(new Feedback(TipoFeedback.Atencao, "Ocorreu um erro ao alterar o livro.", notificacoes, TipoAcaoAoOcultarFeedback.Ocultar))
                : new FeedbackResult(new Feedback(TipoFeedback.Sucesso, "Livro alterado com sucesso.", null, TipoAcaoAoOcultarFeedback.Ocultar));
        }

        [ClaimsAuthorize("Administrador", "Excluir")]
        [HttpPost]
        [Route("excluir-livro")]
        public async Task<ActionResult> ExcluirLivro(Guid codigo)
        {
            await _livroService.Remover(codigo);

            return (!OperacaoValida())
                    ? new FeedbackResult(new Feedback(TipoFeedback.Atencao, "Ocorreu um erro ao excluir o livro.", notificacoes, TipoAcaoAoOcultarFeedback.Ocultar))
                    : new FeedbackResult(new Feedback(TipoFeedback.Sucesso, "Livro excluído com sucesso.", null, TipoAcaoAoOcultarFeedback.Ocultar));
        }

        [AllowAnonymous]
        [Route("emprestar-livro")]
        [HttpPost]
        public async Task<ActionResult> EmprestarLivro(EmprestimoViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var emprestimo = _mapper.Map<Emprestimo>(model);
            await _livroService.RealizarEmprestimo(emprestimo);

            return (!OperacaoValida())
                    ? new FeedbackResult(new Feedback(TipoFeedback.Atencao, "Ocorreu um erro ao emprestar o livro.", notificacoes, TipoAcaoAoOcultarFeedback.Ocultar))
                    : new FeedbackResult(new Feedback(TipoFeedback.Sucesso, "Livro emprestado com sucesso.", null, TipoAcaoAoOcultarFeedback.Ocultar));
        }

        [AllowAnonymous]
        [Route("devolver-livro")]
        [HttpPost]
        public async Task<ActionResult> DevolverLivro(Guid codigo)
        {
            if (!ModelState.IsValid) return View(codigo);

            var emprestimo = _emprestimoRepository.ObterEmprestimoPorIdLivro(codigo);

            if (emprestimo == null)
                return new FeedbackResult(new Feedback(TipoFeedback.Atencao, "O livro não foi encontrado para realizar a devolução!"));

            await _livroService.RealizarDevolucao(emprestimo);

            return (!OperacaoValida())
                    ? new FeedbackResult(new Feedback(TipoFeedback.Atencao, "Ocorreu um erro ao devolver o livro.", notificacoes, TipoAcaoAoOcultarFeedback.Ocultar))
                    : new FeedbackResult(new Feedback(TipoFeedback.Sucesso, "Livro devolvido com sucesso.", null, TipoAcaoAoOcultarFeedback.Ocultar));
        }

        private bool UploadImagem(HttpPostedFileBase img, string imgPrefixo, string fileName)
        {
            //if (img == null || img.ContentLength <= 0)
            if (img == null || img.ContentLength <= 0 || fileName == null)
            {
                ModelState.AddModelError(string.Empty, "Imagem em formato inválido!");
                return false;
            }

            //var path = Path.Combine(HttpContext.Server.MapPath("~/Imagens"), imgPrefixo + img.FileName);
            var path = Path.Combine(HttpContext.Server.MapPath("~/Imagens"), imgPrefixo + fileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            img.SaveAs(path);
            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _livroRepository.Dispose();
                _livroService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}