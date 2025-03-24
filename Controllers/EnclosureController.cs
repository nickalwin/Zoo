using Microsoft.AspNetCore.Mvc;
using ZooNick.Data;
using ZooNick.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore; 

namespace ZooNick.Controllers
{
    public class EnclosureController : Controller
    {
        private readonly ZooContext _context;

        public EnclosureController(ZooContext context)
        {
            _context = context;
        }

        // GET: Enclosures
        public IActionResult Index()
        {
            var enclosures = _context.Enclosures.OrderBy(e => e.Id).ToList();
            return View(enclosures);
        }

        // GET: Enclosures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enclosures/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Enclosure enclosure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enclosure);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(enclosure);
        }

        // GET: Enclosures/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure = _context.Enclosures.Find(id);
            if (enclosure == null)
            {
                return NotFound();
            }
            if (enclosure == null)
            {
                return NotFound();
            }
            return View(enclosure);
        }

        // POST: Enclosures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Enclosure enclosure)
        {
            if (id != enclosure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enclosure);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnclosureExists(enclosure.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(enclosure);
        }

        // GET: Enclosures/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure = _context.Enclosures
                .FirstOrDefault(m => m.Id == id);
            if (enclosure == null)
            {
                return NotFound();
            }

            return View(enclosure);
        }

        // POST: Enclosures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var enclosure = _context.Enclosures.Find(id);
            if (enclosure != null)
            {
                _context.Enclosures.Remove(enclosure);
            }
            else
            {
                return NotFound();
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool EnclosureExists(int id)
        {
            return _context.Enclosures.Any(e => e.Id == id);
        }
    }
}
