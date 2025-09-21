using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

public class UserController : Controller
{
	[Authorize]
	public IActionResult Index()
	{
		return View();
	}
}
