using System.Threading;
using System.Threading.Tasks;
using Fcc.Aeat.Factura.Contracts.Commands;
using Fcc.Aeat.Factura.Contracts.Contracts;
using Fcc.Aeat.Factura.Contracts.Models;
using MediatR;

namespace Fcc.Aeat.Factura.Handlers
{
    public class FacturaAddCommandHandler : IRequestHandler<FacturaAddCommand, FacturaResponse>
    {
        private readonly IAddFacturaManager _iAddFacturaManager;

        public FacturaAddCommandHandler(IAddFacturaManager iAddFacturaManager)
        {
            _iAddFacturaManager = iAddFacturaManager;
        }

        public async Task<FacturaResponse> Handle(FacturaAddCommand request, CancellationToken cancellationToken)
        {
            var facturaRequest = new FacturaRequest
            {
                Base = request.Base,
                Fecha = request.Fecha,
                Iva = request.Iva,
                Nif = request.Nif,
                Pais = request.Pais,
                Importe = request.Importe
            };

            FacturaResponse factura = await _iAddFacturaManager.AddFactura(facturaRequest);

            return factura;
        }
    }
}
