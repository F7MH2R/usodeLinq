using System.ComponentModel.DataAnnotations;

namespace usodeLinq.Models
{
    public class TipoEquipo
    {
        [Key]
        public int id_tipo_equipo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
    }
}
