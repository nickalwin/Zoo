using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ZooNick.Models;
using ZooNick.Data; // Add this line for accessing ZooContext
using System.Linq; // Add this line for LINQ functionality

namespace ZooNick.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ZooContext _context; // Add context for database access

    public HomeController(ILogger<HomeController> logger, ZooContext context)
    {
        _logger = logger;
        _context = context; // Initialize context
    }

    public IActionResult Index()
    {
        var animals = _context.Animals.ToList();
        var enclosures = _context.Enclosures.ToList();
        var categories = _context.Categories.ToList();

        ViewBag.Animals = animals;
        ViewBag.Enclosures = enclosures;
        ViewBag.Categories = categories;

        return View();
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
