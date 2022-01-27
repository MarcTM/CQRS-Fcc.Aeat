using Fcc.Aeat.Factura.Contracts.Models;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Contracts.Repositories
{
    public interface IFacturaRepository
    {
        Task<FacturaResponse> Add(FacturaRequest factura);

        Task<FacturaResponse> Put(FacturaRequest factura, int id);

        Task Delete(int id);
    }
}
