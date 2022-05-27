using Microsoft.AspNetCore.Mvc;
using MusicStore.Models;
using System.Diagnostics;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}