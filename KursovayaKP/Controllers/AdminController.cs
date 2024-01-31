using Microsoft.AspNetCore.Mvc;

namespace KursovayaKP.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult TestAdmin()
        {
            return View();
        }
    }
}
