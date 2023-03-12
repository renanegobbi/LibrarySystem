namespace SistemaBiblioteca.Infra.Migrations
{
    using SistemaBiblioteca.Infra.Data.Context;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SistemaBibliotecaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
