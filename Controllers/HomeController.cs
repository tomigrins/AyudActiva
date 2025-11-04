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

    public IActionResult RegistroUser()
    {
        return View("RegistroUser");
    }
        public IActionResult RegistroOrg()
    {
        return View("RegistroOrg");
    }
    [HttpPost]
    public IActionResult RegistroGuardarUser(string nombre, string apellido,string username, string email, string contrasena, DateTime fechaNacimiento)
    {
        string devolver = "RegistroUser";
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

    public IActionResult RegistroGuardarOrg(string nombre, string latitud,string longitud, string email,string descripcion, string contrasena)
    {
        string devolver = "RegistroOrg";
        string confirmarContrasena = contrasena;
        if (contrasena != confirmarContrasena){
            ViewBag.mensajeError = "LAS CONTRASEÑAS NO COINCIDEN";}
        else if (nombre != null && latitud != null && longitud != null && contrasena != null && email != null && descripcion != null){
        BD.Registro(nombre, latitud, longitud, contrasena, email, descripcion);
        HttpContext.Session.SetString("Organizacion", Objetos.ObjectToString(BD.LoginOrg(username, contrasena))); 
        devolver = "Index";
        }
        return RedirectToAction(devolver, "Home");
    }

    public IActionResult Desloguearse(){
        HttpContext.Session.Remove("Usuario");
        return View("Index");
    }

/* METODO QUE TRAIGA DE LA BD LA LISTA DE CIERTA CATEGORIA
RECIBE X PARAMETRO LA CATEGORIA
MANDA A LA VIEW DONAR UNA LISTA Y EN LA VIEW SE RECORRE CON UN FOREACH

*/
/*HACER:
FOOTER
HEADER
AGREGAR REGIST
*/
}
