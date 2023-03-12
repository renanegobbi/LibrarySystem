using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SistemaBiblioteca.App.Mvc.Helpers;
using SistemaBiblioteca.Business.Models.Emprestimos;
using SistemaBiblioteca.Business.Models.Emprestimos.Services;
using SistemaBiblioteca.Business.Models.Livros;
using SistemaBiblioteca.Business.Models.Livros.Services;
using SistemaBiblioteca.Business.Models.Usuarios;
using SistemaBiblioteca.Business.Models.Usuarios.Services;
using SistemaBiblioteca.Business.Notificacoes;
using SistemaBiblioteca.Infra.Data.Context;
using SistemaBiblioteca.Infra.Repository;
using System.Reflection;
using System.Web.Mvc;

namespace SistemaBiblioteca.App.Mvc
{
    public class DependencyInjectionConfig
    {
        public static void RegisterDIContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            // Lifestyle.Singleton
            // Uma única instância por aplicação

            // Lifestyle.Transient
            // Cria uma nova instância para cada injeção

            //Lifestyle.Scoped
            // Uma única instância por request

            container.Register<SistemaBibliotecaContext>(Lifestyle.Scoped);
            container.Register<ILivroRepository, LivroRepository>(Lifestyle.Scoped);
            container.Register<IEmprestimoRepository, EmprestimoRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<ILivroService, LivroService>(Lifestyle.Scoped);
            container.Register<IEmprestimoService, EmprestimoService>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<INotificador, Notificador>(Lifestyle.Scoped);
            container.Register<DatatablesHelper>(Lifestyle.Transient);
            container.RegisterSingleton(() => AutoMapperConfig.GetMapperConfiguration().CreateMapper(container.GetInstance));
        }
    }
}