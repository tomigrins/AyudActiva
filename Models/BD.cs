namespace AyudActiva.Models;
using Microsoft.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=AyudActiva1; Integrated Security=True; TrustServerCertificate=True;";


       public static Usuario Login(string username, string contrasena){
        Usuario aux = new Usuario();
        if (username != null && contrasena != null){
        using (SqlConnection connection = new SqlConnection(_connectionString)){
        string query = "SELECT * FROM Usuarios WHERE username = @username AND contrasena = @contrasena";
        aux = connection.QueryFirstOrDefault<Usuario>(query, new {username, contrasena});
        }         
        }
        return aux;
    }

    public static void RegistroUser (string nombre, string apellido, string username, string contrasena, string email, DateTime fechaNacimiento){
    string query ="INSERT INTO Usuarios (nombre, apellido, username, contrasena, email, fechaNacimiento) VALUES (@nombre, @apellido, @username, @contrasena, @email, @fechaNacimiento)";
        using (SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Execute(query, new{nombre, apellido, username, contrasena, email, fechaNacimiento});}
    }
	
  public static void RegistroOrg (string nombre, string latitud,string longitud, string email,string descripcion, string contrasena, string username){
    string query ="INSERT INTO Usuarios (nombre, latitud, longitud, contrasena, email, descripcion, username) VALUES (@nombre, @latitud, @longitud, @contrasena, @email, @descripcion, @username)";
        using (SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Execute(query, new{nombre, latitud, longitud, contrasena, email, descripcion, username});}
    }
    /*
    public static void nuevaTarea (string titulo, string descripcion, DateTime fecha, bool finalizada, int IDUsuario) {
        string query ="INSERT INTO Tareas (titulo, descripcion, fecha, finalizada, IDUsuario) VALUES (@titulo, @descripcion, @fecha, @finalizada, @IDUsuario)";
        using (SqlConnection connection = new SqlConnection(connectionString)){
        connection.Execute(query, new{titulo, descripcion, fecha, finalizada, IDUsuario});}
    }//{asegurar que el controller llene el IDUSuario antes de mandar el objeto tarea como parametro)

    public static void modificarTarea (int IDTarea, string titulo, string descripcion, DateTime fecha, bool finalizada, int IDUsuario){
        using (SqlConnection connection = new SqlConnection(connectionString)){
        string query = "UPDATE Tareas SET titulo = @titulo, descripcion = @descripcion, fecha = @fecha, finalizada = @finalizada, IDUsuario = @IDUsuario WHERE IDTarea = @IDTarea";
        connection.Execute(query, new{IDTarea, titulo, descripcion, fecha, finalizada, IDUsuario});}
        }         
    // (cuando el usuario quiere modificar la tarea y va al formulario, no queremos que aparezcan los espacios vacios, sino con la info llena p modificar)

	
    public static void eliminarTarea (int IDTarea){
    string query = "DELETE FROM Tareas WHERE IDTarea = @IDTarea";{
    using (SqlConnection connection = new SqlConnection(connectionString)){
        connection.Execute(query, new {IDTarea});}}
    }

    public static Tarea verTarea (int IDTarea){
        Tarea tarea = new Tarea();
        using (SqlConnection connection = new SqlConnection(connectionString)){
        string query = "SELECT titulo, descripcion, fecha, finalizada FROM Tareas WHERE IDTarea = @IDTarea";
        tarea = connection.QueryFirstOrDefault<Tarea>(query, new {IDTarea});
        }         
        return tarea;
    }
    
    public static List<Tarea> verTareas (int IDUsuario){
        List<Tarea> tareas = new List<Tarea>();
        using (SqlConnection connection = new SqlConnection(connectionString)){
        string query = "SELECT * FROM Tareas WHERE IDUsuario = @IDUsuario";
        tareas = connection.Query<Tarea>(query, new {IDUsuario}).ToList();
        }         
        return tareas;
    }
    

    public static void finalizarTarea(int IDTarea, bool finalizada){
        using (SqlConnection connection = new SqlConnection(connectionString)){
        string query = "UPDATE Tareas SET finalizada = @finalizada WHERE IDTarea = @IDTarea";
        connection.Execute(query, new{finalizada, IDTarea});}
    }


    public static void acualizarFecha (int IDUSuario){
        using (SqlConnection connection = new SqlConnection(connectionString)){
        string query = $"UPDATE Usuario SET ultLogin = {DateTime.Now} WHERE IDUsuario = @IDUsuario";
        connection.Execute(query, new{IDUSuario});}
}
*/

} 
