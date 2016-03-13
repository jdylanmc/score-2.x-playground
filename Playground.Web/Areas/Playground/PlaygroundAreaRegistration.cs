using System.Web.Mvc;

namespace Playground.Web.Areas.Playground
{
    public class PlaygroundAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Playground";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            // Register your MVC routes in here
        }
    }
}
