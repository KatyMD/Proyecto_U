using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using APIBomberos.Clases;

namespace APIBomberos.Controllers
{

    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : Controller
    {
        [HttpPost("AgregarUsuario")]
        public ActionResult<object> setDatosServidor([FromBody] ClsUsuario agregar)
        {
            return this.Content(JsonSerializer.Serialize(agregar.AgregarUsuario()), "application/json", System.Text.Encoding.UTF8);
        }


        [HttpPut("ActualizarUsuario")]
        public ActionResult<object> setDatoServidor([FromBody] ClsUsuario actualizar)
        {
            return this.Content(JsonSerializer.Serialize(actualizar.ActualizarUsuario()), "application/json", System.Text.Encoding.UTF8);

        }

        [HttpPut("EstadoUsuario")]
        public ActionResult<object> setDatServidor([FromBody] ClsUsuario estado)
        {
            return this.Content(JsonSerializer.Serialize(estado.EstadoUsuario()), "application/json", System.Text.Encoding.UTF8);

        }
    }
}
