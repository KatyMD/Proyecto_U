using APIBomberos.Clases;
using Microsoft.AspNetCore.Mvc;

namespace APIBomberos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class TemaController : Controller
    {


        [HttpGet("ListaTema")]
        public ActionResult<object> list([FromQuery] string tema)
        {
   
            return this.Content(new Clstemas().listatemas(tema), "application/json", System.Text.Encoding.UTF8);
        }


    }
}
