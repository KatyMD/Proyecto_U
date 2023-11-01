using APIBomberos.Clases;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIBomberos.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : Controller
    {

        [HttpGet("MostrarExamen")]
        public ActionResult<object> list([FromQuery] string usuario, string idtema)
        {

            return this.Content(new ClsExamen().MostrarExamen(usuario, idtema), "application/json", System.Text.Encoding.UTF8);
        }

        [HttpPost("AgregarExamenUsu")]
        public ActionResult<object> setDatosServidor([FromBody] ClsExamen agregar)
        {
            return this.Content(JsonSerializer.Serialize(agregar.ingresarexamen()), "application/json", System.Text.Encoding.UTF8);
        }



    }
}
