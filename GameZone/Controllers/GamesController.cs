﻿namespace GameZone.Controllers
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
        public IActionResult Details (int id)
        {
            var game = _gameService.GetById(id);
            if (game is null)
                return NotFound();
            return View(game);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                Categories = _categoriesServices.GetSelectLists(),
                Devices = _devicesServcies.GetSelectLists()
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _gameService.GetById(id);
            if (game is null)
                return NotFound();
            EditGameFormViewModel viewModel = new()
            {
                Id=id,
                Name=game.Name,
                Description=game.Description,
                CategoryId=game.CategoryId,
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                Categories = _categoriesServices.GetSelectLists(),
                Devices = _devicesServcies.GetSelectLists(),
                CurrentCover = game.Cover,
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesServices.GetSelectLists();
                model.Devices = _devicesServcies.GetSelectLists();
                return View(model);
            }

            var game = await _gameService.Update(model);
            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _gameService.Delete(id);
            return isDeleted ? Ok() : BadRequest();
        }
    }
}
