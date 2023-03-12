using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SistemaBiblioteca.App.Mvc.Results
{
    /// <summary>
    /// ActionResult que busca padronizar as mensagens de feedback
    /// </summary>
    public class FeedbackResult : ActionResult
    {
        private readonly Feedback _feedback;

        public FeedbackResult(Feedback feedback)
        {
            _feedback = feedback;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                var jsonResult = new JsonResult();
                jsonResult.Data = new { _feedback };

                if (_feedback.tipo == TipoFeedback.Erro || _feedback.tipo == TipoFeedback.Atencao)
                    context.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                jsonResult.ExecuteResult(context);
            }
            else
            {
                var viewResult = new ViewResult
                {
                    ViewName = "Feedback",
                    ViewData = new ViewDataDictionary()
                    {
                        Model = _feedback
                    }
                };

                viewResult.ExecuteResult(context);
            }
        }

        public async Task ExecuteResultAsync(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                var jsonResult = new JsonResult();
                jsonResult.Data = new { _feedback };

                if (_feedback.tipo == TipoFeedback.Erro || _feedback.tipo == TipoFeedback.Atencao)
                    context.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                jsonResult.ExecuteResult(context);
            }
            else
            {
                var viewResult = new ViewResult
                {
                    ViewName = "Feedback",
                    ViewData = new ViewDataDictionary()
                    {
                        Model = _feedback
                    }
                };

                viewResult.ExecuteResult(context);
            }
        }
    }
}