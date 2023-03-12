using SistemaBiblioteca.Business.Core.Services;
using SistemaBiblioteca.Business.Models.Emprestimos;
using SistemaBiblioteca.Business.Models.Usuarios.Validations;
using SistemaBiblioteca.Business.Notificacoes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Business.Models.Usuarios.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEmprestimoRepository _emprestimoRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                                 IEnderecoRepository enderecoRepository,
                                 IEmprestimoRepository emprestimoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _enderecoRepository = enderecoRepository;
            _emprestimoRepository = emprestimoRepository;
        }


        public async Task<Usuario> ObterUsuarioPorId(Guid id)
        {
            var usuario = await _usuarioRepository.ObterPorId(id);

            if (usuario == null) return null;

            var endereco = await _enderecoRepository.ObterEnderecoPorUsuario(usuario.Id);

            if (endereco != null) usuario.Endereco = endereco;

            return usuario;
        }

        public async Task Adicionar(Usuario usuario)
        {
            // Limitações do EF 6 fora da convenção
            usuario.Endereco.Id = usuario.Id;
            usuario.Endereco.Usuario = usuario;

            if (!ExecutarValidacao(new UsuarioValidation(), usuario)
                || !ExecutarValidacao(new EnderecoValidation(), usuario.Endereco) ) return;

            if (await UsuarioExistente(usuario)) return;

            await _usuarioRepository.Adicionar(usuario);
        }

        public async Task AtualizarUsuario(Usuario usuario, Endereco endereco)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)
                || !ExecutarValidacao(new EnderecoValidation(), usuario.Endereco)) return;

            var _endereco = await _enderecoRepository.ObterEnderecoPorId(usuario.Endereco.Id);
            if (_endereco == null) return;

            await _usuarioRepository.AtualizarUsuario(usuario);
            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task Remover(Guid id)
        {
            var usuario = await _usuarioRepository.ObterUsuarioLivrosEndereco(id);

            if (usuario == null) {
                Notificar("Usuário não encontrado!");
                return;
            }

            var livroEmprestado = usuario.Emprestimos.Where(e => e.DataDevolucao == null);

            if (livroEmprestado.Count() > 0)
            {
                Notificar("O usuário possui livros emprestado!");
                return;
            }

            //Remove endereço
            if (usuario.Endereco != null)
            {
                await _enderecoRepository.Remover(usuario.Endereco.Id);
            }

            //Remove registros de empréstimos
            var emprestimos = usuario.Emprestimos;

            foreach (var emprestimo in emprestimos)
            {
                await _emprestimoRepository.Remover(emprestimo.Id);
            }

            //Remove usuário
            await _usuarioRepository.Remover(id);
        }

        private async Task<bool> UsuarioExistente(Usuario usuario)
        {
            var usuarioAtual = await _usuarioRepository.Buscar(f => f.Cpf == usuario.Cpf && f.Id != usuario.Id);

            if (!usuarioAtual.Any()) return false;

            Notificar("Já existe um usuário com este CPF infomado.");
            return true;
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
