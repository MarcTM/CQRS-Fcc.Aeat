using MediatR;

namespace Fcc.Aeat.Factura.Contracts.Commands
{
    public class FacturaDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
