using Fcc.Aeat.Core.Data.Connection;
using Fcc.Aeat.Factura.Queries.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Fcc.Aeat.Factura.Queries.Impl
{
    public class FacturaQueries : IFacturaQueries
    {
        private readonly ConnectionString _connectionString;

        public FacturaQueries(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Factura.Contracts.Models.Factura>> GetAll(string nif)
        {
            using (SqlConnection conn = new(_connectionString.Value))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                var queryParameters = new DynamicParameters();

                queryParameters.Add("@Nif", nif);

                var facturas = (await conn.QueryAsync<Factura.Contracts.Models.Factura>("SELECT * FROM Factura WHERE Nif = @Nif", queryParameters)).ToList();

                return facturas;
            }
        }

        public async Task<IEnumerable<Factura.Contracts.Models.Factura>> GetOne(int id)
        {
            using (SqlConnection conn = new(_connectionString.Value))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                var queryParameters = new DynamicParameters();

                queryParameters.Add("@Id", id);

                var factura = (await conn.QueryAsync<Factura.Contracts.Models.Factura>("SELECT * FROM Factura WHERE Id = @Id", queryParameters)).ToList();

                return factura;
            }
        }
    }
}
