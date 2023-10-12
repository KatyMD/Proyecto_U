using APIBomberos.Clases;
using Microsoft.AspNetCore.Mvc;

namespace APIBomberos.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : Controller
    {
        [HttpGet("MostrarExamen")]
        public ActionResult<object> list([FromQuery] string usuario)
        {

            return this.Content(new ClsExamen().MostrarExamen(usuario), "application/json", System.Text.Encoding.UTF8);
        }
    }
}
