using SistemaBiblioteca.Business.Core.Models;

namespace SistemaBiblioteca.Business.Models.Usuarios
{
    public class Endereco: Entity
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        /* EF Relations */
        public virtual Usuario Usuario { get; set; }
    }
}
