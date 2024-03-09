using System.ComponentModel.DataAnnotations;

namespace usodeLinq.Models
{
    public class estadoEquipo
    {
        [Key]
        public int id_estados_equipo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }

    }
}
