using Fcc.Aeat.Factura.Contracts.Contracts;
using Fcc.Aeat.Factura.Contracts.Repositories;
using System;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Managers
{
    public class DeleteFacturaManager : IDeleteFacturaManager
    {
        private readonly IFacturaRepository _facturaRepository;

        public DeleteFacturaManager(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public Task DeleteFactura(int id)
        {
            if (id < 0)
                throw new ArgumentNullException(nameof(id));

            return _facturaRepository.Delete(id);
        }
    }
}
