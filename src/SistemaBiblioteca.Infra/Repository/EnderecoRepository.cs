using SistemaBiblioteca.Business.Models.Usuarios;
using SistemaBiblioteca.Infra.Data.Context;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Infra.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(SistemaBibliotecaContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorUsuario(Guid fornecedorId)
        {
            return await ObterPorId(fornecedorId);
        }

        public async Task<Endereco> ObterEnderecoPorId(Guid id)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {   var enderecoAtualizado = new Endereco();
            enderecoAtualizado.Id = endereco.Id;
            enderecoAtualizado.Cep = endereco.Cep;
            enderecoAtualizado.Numero = endereco.Numero;
            enderecoAtualizado.Complemento = endereco.Complemento;
            enderecoAtualizado.Logradouro = endereco.Logradouro;
            enderecoAtualizado.Bairro = endereco.Bairro;
            enderecoAtualizado.Cidade = endereco.Cidade;
            enderecoAtualizado.Estado = endereco.Estado;

            await Atualizar(enderecoAtualizado);
            //await SaveChanges();
        }
    }
}