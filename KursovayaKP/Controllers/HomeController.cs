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

		// Delete cookies
		public IActionResult Delete_cookies()
		{

			Response.Cookies.Delete("UserName");
			Response.Cookies.Delete("Email");
			Response.Cookies.Delete("Role");

			return RedirectToAction("Index", "Home");
		}
	}
}
