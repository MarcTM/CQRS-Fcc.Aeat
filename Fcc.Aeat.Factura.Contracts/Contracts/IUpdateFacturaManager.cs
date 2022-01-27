using Fcc.Aeat.Factura.Contracts.Models;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Contracts.Contracts
{
    public interface IUpdateFacturaManager
    {
        Task<FacturaResponse> UpdateFactura(FacturaRequest facturaRequest, int id);
    }
}
