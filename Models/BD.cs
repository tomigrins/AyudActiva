namespace AyudActiva.Models;
using Microsoft.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=AyudActiva1; Integrated Security=True; TrustServerCertificate=True;";


       public static Usuario LoginUser(string username, string contrasena){
        Usuario aux = new Usuario();
        if (username != null && contrasena != null){
        using (SqlConnection connection = new SqlConnection(_connectionString)){
        string query = "SELECT * FROM Usuarios WHERE username = @username AND contrasena = @contrasena";
        aux = connection.QueryFirstOrDefault<Usuario>(query, new {username, contrasena});
        }         
        }
        return aux;
    }       
    
    public static Organizacion LoginOrg(string username, string contrasena){
        Organizacion aux = new Organizacion();
        if (username != null && contrasena != null){
        using (SqlConnection connection = new SqlConnection(_connectionString)){
        string query = "SELECT * FROM Organizaciones WHERE username = @username AND contrasena = @contrasena";
        aux = connection.QueryFirstOrDefault<Organizacion>(query, new {username, contrasena});
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
    string query ="INSERT INTO Organizaciones (nombre, latitud, longitud, contrasena, email, descripcion, username) VALUES (@nombre, @latitud, @longitud, @contrasena, @email, @descripcion, @username)";
        using (SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Execute(query, new{nombre, latitud, longitud, contrasena, email, descripcion, username});}
    }

        public static bool repetirUsernameUser(string username)
        {
            string query = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Usuarios WHERE username = @username) THEN 1 ELSE 0 END";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>(query, new { username }) == 1;
            }
        }
        public static bool repetirUsernameOrg(string username)
        {
            string query = @"
                SELECT CASE WHEN EXISTS(SELECT 1 FROM Organizaciones WHERE username = @username) THEN 1 ELSE 0 END";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>(query, new { username }) == 1;
            }
        }
    public static List<Ubicaciones> RecibirApi(){
        List<Ubicaciones> Lista  = new List<Ubicaciones>();
        string query = "select nombre as titulo, latitud, longitud from Organizaciones";
        using (SqlConnection connection = new SqlConnection(_connectionString)){
            Lista = connection.Query<Ubicaciones>(query).ToList();
        }
        return Lista;
    }
     public static List<Categoria> TraerCategorias(){
        List<Categoria> Lista  = new List<Categoria>();
        string query = "select * from CategoriasDonaciones";
        using (SqlConnection connection = new SqlConnection(_connectionString)){
            Lista = connection.Query<Categoria>(query).ToList();
        }
        return Lista;
    }
    public static List<Ubicaciones> FiltrarApi(int categoria){
    List<Ubicaciones> Lista  = new List<Ubicaciones>();
    string query = @"select Organizaciones.nombre as titulo, latitud, longitud 
                     from Organizaciones 
                     inner join OrgCat on Organizaciones.IDOrganizacion = OrgCat.IDOrganizacion 
                     where OrgCat.IDCategoriaDonacion = @categoria";

    using (SqlConnection connection = new SqlConnection(_connectionString)){
        Lista = connection.Query<Ubicaciones>(query, new { categoria }).ToList(); // ✅ PASAMOS EL PARÁMETRO
    }
    return Lista;
}

public static void InsertarCategoriaOrg(int IDOrganizacion, int IDCategoriaDonacion)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "INSERT INTO OrgCat (IDOrganizacion, IDCategoriaDonacion) VALUES (@IDOrganizacion, @IDCategoriaDonacion)";

        connection.Execute(query, new {IDOrganizacion, IDCategoriaDonacion });
    }
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
