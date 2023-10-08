using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using APIBomberos.Clases;
using APIBomberos.Respuestas;
using System.Collections.Generic;

namespace APIBomberos.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioCursoController : Controller
    {
        [HttpPost("AsignarUsuarioCurso")]
        public ActionResult<object> setDatosServidor([FromBody] ClsUsuarioCurso agregar)
        {
            return this.Content(JsonSerializer.Serialize(agregar.AgregarUsuarioCurso()), "application/json", System.Text.Encoding.UTF8);
        }


        [HttpPut("EstadoUsuarioCurso")]
        public ActionResult<object> setDatServidor([FromBody] ClsUsuarioCurso estado)
        {
            return this.Content(JsonSerializer.Serialize(estado.EstadoUsuarioCurso()), "application/json", System.Text.Encoding.UTF8);

        }


        [HttpGet("ListausuriosCurso")]
        public ActionResult<object> listaUsus()
        {
            return this.Content(new ClsUsuario().listaUsuariocurso(), "application/json", System.Text.Encoding.UTF8);

        }





    }
}
