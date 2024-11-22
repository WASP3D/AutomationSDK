using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Wasp_WebSocketApp.Models;

namespace Wasp_WebSocketApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        // Serves the main page and passes WebSocket configuration to the view
        public IActionResult Index()
        {
            var portno = _configuration.GetValue<string>("WebSocket:Port");
            var url = _configuration.GetValue<string>("SourceOrigin:IP");

            // Create a ConfigModel with WebSocket port and URL, then pass it to the view
            ConfigModel config = new ConfigModel();
            config.PortNo = portno;
            config.URL = url;

            return View(config);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}