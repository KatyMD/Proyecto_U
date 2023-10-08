using APIBomberos.Clases;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIBomberos.Controllers
{


    [Route("api/[controller]")]
    [ApiController]

    public class ControllerCurso : Controller
    {

        [HttpPost("AgregarCurso")]
        public ActionResult<object> setDatosServidor([FromBody] ClsCurso agregar)
        {
            return this.Content(JsonSerializer.Serialize(agregar.AgregarCurso()), "application/json", System.Text.Encoding.UTF8);
        }


        [HttpPut("ActualizarCurso")]
        public ActionResult<object> setDatoServidor([FromBody] ClsCurso actualizar)
        {
            return this.Content(JsonSerializer.Serialize(actualizar.ActualizarCurso()), "application/json", System.Text.Encoding.UTF8);

        }

        [HttpPut("EstadoCurso")]
        public ActionResult<object> setDatServidor([FromBody] ClsCurso estado)
        {
            return this.Content(JsonSerializer.Serialize(estado.EstadoCurso()), "application/json", System.Text.Encoding.UTF8);

        }

        [HttpGet("ListaCurso")]
        public ActionResult<object> listaUsuari()
        {
            return this.Content(new ClsCurso().listaCurso(), "application/json", System.Text.Encoding.UTF8);


        }



        }
}
