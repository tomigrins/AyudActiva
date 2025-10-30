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
        return View("Login");
    }    
    // public IActionResult CrearUsuario(string)
    // public IActionResult ValidarUsuario(string usuario, string clave){
    //     int id = BD.Login(usuario, clave);

    //     if(id == 0){
    //         ViewBag.segundoIntento = true;
    //         return View ("SignIn");
    //     }
    //     else{
    //         HttpContext.Session.SetString("usuario", Objetos.ObjectToString(BD.GetUsuario(id)));
    //         ViewBag.usuario = BD.GetUsuario(id);
    //         return View("Index");
    //     }
    // }
    // public IActionResult SignIn(){
    //     ViewBag.segundoIntento = false;
    //     return View();
    // }
    // public IActionResult Desloguearse(){
    //     HttpContext.Session.Remove("usuario");
    //     return View("Index");
    // }
}
