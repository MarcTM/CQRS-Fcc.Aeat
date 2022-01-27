using System;

namespace Fcc.Aeat.Factura.Contracts.Models
{
    public class FacturaRequest
    {
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
