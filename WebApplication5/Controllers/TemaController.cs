﻿using APIBomberos.Clases;
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

        [HttpGet("ContenidoTemas")]
        public ActionResult<object> list([FromQuery] string idusuario)
        {

            return this.Content(new Clstemas().Contenidotema(idusuario), "application/json", System.Text.Encoding.UTF8);
        }

        [HttpGet("UsuarioTemas")]
        public ActionResult<object> list([FromQuery] string idusuario, string idtema)
        {

            return this.Content(new Clstemas().listaCursotemas(idusuario, idtema), "application/json", System.Text.Encoding.UTF8);
        }




    }
}
