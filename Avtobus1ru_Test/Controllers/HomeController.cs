using Avtobus1ru_Test.MidLogic.Interfaces;
using Avtobus1ru_Test.MidLogic.Models;
using Avtobus1ru_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
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


        public async Task<IActionResult> Index()
        {
            string redirrectionURL = $"{Request.Scheme}://{Request.Host}/shortlink/";
            var linksData = await _linkService.GetAllAsync(redirrectionURL);
            return View(linksData);
        }


        [HttpPost]
        public async Task<IActionResult> CreateNewLink(string longURL)
        {
            await _linkService.CreateAsync(longURL);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLink(LinkModel linkModel)
        {
            await _linkService.UpdateAsync(linkModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLink(int id)
        {
            await _linkService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
