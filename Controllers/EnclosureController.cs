using Microsoft.AspNetCore.Mvc;
using ZooNick.Data;
using ZooNick.Models;
using System.Linq;

namespace ZooNick.Controllers
{
    public class EnclosureController : Controller
    {
        private readonly ZooContext _context;

        public EnclosureController(ZooContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var enclosures = _context.Enclosures.ToList(); // Retrieve the list of enclosures
            return View(enclosures); // Pass the list to the view
        }

public IActionResult Create()
{
    return View();
}

[HttpPost]
public IActionResult Create(Enclosure enclosure)
{
    if (ModelState.IsValid)
    {
        _context.Enclosures.Add(enclosure);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    return View(enclosure);
}

public IActionResult Delete(int id)
{
    var enclosure = _context.Enclosures.Find(id); // Retrieve the enclosure by ID
    if (enclosure == null)
    {
        return NotFound(); // Return 404 if not found
    }
    _context.Enclosures.Remove(enclosure);
    _context.SaveChanges();
    return RedirectToAction(nameof(Index)); // Redirect to the index after deletion
}


        public IActionResult Edit(int id)
        {
            var enclosure = _context.Enclosures.Find(id); // Retrieve the enclosure by ID
            if (enclosure == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return View(enclosure); // Pass the enclosure to the view
        }

        [HttpPost]
        public IActionResult Edit(Enclosure enclosure)
        {
            if (ModelState.IsValid)
            {
                _context.Enclosures.Update(enclosure);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(enclosure);
        }
    }
}
