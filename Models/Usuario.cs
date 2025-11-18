using Newtonsoft.Json;

public class Usuario{
    [JsonProperty]
    public int IDUsuario{ get; private set; }
    [JsonProperty]
    public string nombre{ get; private set; }
    [JsonProperty]
    public string apellido{ get; private set; }
    [JsonProperty]
    public string email{ get; private set; }
    [JsonProperty]
    public string contrasena{ get; private set; }
    [JsonProperty]
    public int edad{ get; private set; }

    public Usuario()
    {

    }
}