using Microsoft.AspNetCore.Mvc;
using ZooNick.Data;
using ZooNick.Models;
using System.Linq;

namespace ZooNick.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ZooContext _context;

        public AnimalController(ZooContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var animals = _context.Animals.ToList(); // Retrieve the list of animals
            return View(animals); // Pass the list to the view
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Animals.Add(animal);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

public IActionResult Delete(int id)
{
    var animal = _context.Animals.Find(id); // Retrieve the animal by ID
    if (animal == null)
    {
        return NotFound(); // Return 404 if not found
    }
    _context.Animals.Remove(animal);
    _context.SaveChanges();
    return RedirectToAction(nameof(Index)); // Redirect to the index after deletion
}

public IActionResult Edit(int id)
{
    var animal = _context.Animals.Find(id);
    if (animal == null)
    {
        return NotFound();
    }

    // Zorg dat ViewBag altijd gevuld is
    ViewBag.Enclosures = _context.Enclosures.ToList();
    ViewBag.Categories = _context.Categories.ToList();

    return View(animal);
}

[HttpPost]
public IActionResult Edit(Animal animal)
{
    if (!ModelState.IsValid)
    {
        // Als er een fout is, moeten de dropdowns opnieuw worden gevuld
        ViewBag.Enclosures = _context.Enclosures.ToList();
        ViewBag.Categories = _context.Categories.ToList();

        return View(animal);
    }

    _context.Animals.Update(animal);
    _context.SaveChanges();
    return RedirectToAction(nameof(Index));
}
    }
}
