using Newtonsoft.Json;

public class Donaciones{
    public int IDDonacion{ get; private set; }
    public int IDUsuario{ get; private set; }
    public int IDCampana{ get; private set; }
    public string tipoDonacion{ get; private set; }
    public string descripcion{ get; private set; }
    public DateTime fecha{ get; private set; }
    public string estado{ get; private set; }
    public int cantidad{ get; private set; }
    public int monto{ get; private set; }
    public bool animosidad{ get; private set; }
    public string rol{ get; private set; }
}