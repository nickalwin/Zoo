using Microsoft.AspNetCore.Mvc;
using ZooNick.Data;
using ZooNick.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ZooNick.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ZooContext _context;

        public AnimalController(ZooContext context)
        {
            _context = context;
        }

        // GET: Animals
        public IActionResult Index()
        {
            var animals = _context.Animals.ToList();
            return View(animals);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            ViewBag.Enclosures = GetEnclosures();
            ViewBag.Categories = GetCategories();
            return View();
        }

        // POST: Animals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(animal);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "An error occurred while saving the changes.");
                }
            }

            ViewBag.Enclosures = GetEnclosures();
            ViewBag.Categories = GetCategories();
            return View(animal);
        }

        // GET: Animals/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = _context.Animals.Include(a => a.Enclosure).Include(a => a.Category)
                .FirstOrDefault(m => m.Id == id);

            if (animal == null)
            {
                return NotFound();
            }

            ViewBag.Enclosures = GetEnclosures();
            ViewBag.Categories = GetCategories();
            return View(animal);
        }

        // POST: Animals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Animal updatedAnimal)
        {
            if (id != updatedAnimal.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingAnimal = _context.Animals.Find(id);
                    if (existingAnimal == null)
                    {
                        return NotFound();
                    }

                    existingAnimal.Name = updatedAnimal.Name;
                    existingAnimal.Species = updatedAnimal.Species;
                    existingAnimal.Age = updatedAnimal.Age;
                    existingAnimal.Size = updatedAnimal.Size;
                    existingAnimal.DietaryClass = updatedAnimal.DietaryClass;
                    existingAnimal.SecurityRequirement = updatedAnimal.SecurityRequirement;
                    existingAnimal.CategoryId = updatedAnimal.CategoryId;
                    existingAnimal.EnclosureId = updatedAnimal.EnclosureId;
                    existingAnimal.Prey = updatedAnimal.Prey; 
                    existingAnimal.SpaceRequirement = updatedAnimal.SpaceRequirement;
                    existingAnimal.ActivityPattern = updatedAnimal.ActivityPattern; 

                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error saving changes: {ex.Message}");
                }
            }

            ViewBag.Enclosures = GetEnclosures();
            ViewBag.Categories = GetCategories();
            return View(updatedAnimal);
        }

        // GET: Animals/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = _context.Animals.FirstOrDefault(m => m.Id == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var animal = _context.Animals.Find(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.Id == id);
        }

        private List<Enclosure> GetEnclosures()
        {
            return _context.Enclosures.Take(50).ToList();
        }

        private List<Category> GetCategories()
        {
            return _context.Categories.Take(50).ToList();
        }
    }
}