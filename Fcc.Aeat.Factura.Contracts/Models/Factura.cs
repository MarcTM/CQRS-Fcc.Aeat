namespace Fcc.Aeat.Factura.Contracts.Models
{
    public class Factura
    {
        public int Id { get; set; }

        public string Nif { get; set; }

        public string Pais { get; set; }

        public string Fecha { get; set; }

        public byte Iva { get; set; }

        public decimal Importe { get; set; }

        public decimal Base { get; set; }
    }
}
