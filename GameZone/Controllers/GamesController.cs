namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesService _categoriesServices;
        private readonly IDevicesService _devicesServcies;
        private readonly IGamesService _gameService;
        public GamesController(ICategoriesService categoriesServices, IDevicesService devicesServcies, IGamesService gameService)
        {
            _categoriesServices = categoriesServices;
            _devicesServcies = devicesServcies;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            var games = _gameService.GetAll();
            return View(games);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                Categories = _categoriesServices.GetSelectLists(),
                Devices = _devicesServcies.GetSelectLists(),
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetSelectLists();
                model.Devices = _devicesServcies.GetSelectLists();
                return View(model);
            }

            await _gameService.Create(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
