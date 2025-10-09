namespace TP02.Models;
using Microsoft.Data.SqlClient;
using Dapper;

public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=Presentacion; Integrated Security=True; TrustServerCertificate=True;";

    public static int Login(string email, string contraseña){
        int Id = 0;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string query = "SELECT Id FROM Usuario WHERE Email = @email AND Contraseña = @contraseña";
            Id = connection.QueryFirstOrDefault<int>(query, new { email,  contraseña});
        }
        return Id; //Devuelve -1 si no lo encontro. sino la id del usuario.
    }
    public static Usuario GetUsuario(int id){
        Usuario usuario = null;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string query = "SELECT * FROM Usuario WHERE Id = @id";
            usuario = connection.QueryFirstOrDefault<Usuario>(query, new {id});
        }
        return usuario; //Lo mismo que Login
    }
} 
