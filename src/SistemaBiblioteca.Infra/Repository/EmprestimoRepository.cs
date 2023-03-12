using SistemaBiblioteca.Business.Comandos.Entrada;
using SistemaBiblioteca.Business.Enums;
using SistemaBiblioteca.Business.Models.Emprestimos;
using SistemaBiblioteca.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Infra.Repository
{
    public class EmprestimoRepository : Repository<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(SistemaBibliotecaContext context) : base(context) { }

        public Emprestimo ObterEmprestimoPorIdLivro(Guid idLivro)
        {
            var emprestimo = Db.Emprestimos.AsNoTracking().Where(e =>
               e.LivroID == idLivro &&
               e.DataDevolucao == null).FirstOrDefault();

            return emprestimo;
        }
        public Emprestimo ObterPorIdLivro(Guid idLivro)
        {
            var emprestimo = Db.Emprestimos.AsNoTracking().Where(e =>
               e.LivroID == idLivro).FirstOrDefault();

            return emprestimo;
        }

        public async Task<bool> VerificarPossibilidadeEmprestimo(Guid idLivro)
        {
            var query = Db.Emprestimos.AsNoTracking().Where(e =>
               e.LivroID == idLivro &&
               e.DataDevolucao == null);

            if (!query.Any()) return true;

            return query.Count() > 0 ? false : true;
        }

        public async Task<bool> VerificarExistenciaLivroEmprestado(Guid idLivro)
        {
            var query = Db.Emprestimos.AsNoTracking().Where(e =>
               e.LivroID == idLivro &&
               e.DataDevolucao == null);

            return query.Count() > 0 ? true : false;
        }

        public async Task<bool> VerificarExistenciaLivroEmprestado(IEnumerable<Emprestimo> emprestimos)
        {
            var query = emprestimos.Where(e => e.DataDevolucao == null);

            return query.Count() > 0 ? true : false;
        }

        public async Task RemoverEmprestimos(IEnumerable<Emprestimo> emprestimos)
        {
            if (emprestimos != null)
            {
                foreach (var emprestimo in emprestimos)
                {
                    Db.Entry(emprestimo).State = EntityState.Deleted;
                }
            }
                
            await SaveChanges();
        }

        public async Task<Tuple<EmprestimoResumo[], double>> ProcurarEmprestimo(ProcurarEmprestimoEntrada entrada)
        {
            var registros = Db.Emprestimos
                .AsNoTracking()
                .Include(x => x.Usuario)
                .Include(x => x.Livro)
                .OrderBy(entrada)
                .Skip((int)entrada.PaginaTamanho * ((int)entrada.PaginaIndex - 1))
                .Take((int)entrada.PaginaTamanho)
                .Where(entrada).ToList();

            var totalRegistros = Convert.ToDouble(Db.Emprestimos.AsNoTracking().Include(x => x.Usuario).Count());

            return new Tuple<EmprestimoResumo[], double>(registros.ToArray().Select(x =>
            new EmprestimoResumo(x.Id, x.Usuario.Nome, x.Livro.Titulo, x.DataRetirada, x.DataDevolucao)).ToArray(), totalRegistros);
        }

        public async Task RealizarEmprestimo(Emprestimo emprestimo)
        {
            DbSet.Add(emprestimo);
            await SaveChanges();
        }
    }

    public static class IEnumerableExtensions
    {

        public static IEnumerable<Emprestimo> OrderBy(this IEnumerable<Emprestimo> registros, ProcurarEmprestimoEntrada entrada)
        {
            switch (entrada.OrdenarPor)
            {
                case EmprestimoOrdenarPor.Nome:
                    registros = entrada.OrdenarSentido.ToUpper() == "DESC"
                        ? registros.OrderByDescending(e => e.Usuario.Nome)
                        : registros.OrderBy(e => e.Usuario.Nome);
                    break;
                case EmprestimoOrdenarPor.DataRetirada:
                    registros = entrada.OrdenarSentido.ToUpper() == "DESC"
                        ? registros.OrderByDescending(e => e.DataRetirada)
                        : registros.OrderBy(e => e.DataRetirada);
                    break;
                case EmprestimoOrdenarPor.DataDevolucao:
                    registros = entrada.OrdenarSentido.ToUpper() == "DESC"
                        ? registros.OrderByDescending(e => e.DataDevolucao)
                        : registros.OrderBy(e => e.DataDevolucao);
                    break;
                default:
                    registros = entrada.OrdenarSentido.ToUpper() == "DESC"
                        ? registros.OrderByDescending(e => e.Livro.Titulo)
                        : registros.OrderBy(e => e.Livro.Titulo);
                    break;
            }

            return registros;
        }

        public static IEnumerable<Emprestimo> Where(this IEnumerable<Emprestimo> registros, ProcurarEmprestimoEntrada entrada)
        {
            if (!string.IsNullOrEmpty(entrada.Pesquisa))
            {
                registros = registros.Where(u =>
                   u.Usuario.Nome.ToUpper().Contains(entrada.Pesquisa.ToUpper().Trim()) ||
                   u.Livro.Titulo.ToUpper().Contains(entrada.Pesquisa.ToUpper().Trim()));
            }
            if (entrada.Id.HasValue)
            {
                registros = registros.Where(e => e.Id == entrada.Id);
            }
            if (!string.IsNullOrEmpty(entrada.Usuario))
            {
                registros = registros.Where(e => e.Usuario.Nome.ToUpper().Contains(entrada.Usuario.ToUpper().Trim()));
            }
            if (!string.IsNullOrEmpty(entrada.Livro))
            {
                registros = registros.Where(e => e.Livro.Titulo.ToUpper().Contains(entrada.Usuario.ToUpper().Trim()));
            }

            return registros;
        }
    }
}