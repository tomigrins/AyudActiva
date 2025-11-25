using Newtonsoft.Json;

public class Organizacion{
[JsonProperty]
    public int IDOrganizacion{ get; private set; }
[JsonProperty]    public string nombre{ get; private set; }
   [JsonProperty] public string email{ get; private set; }
  [JsonProperty]  public string contrasena{ get; private set; }
  [JsonProperty]  public string latitud { get; private set; }
  [JsonProperty]  public string longitud { get; private set; }
   [JsonProperty] public string username { get; private set; }
   [JsonProperty] public string descripcion { get; private set; }
     
}