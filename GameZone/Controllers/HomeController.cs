using System.Diagnostics;

namespace GameZone.Controllers
{
    public class HomeController : Controller
	{
		private readonly IGamesService _gameServices;

		public HomeController(IGamesService gameServices)
		{
            _gameServices = gameServices;
		}

		public IActionResult Index()
		{
			var games = _gameServices.GetAll();
			return View(games);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
