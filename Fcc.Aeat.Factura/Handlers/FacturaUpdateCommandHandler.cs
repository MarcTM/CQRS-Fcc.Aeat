using System.Threading;
using System.Threading.Tasks;
using Fcc.Aeat.Factura.Contracts.Commands;
using Fcc.Aeat.Factura.Contracts.Contracts;
using Fcc.Aeat.Factura.Contracts.Models;
using MediatR;

namespace Fcc.Aeat.Factura.Handlers
{
    public class FacturaUpdateCommandHandler : IRequestHandler<FacturaUpdateCommand, FacturaResponse>
    {
        private readonly IUpdateFacturaManager _iUpdateFacturaManager;

        public FacturaUpdateCommandHandler(IUpdateFacturaManager iAddFacturaManager)
        {
            _iUpdateFacturaManager = iAddFacturaManager;
        }

        public async Task<FacturaResponse> Handle(FacturaUpdateCommand request, CancellationToken cancellationToken)
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

            FacturaResponse factura = await _iUpdateFacturaManager.UpdateFactura(facturaRequest, request.Id);

            return factura;
        }
    }
}
