using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using usodeLinq.Models;

namespace usodeLinq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly EquiposContexts _equiposContext;
     

        public EquiposController(EquiposContexts equiposContext)
        {
            _equiposContext = equiposContext;

        }

        //Peticiones

        //Devolver TODOS LOS DATOS

        [HttpGet]
        [Route("OBTENER_TODOS_LOS_EQUIPOS_DETALLES")]

        public IActionResult Get()
        {
            var listadoequipo = (from e in _equiposContext.equipos
                                           join t in _equiposContext.tipo_equipo
                                           on e.tipo_equipo_id equals t.id_tipo_equipo
                                           join m in _equiposContext.marcas
                                           on   e.marca_id equals m.id_marcas
                                           join es in _equiposContext.estados_equipo
                                           on e.estado_equipo_id equals es.id_estados_equipo
                                           select new
                                           {
                                               e.id_equipos,
                                               e.nombre,
                                               e.descripcion,
                                               e.tipo_equipo_id,
                                               tipo_equipo= t.descripcion,
                                               e.marca_id,
                                               marca=m.nombre_marca,
                                               e.estado_equipo_id,
                                               estado_equipo=es.descripcion,
                                           }).ToList();

            if (listadoequipo.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoequipo);

        }






    }
}
