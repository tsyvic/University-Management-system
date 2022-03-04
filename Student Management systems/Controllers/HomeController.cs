

using System.Web.Mvc;

namespace Student_Management_systems.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Administrator"))
            {
                return RedirectToAction("Home", "Admin");
            }
            if (User.Identity.IsAuthenticated && User.IsInRole("Trainer"))
            {
                return RedirectToAction("Home", "Trainer");
            }
            if (User.Identity.IsAuthenticated && User.IsInRole("Student"))
            {
                return RedirectToAction("Home", "Student");
            }
            else
                return View();
        }
    }
}