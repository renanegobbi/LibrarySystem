using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SistemaBiblioteca.Business.Enums;
using System;

namespace SistemaBiblioteca.Business.Comandos.Entrada
{
    public class ProcurarUsuarioEntrada
    {
        public Guid? Id { get; set; }

        public string Pesquisa { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public int? PaginaIndex { get; }

        public int? PaginaTamanho { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public UsuarioOrdenarPor? OrdenarPor { get; }

        public string OrdenarSentido { get; }

        public ProcurarUsuarioEntrada(UsuarioOrdenarPor? ordenarPor = UsuarioOrdenarPor.Nome, string ordenarSentido = "ASC", int? paginaIndex = null, int? paginaTamanho = null)
        {
            this.OrdenarPor = ordenarPor;
            this.OrdenarSentido = ordenarSentido;
            this.PaginaIndex = paginaIndex;
            this.PaginaTamanho = paginaTamanho;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}