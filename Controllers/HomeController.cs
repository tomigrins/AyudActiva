using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AyudActiva.Models;
using System.Text.Json;

namespace AyudActiva.Controllers;

public class HomeController : Controller
{
/*    HAY UN PROBLEMA EN EL LAYOUT*/
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
 public IActionResult LoginUser()
    {
        return View("LoginUser");
    } public IActionResult LoginOrg()
    {
        return View("LoginOrg");
    }
    [HttpPost]
    public IActionResult LoginGuardarUser(string username, string contrasena)
    {   
        ViewBag.Username = "";
        ViewBag.Contrasena = "";
        ViewBag.mensajeError = "Usuario o clave incorrecto";

        Usuario usuario = BD.LoginUser(username, contrasena);
        if(usuario != null){

            HttpContext.Session.SetString("Usuario", Objetos.ObjectToString(usuario)); 
                        return RedirectToAction("Index", "Home");
        }
        else{
        ViewBag.Username = username;
        ViewBag.Contrasena = contrasena;
                return View(LoginUser);
        }

    }
    public IActionResult LoginGuardarOrg(string username, string contrasena)
    {   
        ViewBag.Username = "";
        ViewBag.Contrasena = "";
        ViewBag.mensajeError = "Usuario o clave incorrecto";;

        Organizacion organizacion = BD.LoginOrg(username, contrasena);
        if(organizacion != null){

            HttpContext.Session.SetString("Organizacion", Objetos.ObjectToString(organizacion)); 
                        return RedirectToAction("Index", "Home");
        }
        else{
        ViewBag.Username = username;
        ViewBag.Contrasena = contrasena;
        return View(LoginOrg);
        }

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
        
        ViewBag.Nombre = nombre;
ViewBag.Apellido = apellido;
ViewBag.Username = username;
ViewBag.Email = email;
ViewBag.FechaNacimiento = fechaNacimiento.ToString("yyyy-MM-dd");
ViewBag.Contrasena = contrasena;
ViewBag.ConfirmarContrasena = confirmarContrasena;

        
        if(BD.repetirUsernameUser(username)){
            ViewBag.mensajeError = "ESE USERNAME YA EXISTE";
                    return View(RegistroUser);
        }
        else if (contrasena != confirmarContrasena){
            ViewBag.mensajeError = "LAS CONTRASEÑAS NO COINCIDEN";
                    return View(RegistroUser);}
        else if (nombre != null && apellido != null && username != null && contrasena != null && email != null && fechaNacimiento != null){
        BD.RegistroUser(nombre, apellido, username, contrasena, email, fechaNacimiento);
        HttpContext.Session.SetString("Usuario", Objetos.ObjectToString(BD.LoginUser(username, contrasena))); 
        }
        return RedirectToAction("Index","Home");
    }

    public IActionResult RegistroGuardarOrg(string nombre, string latitud,string longitud, string email,string descripcion,string username, string contrasena, string confirmarContrasena)
    {
        ViewBag.Nombre = nombre;
ViewBag.Latitud = latitud;
ViewBag.Longitud = longitud;
ViewBag.Email = email;
ViewBag.Descripcion = descripcion;
ViewBag.Username = username;
ViewBag.Contrasena = contrasena;
ViewBag.ConfirmarContrasena = confirmarContrasena;

        if(BD.repetirUsernameOrg(username)){
            ViewBag.mensajeError = "ESE USERNAME YA EXISTE";
                    return View(RegistroOrg);
        }
        else if (contrasena != confirmarContrasena){
            ViewBag.mensajeError = "LAS CONTRASEÑAS NO COINCIDEN";
                                return View(RegistroOrg);}
        else if (nombre != null && latitud != null && longitud != null && contrasena != null && email != null && descripcion != null && username != null){
        BD.RegistroOrg(nombre, latitud, longitud, contrasena, email, descripcion, username);
        HttpContext.Session.SetString("Organizacion", Objetos.ObjectToString(BD.LoginOrg(username, contrasena))); 
        }
  return RedirectToAction("Index","Home");
    }

    public IActionResult Desloguearse(){
        HttpContext.Session.Remove("Usuario");
        return View("Index");
    }
    public IActionResult Donar()
    {
    ViewBag.Ubicaciones = JsonSerializer.Serialize(BD.RecibirApi());
    ViewBag.UbicacionesDiv = BD.RecibirApi();
    ViewBag.Categorias = BD.TraerCategorias();
    return View();
    }
    public JsonResult FiltrarUbicaciones(int categoria)
    {
    var lista = BD.FiltrarApi(categoria);
    return Json(lista);
    }
    [HttpGet]
    public JsonResult FiltrarCampanas(int categoria)
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

    public IActionResult ViewCatDonaciones(){
        ViewBag.Categorias = BD.TraerCategorias();
        return View ("CatDonaciones");
    }
[HttpPost]
public IActionResult CatDonacionesGuardar(string[] intereses)
{
    // intereses tendrá los valores seleccionados
    // ej: ["musica", "cine"]
      string org = HttpContext.Session.GetString("Organizacion");

      if (org == null){
    return RedirectToAction ("Index", "Home");
      }
      
      Organizacion organizacion = Objetos.StringToObject<Organizacion>(org);
      int IDOrganizacion = organizacion.IDOrganizacion;


    foreach (var IDCatString in intereses)
    {
        int IDCategoria = int.Parse(IDCatString);
        BD.InsertarCategoriaOrg(IDOrganizacion, IDCategoria);
    }

    return View("Listo");
}


}
