using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using APIBomberos.Clases;

namespace APIBomberos.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : Controller
    {
        [HttpPost("IniciarSesion")]
        public ActionResult<object> setDatosServidor([FromBody] ClsLogin login)
        {
            return this.Content(JsonSerializer.Serialize(login.iniciarsesion()), "application/json", System.Text.Encoding.UTF8);
        }
    }
}
