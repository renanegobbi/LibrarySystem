using SistemaBiblioteca.App.Mvc.Extensions;
using SistemaBiblioteca.Business.Enums;
using System.Web;

namespace SistemaBiblioteca.App.Mvc.Helpers
{
    public static class CustomHtmlHelper
    {
        public static HtmlString CampoObrigatorio(string idControle)
        {
            return new HtmlString($"&nbsp;&nbsp;<label for=\"{idControle}\" class=\"error\"></label>");
        }

        public static HtmlString CampoStatus(string statusEmprestimo)
        {
            return statusEmprestimo == EnumeratorsExtensions.GetDescription(StatusEmprestimo.Disponivel)
                ? new HtmlString($"<td id=\"statusEmprestimo\" style=\"color: green;\">{statusEmprestimo}</td>")
                : new HtmlString($"<td id=\"statusEmprestimo\" style=\"color: red;\">{statusEmprestimo}</td>");
        }
    }
}