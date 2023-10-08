using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using APIBomberos.Clases;

namespace APIBomberos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        [HttpPost("IniciarSesionadim")]
        public ActionResult<object> setDatosServidor([FromBody] ClsLogin login)
        {
            return this.Content(JsonSerializer.Serialize(login.iniciarsesionadmin()), "application/json", System.Text.Encoding.UTF8);
        }



        [HttpPost("IniciarSesionins")]
        public ActionResult<object> lognin([FromBody] ClsLogin login)
        {
            return this.Content(JsonSerializer.Serialize(login.iniciarsesionins()), "application/json", System.Text.Encoding.UTF8);
        }

        [HttpPost("IniciarSesionalum")]
        public ActionResult<object> lognalu([FromBody] ClsLogin login)
        {
            return this.Content(JsonSerializer.Serialize(login.iniciarsesionalum()), "application/json", System.Text.Encoding.UTF8);
        }

        [HttpPost("ReiniciarContra")]
        public ActionResult<object> reincia([FromBody] ClsReinicio login)
        {
            return this.Content(JsonSerializer.Serialize(login.reiniciarcontra()), "application/json", System.Text.Encoding.UTF8);
        }


    }

}
