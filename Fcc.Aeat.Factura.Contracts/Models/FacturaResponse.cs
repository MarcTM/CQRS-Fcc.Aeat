using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Contracts.Models
{
    public class FacturaResponse
    {
        public int Id { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string Nif { get; set; }

        public string Pais { get; set; }

        public DateTime Fecha { get; set; }

        public byte Iva { get; set; }

        public decimal Importe { get; set; }

        public decimal Base { get; set; }
    }
}
