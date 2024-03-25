using Microsoft.AspNetCore.Mvc;

namespace aspnetmvc.Controllers
{
    public class CoursesController : Controller
    {
        [Route("/courses")]
        public IActionResult Courses()
        {
            return View();
        }
    }
}
