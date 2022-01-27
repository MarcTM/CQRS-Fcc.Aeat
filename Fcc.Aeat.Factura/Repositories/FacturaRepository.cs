using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Fcc.Aeat.Core.Data.Connection;
using Fcc.Aeat.Factura.Contracts.Models;
using Fcc.Aeat.Factura.Contracts.Repositories;
using Microsoft.Data.SqlClient;

namespace Fcc.Aeat.Factura.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ConnectionString _connectionString;

        public FacturaRepository(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<FacturaResponse> Add(FacturaRequest factura)
        {
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                var cmd = new SqlCommand("INSERT INTO Factura (Nif, Pais, Importe, Base, Iva, Fecha) output INSERTED.ID VALUES " +
                    "(@Nif, @Pais, @Importe, @Base, @Iva, @Fecha)", conn);

                cmd.Parameters.AddWithValue("@Nif", factura.Nif);
                cmd.Parameters.AddWithValue("@Pais", factura.Pais);
                cmd.Parameters.AddWithValue("@Importe", factura.Importe);
                cmd.Parameters.AddWithValue("@Base", factura.Base);
                cmd.Parameters.AddWithValue("@Iva", factura.Iva);
                cmd.Parameters.AddWithValue("@Fecha", factura.Fecha);

                conn.Open();

                int id = (int)cmd.ExecuteScalar();

                string getQuery = "SELECT * FROM Factura WHERE Id = " + id;

                var insertedFactura = (await conn.QueryAsync<FacturaResponse>(getQuery)).ToList();

                conn.Close();

                return insertedFactura[0];
            }
        }

        public async Task<FacturaResponse> Put(FacturaRequest factura, int id)
        {
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                string query = "UPDATE Factura SET Nif = @Nif, Pais = @Pais, Importe = @Importe, Base = @Base, Iva = @Iva, Fecha = @Fecha WHERE id = " + id;

                await conn.ExecuteAsync(query,
                    new
                    {
                        Nif = factura.Nif,
                        Pais = factura.Pais,
                        Importe = factura.Importe,
                        Base = factura.Base,
                        Iva = factura.Iva,
                        Fecha = factura.Fecha
                    }
                );

                string getQuery = "SELECT * FROM Factura WHERE Id = " + id;

                var updatedFactura = (await conn.QueryAsync<FacturaResponse>(getQuery)).ToList();

                return updatedFactura[0];
            }
        }

        public async Task Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                string query = "DELETE FROM Factura WHERE Id = " + id;

                await conn.ExecuteAsync(query);
            }
        }
    }
}
