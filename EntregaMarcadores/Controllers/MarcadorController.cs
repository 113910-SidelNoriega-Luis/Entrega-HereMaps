using EntregaMarcadores.Models;
using EntregaMarcadores.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EntregaMarcadores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcadorController : ControllerBase
    {
        private static Dictionary<string, Logresponse> cache = new Dictionary<string, Logresponse>();

        [HttpPost]
        [Route("/loginUsuario")]
        public async Task<Logresponse> Logearse([FromBody] logUsuario loginUsuario)
        {
            try
            {
                PostGetProfe pgProfe = new PostGetProfe();
                Logresponse logresponse = await pgProfe.Login(loginUsuario);

                cache["lR"] = logresponse;

                return logresponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("/obtenerMarcadores")]
        public async Task<marcadoresResponse> GetMarcadores()
        {
            try
            {
                Logresponse lR = cache["lR"];

                PostGetProfe pgProfe = new PostGetProfe();
                marcadoresResponse mR = await pgProfe.GetMarcadores(lR.token);
                return mR;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
