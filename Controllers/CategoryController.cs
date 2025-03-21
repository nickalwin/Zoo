using Microsoft.AspNetCore.Mvc;
using ZooNick.Data;
using ZooNick.Models;
using System.Linq;

namespace ZooNick.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ZooContext _context;

        public CategoryController(ZooContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList(); // Retrieve the list of categories
            return View(categories); // Pass the list to the view
        }

public IActionResult Create()
{
    return View();
}

[HttpPost]
public IActionResult Create(Category category)
{
    if (ModelState.IsValid)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    return View(category);
}

public IActionResult Delete(int id)
{
    var category = _context.Categories.Find(id); // Retrieve the category by ID
    if (category == null)
    {
        return NotFound(); // Return 404 if not found
    }
    _context.Categories.Remove(category);
    _context.SaveChanges();
    return RedirectToAction(nameof(Index)); // Redirect to the index after deletion
}


        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id); // Retrieve the category by ID
            if (category == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return View(category); // Pass the category to the view
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
    }
}
