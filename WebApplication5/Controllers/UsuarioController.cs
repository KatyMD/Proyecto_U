using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using APIBomberos.Clases;
using APIBomberos.Respuestas;

namespace APIBomberos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("Listausurios")]
        public ActionResult<object> listaUsus()
        {
            return this.Content(new Clsgetusu().listausarios(), "application/json", System.Text.Encoding.UTF8);

        }

        [HttpGet("ListausuriosAlum")]
        public ActionResult<object> listaUsuari()
        {
            return this.Content(new Clsgetusu().listausariosAlum(), "application/json", System.Text.Encoding.UTF8);

        }


        [HttpGet("ListausuriosIns")]
        public ActionResult<object> listaUsuar()
        {
            return this.Content(new Clsgetusu().listausariosIns(), "application/json", System.Text.Encoding.UTF8);

        }




    }
}
