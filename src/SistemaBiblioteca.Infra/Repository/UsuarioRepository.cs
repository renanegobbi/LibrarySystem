using SistemaBiblioteca.Business.Comandos.Entrada;
using SistemaBiblioteca.Business.Enums;
using SistemaBiblioteca.Business.Models.Usuarios;
using SistemaBiblioteca.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Infra.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SistemaBibliotecaContext context) : base(context) { }

        public async Task<Usuario> ObterUsuarioEndereco(Guid id)
        {
            return await Db.Usuarios.AsNoTracking()
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Usuario> ObterUsuarioLivrosEndereco(Guid id)
        {
            return await Db.Usuarios.AsNoTracking()
                .Include(u => u.Emprestimos.Select(l => l.Livro))
                .Include(u => u.Endereco)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Tuple<Usuario[], double>> ProcurarUsuario(ProcurarUsuarioEntrada entrada)
        {
            IEnumerable<Usuario> registros = Db.Usuarios.AsNoTracking();

            if (entrada.Id.HasValue)
            {
                registros = registros.Where(u => u.Id == entrada.Id);
            }
            if (!string.IsNullOrEmpty(entrada.Pesquisa))
            {
                registros = registros.Where(u =>
                   u.Nome.ToUpper().Contains(entrada.Pesquisa.ToUpper().Trim()) ||
                   u.Cpf.ToUpper().Contains(entrada.Pesquisa.ToUpper().Trim()));
            }
            if (!string.IsNullOrEmpty(entrada.Nome))
            {
                registros = registros.Where(u => u.Nome.ToUpper().Contains(entrada.Nome.ToUpper().Trim()));
            }
            if (!string.IsNullOrEmpty(entrada.Cpf))
            {
                registros = registros.Where(u => u.Cpf.ToUpper().Contains(entrada.Cpf.ToUpper().Trim()));
            }

            switch (entrada.OrdenarPor)
            {
                case UsuarioOrdenarPor.Cpf:
                    registros = entrada.OrdenarSentido.ToUpper() == "DESC"
                        ? registros.OrderByDescending(u => u.Cpf)
                        : registros.OrderBy(u => u.Cpf);
                    break;
                default:
                    registros = entrada.OrdenarSentido.ToUpper() == "DESC"
                        ? registros.OrderByDescending(u => u.Nome)
                        : registros.OrderBy(u => u.Nome);
                    break;
            }

            var totalRegistros = Convert.ToDouble(registros.Count());

            registros = registros
                .Skip((int)entrada.PaginaTamanho * ((int)entrada.PaginaIndex - 1))
                .Take((int)entrada.PaginaTamanho)
                .ToList();

            return new Tuple<Usuario[], double>(registros.ToArray(), totalRegistros);
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            var usuarioAtualizado = new Usuario();
            usuarioAtualizado.Id = usuario.Id;
            usuarioAtualizado.Cpf = usuario.Cpf;
            usuarioAtualizado.Nome = usuario.Nome;
            Db.Entry(usuarioAtualizado).State = EntityState.Modified;
            //await SaveChanges();
        }

        public async Task<Tuple<Usuario[], double>> ProcurarUsuarioPorId(ProcurarUsuarioEntrada entrada)
        {
            IEnumerable<Usuario> registros = Db.Usuarios.AsNoTracking()
                .Where(u => u.Cpf.ToUpper().Contains(entrada.Cpf.ToUpper().Trim()));

            var totalRegistros = Convert.ToDouble(registros.Count());

            return new Tuple<Usuario[], double>(registros.ToArray(), totalRegistros);
        }
    }
}