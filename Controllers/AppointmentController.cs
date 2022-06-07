using Microsoft.AspNetCore.Mvc;

namespace InAndOut.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index() //error if dont return; Right click on IActionResult to create a View
        {
            return View();
            
        }

        public IActionResult Details(int id)
        {
            return Ok("You have entered id = " + id); //USE 'OK' TO TEST SIMPLE THINGS
        }
    }
}
