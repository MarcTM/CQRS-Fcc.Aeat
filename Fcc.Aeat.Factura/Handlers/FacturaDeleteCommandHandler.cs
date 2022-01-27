using System.Threading;
using System.Threading.Tasks;
using Fcc.Aeat.Factura.Contracts.Commands;
using Fcc.Aeat.Factura.Contracts.Contracts;
using MediatR;

namespace Fcc.Aeat.Factura.Handlers
{
    public class FacturaDeleteCommandHandler : IRequestHandler<FacturaDeleteCommand>
    {
        private readonly IDeleteFacturaManager _iDeleteFacturaManager;

        public FacturaDeleteCommandHandler(IDeleteFacturaManager iDeleteFacturaManager)
        {
            _iDeleteFacturaManager = iDeleteFacturaManager;
        }

        public async Task<Unit> Handle(FacturaDeleteCommand request, CancellationToken cancellationToken)
        {
            await _iDeleteFacturaManager.DeleteFactura(request.Id);

            return Unit.Value;
        }
    }
}
