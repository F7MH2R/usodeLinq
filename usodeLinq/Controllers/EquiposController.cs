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

        //Devolver TODOS LOS DATOS union basica

        [HttpGet]
        [Route("OBTENER_TODO")]

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




        //Devolver TODOS LOS DATOS union basica con datos compuestos
        [HttpGet]
        [Route("OBTENER_TODOS_LOS_EQUIPOS_DETALLES")]

        public IActionResult getcompuesto()
        {
            var listadoequipo = (from e in _equiposContext.equipos
                                 join t in _equiposContext.tipo_equipo
                                 on e.tipo_equipo_id equals t.id_tipo_equipo
                                 join m in _equiposContext.marcas
                                 on e.marca_id equals m.id_marcas
                                 join es in _equiposContext.estados_equipo
                                 on e.estado_equipo_id equals es.id_estados_equipo
                                 select new
                                 {
                                     e.id_equipos,
                                     e.nombre,
                                     e.descripcion,
                                     e.tipo_equipo_id,
                                     tipo_equipo = t.descripcion,
                                     e.marca_id,
                                     marca = m.nombre_marca,
                                     e.estado_equipo_id,
                                     estado_equipo = es.descripcion,
                                     detalle = $"Tipo : {t.descripcion}, Marca : {m.nombre_marca}, Estado Equipo : {es.descripcion}"

                                 }).ToList();

            if (listadoequipo.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoequipo);

        }

        //Devolver el alcance deseado de LOS DATOS union basica con datos compuestos
        [HttpGet]
        [Route("obtener_alcance")]

        public IActionResult g_alcance_com()
        {
            var listadoequipo = (from e in _equiposContext.equipos
                                 join t in _equiposContext.tipo_equipo
                                 on e.tipo_equipo_id equals t.id_tipo_equipo
                                 join m in _equiposContext.marcas
                                 on e.marca_id equals m.id_marcas
                                 join es in _equiposContext.estados_equipo
                                 on e.estado_equipo_id equals es.id_estados_equipo
                                 select new
                                 {
                                     e.id_equipos,
                                     e.nombre,
                                     e.descripcion,
                                     e.tipo_equipo_id,
                                     tipo_equipo = t.descripcion,
                                     e.marca_id,
                                     marca = m.nombre_marca,
                                     e.estado_equipo_id,
                                     estado_equipo = es.descripcion,
                                     detalle = $"Tipo : {t.descripcion}, Marca : {m.nombre_marca}, Estado Equipo : {es.descripcion}"

                                 }).Take(1).ToList();

            if (listadoequipo.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoequipo);

        }

        //Devolver el alcance deseado de LOS DATOS union basica con datos compuestos y añadiendo saltos de resultados
        [HttpGet]
        [Route("obtener_alcance_y_salto")]

        public IActionResult gsalto()
        {
            var listadoequipo = (from e in _equiposContext.equipos
                                 join t in _equiposContext.tipo_equipo
                                 on e.tipo_equipo_id equals t.id_tipo_equipo
                                 join m in _equiposContext.marcas
                                 on e.marca_id equals m.id_marcas
                                 join es in _equiposContext.estados_equipo
                                 on e.estado_equipo_id equals es.id_estados_equipo
                                 select new
                                 {
                                     e.id_equipos,
                                     e.nombre,
                                     e.descripcion,
                                     e.tipo_equipo_id,
                                     tipo_equipo = t.descripcion,
                                     e.marca_id,
                                     marca = m.nombre_marca,
                                     e.estado_equipo_id,
                                     estado_equipo = es.descripcion,
                                     detalle = $"Tipo : {t.descripcion}, Marca : {m.nombre_marca}, Estado Equipo : {es.descripcion}"

                                 }).Skip(10).Take(10).ToList();

            if (listadoequipo.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoequipo);

        }

        //Devolver el alcance deseado de LOS DATOS union basica con datos compuestos y añadiendo saltos de resultados con ordenamiento basico
        [HttpGet]
        [Route("obtener_ordenamiento_basico")]

        public IActionResult ordenamiento_basic()
        {
            var listadoequipo = (from e in _equiposContext.equipos
                                 join t in _equiposContext.tipo_equipo
                                 on e.tipo_equipo_id equals t.id_tipo_equipo
                                 join m in _equiposContext.marcas
                                 on e.marca_id equals m.id_marcas
                                 join es in _equiposContext.estados_equipo
                                 on e.estado_equipo_id equals es.id_estados_equipo
                                 select new
                                 {
                                     e.id_equipos,
                                     e.nombre,
                                     e.descripcion,
                                     e.tipo_equipo_id,
                                     tipo_equipo = t.descripcion,
                                     e.marca_id,
                                     marca = m.nombre_marca,
                                     e.estado_equipo_id,
                                     estado_equipo = es.descripcion,
                                     detalle = $"Tipo : {t.descripcion}, Marca : {m.nombre_marca}, Estado Equipo : {es.descripcion}"

                                 }).OrderBy(resultado=> resultado.estado_equipo_id).ToList();

            if (listadoequipo.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoequipo);

        }
        //Devolver el alcance deseado de LOS DATOS union basica con datos compuestos y añadiendo saltos de resultados
        [HttpGet]
        [Route("Obtener_advanceOrder")]

        public IActionResult orden_advance()
        {
            var listadoequipo = (from e in _equiposContext.equipos
                                 join t in _equiposContext.tipo_equipo
                                 on e.tipo_equipo_id equals t.id_tipo_equipo
                                 join m in _equiposContext.marcas
                                 on e.marca_id equals m.id_marcas
                                 join es in _equiposContext.estados_equipo
                                 on e.estado_equipo_id equals es.id_estados_equipo
                                 select new
                                 {
                                     e.id_equipos,
                                     e.nombre,
                                     e.descripcion,
                                     e.tipo_equipo_id,
                                     tipo_equipo = t.descripcion,
                                     e.marca_id,
                                     marca = m.nombre_marca,
                                     e.estado_equipo_id,
                                     estado_equipo = es.descripcion,
                                     detalle = $"Tipo : {t.descripcion}, Marca : {m.nombre_marca}, Estado Equipo : {es.descripcion}"

                                 }).OrderBy(resultado => resultado.estado_equipo_id)
                                 .ThenBy(resultado=>resultado.marca_id)
                                 .ThenBy(resultado=>resultado.tipo_equipo_id).ToList();

            if (listadoequipo.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoequipo);

        }
    }
}
