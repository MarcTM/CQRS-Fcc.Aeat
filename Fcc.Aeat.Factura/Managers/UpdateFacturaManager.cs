using Fcc.Aeat.Factura.Contracts.Contracts;
using Fcc.Aeat.Factura.Contracts.Models;
using Fcc.Aeat.Factura.Contracts.Repositories;
using System;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Managers
{
    public class UpdateFacturaManager : IUpdateFacturaManager
    {
        private readonly IFacturaRepository _facturaRepository;

        public UpdateFacturaManager(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public Task<FacturaResponse> UpdateFactura(FacturaRequest facturaRequest, int id)
        {
            if (facturaRequest == null || id < 1)
                throw new ArgumentNullException(nameof(facturaRequest));

            return _facturaRepository.Put(facturaRequest, id);
        }
    }
}
