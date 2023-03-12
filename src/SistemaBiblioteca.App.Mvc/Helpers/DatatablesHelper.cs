using System;
using System.Linq;
using System.Web;

namespace SistemaBiblioteca.App.Mvc.Helpers
{
    /// <summary>
    /// Classe para extração dos parâmetros utilizados pelo componente Datatables.net
    /// </summary>
    public class DatatablesHelper
    {
        HttpContext _httpContext = HttpContext.Current;

        public string PalavraChave
        {
            get { return _httpContext.Request.Form["search[value]"]; }
        }

        public int Draw
        {
            get
            {
                return !_httpContext.Request.Form.GetValues("draw").Any()
              ? -1
              : Convert.ToInt32(_httpContext.Request.Form.GetValues("draw").First());
            }
        }

        public int PaginaIndex
        {
            get
            {
                if (string.IsNullOrEmpty(_httpContext.Request.Form["length"])
                    || string.IsNullOrEmpty(_httpContext.Request.Form["start"]))
                    return -1;

                var length = Convert.ToInt32(_httpContext.Request.Form["length"]);
                var start = Convert.ToInt32(_httpContext.Request.Form["start"]);

                return (start / length) + 1;
            }
        }

        public int PaginaTamanho
        {
            get
            {
                return !_httpContext.Request.Form.GetValues("length").Any()
              ? 1
              : Convert.ToInt32(_httpContext.Request.Form.GetValues("length").FirstOrDefault());
            }
        }

        public string OrdenarSentido
        {
            get { return _httpContext.Request.Form["order[0][dir]"] ?? string.Empty; }
        }

        public string OrdenarPor
        {
            get
            {
                var colunaOrdenacaoIndex = -1;

                return int.TryParse(_httpContext.Request.Form["order[0][column]"], out colunaOrdenacaoIndex)
                    ? _httpContext.Request.Form["columns[" + colunaOrdenacaoIndex + "][data]"]
                    : string.Empty;
            }
        }
    }
}