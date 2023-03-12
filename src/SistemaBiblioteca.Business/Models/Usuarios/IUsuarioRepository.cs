using SistemaBiblioteca.Business.Comandos.Entrada;
using SistemaBiblioteca.Business.Core.Data;
using System;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Business.Models.Usuarios
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterUsuarioEndereco(Guid id);
        Task<Usuario> ObterUsuarioLivrosEndereco(Guid id);
        Task<Tuple<Usuario[], double>> ProcurarUsuario(ProcurarUsuarioEntrada entrada);
        Task<Tuple<Usuario[], double>> ProcurarUsuarioPorId(ProcurarUsuarioEntrada entrada);
        Task AtualizarUsuario(Usuario usuario);
    }
}