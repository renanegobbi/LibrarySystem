using System;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Business.Models.Usuarios.Services
{
    public interface IUsuarioService : IDisposable
    {
        Task<Usuario> ObterUsuarioPorId(Guid id);
        Task Adicionar(Usuario usuario);
        Task Remover(Guid id);
        Task AtualizarUsuario(Usuario usuario, Endereco endereco);
    }
}