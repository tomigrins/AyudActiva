using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AyudActiva.Models;

namespace AyudActiva.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("Registrate");
    }
}
