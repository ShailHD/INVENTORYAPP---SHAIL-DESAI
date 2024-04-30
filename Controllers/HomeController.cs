using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InventoryApp.Models; 
namespace InventoryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor injects a logger for logging information within the controller
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action method for the home page (e.g., http://localhost:5000/ or http://localhost:5000/Home)
        public IActionResult Index()
        {
            return View(); // Returns the Index view
        }

        // Action method for the privacy page (e.g., http://localhost:5000/Home/Privacy)
        public IActionResult Privacy()
        {
            return View(); // Returns the Privacy view
        }

        // Action method for handling errors. It uses the ErrorViewModel to pass error information to the view.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // This code creates an instance of ErrorViewModel with the current request's ID
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
