using Avtobus1ru_Test.MidLogic.Interfaces;
using Avtobus1ru_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Avtobus1ru_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILinkService _linkService;

        public HomeController(ILogger<HomeController> logger, ILinkService linkService)
        {
            _logger = logger;
            _linkService = linkService;
        }

        public IActionResult Index()
        {
            var linksData = _linkService.GetAllAsync();
            return View(linksData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
