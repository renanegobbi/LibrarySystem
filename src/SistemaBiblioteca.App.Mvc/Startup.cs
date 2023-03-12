using Microsoft.Owin;
using Owin;
using SistemaBiblioteca.Infra.Data.Context;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartupAttribute(typeof(SistemaBiblioteca.App.Mvc.Startup))]
namespace SistemaBiblioteca.App.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //Database.SetInitializer(new DatabaseInitializer());
            DependencyInjectionConfig.RegisterDIContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}