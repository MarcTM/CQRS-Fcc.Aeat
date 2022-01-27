using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Queries.Contracts
{
    public interface IFacturaQueries
    {
        Task<IEnumerable<Factura.Contracts.Models.Factura>> GetAll(string nif);

        Task<IEnumerable<Factura.Contracts.Models.Factura>> GetOne(int id);
    }
}
