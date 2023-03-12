using SistemaBiblioteca.Business.Core.Data;
using System;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Business.Models.Usuarios
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorUsuario(Guid fornecedorId);

        Task AtualizarEndereco(Endereco endereco);

        Task<Endereco> ObterEnderecoPorId(Guid id);
    }
}
