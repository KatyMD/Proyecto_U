using APIBomberos.Clases;
using Microsoft.AspNetCore.Mvc;

namespace APIBomberos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class TemaController : Controller
    {




        [HttpGet("ListaTema")]
        public ActionResult<object> listatema()
        {
            return this.Content(new Clstemas().listatemas(), "application/json", System.Text.Encoding.UTF8);

        }

        [HttpGet("TemasExamen")]
        public ActionResult<object> listas([FromQuery] string idusuario)
        {

            return this.Content(new Clstemas().listaCursotemas(idusuario), "application/json", System.Text.Encoding.UTF8);
        } 

        [HttpGet("ContenidoTema")]
        public ActionResult<object> list([FromQuery] string idusuario, string idtema)
        {

            return this.Content(new Clstemas().listatems(idusuario, idtema), "application/json", System.Text.Encoding.UTF8);
        }

   

        [HttpGet("TemasUsuario")]
        public ActionResult<object> lista([FromQuery] string idusuario)
        {

            return this.Content(new Clstemas().listausuariotemas(idusuario), "application/json", System.Text.Encoding.UTF8);
        }



    }
}
