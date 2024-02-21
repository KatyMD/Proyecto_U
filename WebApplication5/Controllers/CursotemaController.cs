using APIBomberos.Clases;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace APIBomberos.Controllers
{



    [ApiController]
    [Route("CursoTema")]
    public class CursotemaController : Controller
    {
        [HttpPost("AsignarCursotema")]
        public ActionResult<object> setDatosServidor([FromBody] Clscursotema agregar)
        {
            return this.Content(JsonSerializer.Serialize(agregar.AgregarCursotema()), "application/json", System.Text.Encoding.UTF8);
        }

        [HttpPut("ActualizarCursotema")]
        public ActionResult<object> setDasettosServidor([FromBody] Clscursotema actualiza)
        {
            return this.Content(JsonSerializer.Serialize(actualiza.ActualizarCursotema()), "application/json", System.Text.Encoding.UTF8);
        }


        [HttpPut("EstadoCursotema")]
        public ActionResult<object> setDatServidor([FromBody] Clscursotema estado)
        {
            return this.Content(JsonSerializer.Serialize(estado.EstadoCursotema()), "application/json", System.Text.Encoding.UTF8);

        }
        [HttpGet("ListaCursoTema")]
        public ActionResult<object> listacurte()
        {
            return this.Content(new ClsUsuarioCurso().listaCursoTema(), "application/json", System.Text.Encoding.UTF8);

        }



    }
}
