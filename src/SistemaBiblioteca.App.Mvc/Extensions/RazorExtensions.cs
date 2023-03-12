using System;
using System.Web.Mvc;

namespace SistemaBiblioteca.App.Mvc.Extensions
{
    public static class RazorExtensions
    {
        public static bool PermitirExibicao(this WebViewPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(claimName, claimValue);
        }

        public static MvcHtmlString PermitirExibicao(this MvcHtmlString value, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        public static string ActionComPermissao(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidarClaimsUsuario(claimName, claimValue) ? urlHelper.Action(actionName, controllerName, routeValues) : "";
        }


        public static string FormatarCpf(this WebViewPage page, string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

        public static string FormatarCep(this WebViewPage page, string cep)
        {
            return Convert.ToUInt64(cep).ToString(@"00\.000\-000");
        }

        public static string FormatarData(this WebViewPage page, DateTime? data)
        {
            return data?.ToString("dd/MM/yyyy");
        }
    }
}