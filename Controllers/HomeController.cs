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
        return View("Index");
    }    

 public IActionResult Login()
    {
        return View("Login");
    }

    [HttpPost]
    public IActionResult LoginGuardar(string username, string contraseña)
    {   
        ViewBag.mensajeError = "";
        string devolver = "Login";
        string devolverController = "UserAccount";
        Usuario usuario = BD.Login(username, contraseña);
        if(usuario != null){
            devolver = "Index";
            devolverController = "Home";
        HttpContext.Session.SetString("Usuario", Objetos.ObjectToString(usuario)); 
        }else{
            ViewBag.mensajeError = "Usuario o clave incorrecto";
        }
        return RedirectToAction(devolver, devolverController);
    }

    public IActionResult Registro()
    {
        return View("Registro");
    }
    [HttpPost]
    public IActionResult RegistroGuardar(string nombre, string apellido,string username, string email, string contrasena, DateTime fechaNacimiento)
    {
        string devolver = "Registro";
        string confirmarContrasena = contrasena;
        if (contrasena != confirmarContrasena){
            ViewBag.mensajeError = "LAS CONTRASEÑAS NO COINCIDEN";}
        else if (nombre != null && apellido != null && username != null && contrasena != null && email != null && fechaNacimiento != null){
        BD.Registro(nombre, apellido, username, contrasena, email, fechaNacimiento);
        HttpContext.Session.SetString("Usuario", Objetos.ObjectToString(BD.Login(username, contrasena))); 
        devolver = "Index";
        }
        return RedirectToAction(devolver, "Home");
    }

    public IActionResult Desloguearse(){
        HttpContext.Session.Remove("Usuario");
        return View("Index");
    }

}
