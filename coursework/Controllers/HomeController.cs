
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using coursework.Models;
using Microsoft.EntityFrameworkCore;


namespace coursework.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        FeedbackContext db;
        public HomeController(FeedbackContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("/home/feedback")]
        public async Task<IActionResult> Feedback(int? id)
        {
            
            var viewOrder = View(await db.Feedbacks.ToListAsync());
            return viewOrder;
        }
        [HttpPost]
        public async Task<IActionResult> Index(Feedback feedback)
        {
            db.Feedbacks.Add(feedback);
            // сохраняем в бд все изменения
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
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