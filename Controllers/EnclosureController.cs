using Microsoft.AspNetCore.Mvc;
using ZooNick.Models;

namespace ZooNick.Controllers
{
    public class EnclosureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}
