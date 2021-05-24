using System.Web.Mvc;

namespace FeedSimulator.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ErrorMessage()
        {
            return View();
        }
    }
}