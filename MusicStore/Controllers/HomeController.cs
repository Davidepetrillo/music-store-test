using Microsoft.AspNetCore.Mvc;
using MusicStore.Data;
using MusicStore.Models;
using System.Diagnostics;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        public IActionResult Home()
        {
            return View("HomePage");
        }
        [HttpGet]
        public IActionResult CategoriaStrumento(int id)
        {
            return View("CategoriaStrumento", id);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View("Details", id);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

    }
}