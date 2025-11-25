using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AyudActiva.Models;
using System.Text.Json;

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
            return View();
        }
    
 public IActionResult Login()
    {
        return View("Login");
    }

    [HttpPost]
    public IActionResult LoginGuardarUser(string username, string contrasena)
    {   
        ViewBag.mensajeError = "Usuario o clave incorrecto";;
        string devolver = "Login";
        Usuario usuario = BD.LoginUser(username, contrasena);
        if(usuario != null){
            devolver = "Index";
            HttpContext.Session.SetString("Usuario", Objetos.ObjectToString(usuario)); 
        }
        return View(devolver);
    }
    public IActionResult LoginGuardarOrg(string username, string contrasena)
    {   
        ViewBag.mensajeError = "Usuario o clave incorrecto";;
        string devolver = "Login";
        Organizacion organizacion = BD.LoginOrg(username, contrasena);
        if(organizacion != null){
            devolver = "Index";
            HttpContext.Session.SetString("Organizacion", Objetos.ObjectToString(organizacion)); 
        }
        return View(devolver);
    }

    public IActionResult Registro()
    {
        return View("Registro");
    }
    public IActionResult RegistroUser()
    {
        return View("RegistroUser");
    }
        public IActionResult RegistroOrg()
    {
        return View("RegistroOrg");
    }
    [HttpPost]
    public IActionResult RegistroGuardarUser(string nombre, string apellido,string username, string email, DateTime fechaNacimiento, string contrasena, string confirmarContrasena)
    {
        string devolver = "RegistroUser";
        if(BD.repetirUsernameUser(username)){
            ViewBag.mensajeError = "ESE USERNAME YA EXISTE";
        }
        else if (contrasena != confirmarContrasena){
            ViewBag.mensajeError = "LAS CONTRASEÑAS NO COINCIDEN";}
        else if (nombre != null && apellido != null && username != null && contrasena != null && email != null && fechaNacimiento != null){
        BD.RegistroUser(nombre, apellido, username, contrasena, email, fechaNacimiento);
        HttpContext.Session.SetString("Usuario", Objetos.ObjectToString(BD.LoginUser(username, contrasena))); 
        devolver = "Index";
        }
        return View(devolver);
    }

    public IActionResult RegistroGuardarOrg(string nombre, string latitud,string longitud, string email,string descripcion,string username, string contrasena, string confirmarContrasena)
    {
        string devolver = "RegistroOrg";
        if(BD.repetirUsernameOrg(username)){
            ViewBag.mensajeError = "ESE USERNAME YA EXISTE";
        }
        else if (contrasena != confirmarContrasena){
            ViewBag.mensajeError = "LAS CONTRASEÑAS NO COINCIDEN";}
        else if (nombre != null && latitud != null && longitud != null && contrasena != null && email != null && descripcion != null && username != null){
        BD.RegistroOrg(nombre, latitud, longitud, contrasena, email, descripcion, username);
        HttpContext.Session.SetString("Organizacion", Objetos.ObjectToString(BD.LoginOrg(username, contrasena))); 
        devolver = "Index";
        }
        return View(devolver);
    }

    public IActionResult Desloguearse(){
        HttpContext.Session.Remove("Usuario");
        return View("Index");
    }
    public IActionResult Donar()
    {
    ViewBag.Ubicaciones = JsonSerializer.Serialize(BD.RecibirApi());
    ViewBag.UbicacionesDiv = BD.RecibirApi();
    return View();
    }
    public JsonResult FiltrarUbicaciones(string categoria)
    {
    var lista = BD.FiltrarApi(categoria);
    return Json(lista);
    }
    [HttpGet]
    public JsonResult FiltrarCampanas(string categoria)
    {
    var lista = BD.FiltrarApi(categoria); // mismo filtro que ubicaciones
    return Json(lista);
    }


    public IActionResult ViewDonar(){
        return View("Donar");
    }    public IActionResult ViewHistorial(){
        return View("Historial");
    }    public IActionResult ViewFinanciar(){
        return View("Financiar");
    }
    public IActionResult ViewONGInfo(){
        return View("ONGInfo");
    }
}
