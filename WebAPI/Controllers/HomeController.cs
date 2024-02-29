using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult RedirectToSwagger() {
            return Redirect("/swagger");
        }
    }
}