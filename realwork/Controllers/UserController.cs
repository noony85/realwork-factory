using Microsoft.AspNetCore.Mvc;

namespace realwork.Controllers
{
    public class UserController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
