using Avtobus1ru_Test.Controllers;
using Avtobus1ru_Test.MidLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPad.Api
{
    [Route("r")]
    [ApiController]
    public class RedirectionController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILinkService _linkService;

        public RedirectionController(ILogger<HomeController> logger, ILinkService linkService)
        {
            _logger = logger;
            _linkService = linkService;
        }


        [HttpGet("{shortURLkey}")]
        public async Task<IActionResult> RedirectFromShortToLong(string shortURLkey)
        {
            string longURL = await _linkService.GetLongFromShortAsync(shortURLkey);
            return Redirect(longURL);
        }
    }
}
