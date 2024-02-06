using KursovayaKP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KursovayaKP.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var role = HttpContext.Request.Cookies["Role"];

			if (role == "Admin")
			{
				return RedirectToAction("AdminIndex", "Admin");
			}

			return View();
		}

		public IActionResult TrafficRegulations()
		{
			return View();
		}

		public IActionResult RoadSigns()
		{
			return View();
		}

        public IActionResult MedicalCare()
        {
            return View();
        }

        public IActionResult CarDevice()
        {
            return View();
        }

        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
