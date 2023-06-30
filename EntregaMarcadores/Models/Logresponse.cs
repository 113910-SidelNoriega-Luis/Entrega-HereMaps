namespace EntregaMarcadores.Models
{
    public class Logresponse
    {
        public string error { get; set; }
        public bool ok { get; set; }
        public string mensajeInfo { get; set; }
        public int statusCode { get; set; }
        public string idUsuario { get; set; }
        public string token { get; set; }
        public string emailUsuario { get; set; }
        public string urlImagen { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int idRol { get; set; }
        public string rolName { get; set; }
    }
}
