using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WebApplication1.Models;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
	public class UserController : Controller
	{
		private readonly ILogger<UserController> _logger;

		public UserController(ILogger<UserController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(User user)
		{
			user.OnlyDate();
			string json = JsonConvert.SerializeObject(user);
			var arr = json.Split(",");

			for (int i = 0; i < arr.Length; i++)
			{
				System.IO.File.AppendAllText("output.json", arr[i] + "\n");
			}

			return RedirectToAction("Success");
		}

		public ActionResult Success()
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