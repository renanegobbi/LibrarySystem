using System.Collections;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SistemaBiblioteca.App.Mvc.Results
{
    /// <summary>
    /// ActionResults que alimentarão componentes Datatables.net
    /// </summary>
    public class DatatablesResult
    {
        public readonly int draw;
        public readonly int recordsTotal;
        public readonly int recordsFiltered;
        public readonly IEnumerable data;

        public DatatablesResult(int Draw, int RecordsTotal, int RecordsFiltered, IEnumerable Data)
        {
            draw = Draw;
            recordsTotal = RecordsTotal;
            recordsFiltered = RecordsFiltered;
            data = Data;
        }

        public async Task ExecuteResultAsync(ActionExecutingContext context)
        {
            var jsonResult = new JsonResult() {
 
            };

            jsonResult.Data = new
            {
                draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsTotal,
                data = this.data
            };

            jsonResult.ExecuteResult(context);
        }
    }
}
