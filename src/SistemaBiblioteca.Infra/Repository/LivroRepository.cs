using SistemaBiblioteca.Business.Comandos.Entrada;
using SistemaBiblioteca.Business.Enums;
using SistemaBiblioteca.Business.Models.Emprestimos;
using SistemaBiblioteca.Business.Models.Livros;
using SistemaBiblioteca.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Infra.Repository
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(SistemaBibliotecaContext context) : base(context) { }

        public async Task<Livro> ObterLivroPorId(Guid id)
        {
            return await Db.Livros.AsNoTracking()
                .Include(e => e.Emprestimos.Select(l => l.Usuario))
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Livro> ObterLivroUsuario(Guid id)
        {
            return await Db.Livros.AsNoTracking()
                .Include(e => e.Emprestimos.Select(l => l.Livro))
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Livro>> ObterLivrosUsuarios()
        {
            return await Db.Livros.AsNoTracking()
                .Include(e => e.Emprestimos.Select(l => l.Usuario))
                .OrderBy(p => p.Titulo).ToListAsync();
        }

        public async Task<Tuple<Livro[], double>> ProcurarLivro(ProcurarLivroEntrada entrada)
        {
            IEnumerable<Livro> registros = Db.Livros.AsNoTracking();

            if (entrada.Id.HasValue)
            {
                registros = registros.Where(l => l.Id == entrada.Id);
            }
            if (!string.IsNullOrEmpty(entrada.Pesquisa))
            {
                registros = registros.Where(u =>
                   u.Titulo.ToUpper().Contains(entrada.Pesquisa.ToUpper().Trim()) ||
                   u.Descricao.ToUpper().Contains(entrada.Pesquisa.ToUpper().Trim()));
            }
            if (!string.IsNullOrEmpty(entrada.Titulo))
            {
                registros = registros.Where(l => l.Titulo.ToUpper().Contains(entrada.Titulo.ToUpper().Trim()));
            }
            if (!string.IsNullOrEmpty(entrada.Descricao))
            {
                registros = registros.Where(l => l.Descricao.ToUpper().Contains(entrada.Descricao.ToUpper().Trim()));
            }

            switch (entrada.OrdenarPor)
            {
                case LivroOrdenarPor.Descricao:
                    registros = entrada.OrdenarSentido.ToUpper() == "DESC"
                        ? registros.OrderByDescending(l => l.Descricao)
                        : registros.OrderBy(l => l.Descricao);
                    break;
                default:
                    registros = entrada.OrdenarSentido.ToUpper() == "DESC"
                        ? registros.OrderByDescending(l => l.Titulo)
                        : registros.OrderBy(l => l.Titulo);
                    break;
            }

            var totalRegistros = Convert.ToDouble(registros.Count());

            registros = registros
                .Skip((int)entrada.PaginaTamanho * ((int)entrada.PaginaIndex - 1))
                .Take((int)entrada.PaginaTamanho)
                .ToList();

            return new Tuple<Livro[], double>(registros.ToArray(), totalRegistros);
        }

        public async Task RemoverLivro(IEnumerable<Emprestimo> emprestimos, Livro livro)
        {
             if(emprestimos != null)
                Db.Entry(emprestimos).State = EntityState.Deleted;

             Db.Entry(livro).State = EntityState.Deleted;
             await SaveChanges();
        }

        public async Task RemoverLivro(Livro livro)
        {
            Db.Entry(livro).State = EntityState.Deleted;
            await SaveChanges();
        }
    }
}