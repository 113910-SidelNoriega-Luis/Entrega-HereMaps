using EntregaMarcadores.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace EntregaMarcadores.Services
{
    public class PostGetProfe
    {
        public async Task<Logresponse> Login(logUsuario l)
        {
            string url = "https://prog3.nhorenstein.com/api/usuario/LoginUsuarioWeb";
            using (var client = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(new logUsuario()
                {
                    nombreUsuario = l.nombreUsuario,
                    password = l.password
                });
                var response = await client.PostAsync(url, new
                StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<Logresponse>(responseBody);
                    return resultado;
                }
                else
                {
                    throw new Exception($"La solicitud de inicio de sesión falló. Código de estado: {response.StatusCode}");
                }
            }
        }

        public async Task<marcadoresResponse> GetMarcadores(string token)
        {
            string url = "https://prog3.nhorenstein.com/api/marcador/GetMarcadores";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<marcadoresResponse>(content);
                return result;
            }
        }
    }
}
