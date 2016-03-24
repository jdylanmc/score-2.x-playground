using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Playground.Web.Areas.Playground.Controllers
{
    using System.Web.Mvc;
    using Base.Services;

    public class SanityCheckController : System.Web.Mvc.Controller
    {
        private IExampleService exampleService;

        public SanityCheckController(IExampleService exampleService)
        {
            this.exampleService = exampleService;
        }

        [HttpGet]
        public ActionResult DependencyResolution()
        {
            var model = new ExampleModel();

            if (exampleService == null)
            {
                model.Message = "Service was null";
            }
            else
            {
                model.Message = exampleService.GetMessage();
            }

            return PartialView(model);
        }
    }
}