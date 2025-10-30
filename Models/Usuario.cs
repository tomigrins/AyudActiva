using Newtonsoft.Json;

public class Usuario{
    public int IDUsuario{ get; private set; }
    public string nombre{ get; private set; }
    public string apellido{ get; private set; }
    public string email{ get; private set; }
    public string contrasena{ get; private set; }
    public int edad{ get; private set; }
}