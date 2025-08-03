using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobleHabitat.Shared.DTOs
{
    public class CaracteristicaInmuebleDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Valor { get; set; } = default!;
        public Guid InmuebleId { get; set; }
    }
}
