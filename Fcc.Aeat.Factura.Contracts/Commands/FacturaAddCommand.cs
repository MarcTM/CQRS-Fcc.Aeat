using Fcc.Aeat.Factura.Contracts.Models;
using MediatR;
using System;

namespace Fcc.Aeat.Factura.Contracts.Commands
{
    public class FacturaAddCommand : IRequest<FacturaResponse>
    {
        public string Nif { get; set; }

        public string Pais { get; set; }

        public DateTime Fecha { get; set; }

        public byte Iva { get; set; }

        public decimal Importe { get; set; }

        public decimal Base { get; set; }
    }
}
