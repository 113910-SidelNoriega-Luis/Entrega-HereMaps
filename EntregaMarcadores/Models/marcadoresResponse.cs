namespace EntregaMarcadores.Models
{
    public class marcadoresResponse
    {
        public string error { get; set; }
        public bool ok { get; set; }
        public string mensajeInfo { get; set; }
        public int statusCode { get; set; }
        public List<Marcadores> litadoMarcadores { get; set; }
    }
}
