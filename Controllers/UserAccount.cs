// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using AyudActiva.Models;

// namespace AyudActiva.Controllers;

// public class UserAccount : Controller
// {
//      public IActionResult Login()
//     {
//         return View("Login");
//     }

//     [HttpPost]
//     public IActionResult LoginGuardar(string email, string contraseña)
//     {   
//         ViewBag.mensajeError = "";
//         string devolver = "Login";
//         string devolverController = "UserAccount";
//         Usuario usuario = BD.Login(email, contraseña);
//         if(usuario != null){
//             devolver = "VerTareas";
//             devolverController = "Home";
//         HttpContext.Session.SetString("Usuario", usuario.IDUsuario.ToString()); 
//         }else{
//             ViewBag.mensajeError = "Usuario o clave incorrecto";
//         }
//         return RedirectToAction(devolver, devolverController);
//     }
//     public IActionResult Registro()
//     {
//         return View("Registrarse");
//     }
//     [HttpPost]
//     public IActionResult RegistroGuardar(string nombre, string apellido, string usuario, string contraseña, string confirmarContraseña)
//     {
//         string prueba = "PRUEBA";
//         string devolver = "Registro";
//         if (contraseña != confirmarContraseña){
//             ViewBag.mensajeError = "LAS CONTRASEÑAS NO COINCIDEN";}
//         else if (nombre != null && apellido != null && usuario != null && contraseña != null && prueba != null){
//         BD.Registro(nombre, apellido, usuario, contraseña, prueba, (DateTime.Now));
//         Usuario aux = new Usuario();
//         aux = BD.Login (usuario, contraseña);
//         HttpContext.Session.SetString("Usuario", aux.IDUsuario.ToString()); 
//         devolver = "VerTareas";
//         }

//         return RedirectToAction(devolver, "Home");
//     }
// }