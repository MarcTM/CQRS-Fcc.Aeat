using Fcc.Aeat.Factura.Contracts.Models;
using System;
using System.Globalization;

namespace Fcc.Aeat.Api.Models
{
    public class FacturaRequestDto
    {
        public string FechaInicio { get; set; }

        public string FechaFin { get; set; }

        public string Nif { get; set; }

        public string Pais { get; set; }

        public string Fecha { get; set; }

        public byte Iva { get; set; }

        public decimal Importe { get; set; }

        public decimal Base { get; set; }

        public FacturaRequestDto(string nif)
        {
            Nif = nif;
        }

        public static FacturaRequest MapToFacturaRequest(FacturaRequestDto facturaRequestDto)
        {
            if (facturaRequestDto == null)
                throw new ArgumentNullException(nameof(facturaRequestDto));

            return new FacturaRequest
            {
                FechaFin = DateTime.ParseExact(facturaRequestDto.FechaFin, "dd-MM-yy", CultureInfo.InvariantCulture),
                FechaInicio = DateTime.ParseExact(facturaRequestDto.FechaInicio, "dd-MM-yy", CultureInfo.InvariantCulture),
                Nif = facturaRequestDto.Nif
            };
        }

        /**
        public static FacturaAddCommand MapToFacturaAddCommand(FacturaRequestDto facturaRequestDto)
        {
            if (facturaRequestDto == null)
                throw new ArgumentNullException(nameof(facturaRequestDto));

            return new FacturaAddCommand
            {
                Pais = facturaRequestDto.Pais,
                Nif = facturaRequestDto.Nif,
                Importe = facturaRequestDto.Importe,
                Base = facturaRequestDto.Base,
                Iva = facturaRequestDto.Iva,
                Fecha = DateTime.ParseExact(facturaRequestDto.Fecha, "dd-MM-yy", CultureInfo.InvariantCulture)
            };
        }

        public static FacturaUpdateCommand MapToFacturaUpdateCommand(FacturaRequestDto facturaRequestDto)
        {
            if (facturaRequestDto == null)
                throw new ArgumentNullException(nameof(facturaRequestDto));

            return new FacturaUpdateCommand
            {
                Pais = facturaRequestDto.Pais,
                Nif = facturaRequestDto.Nif,
                Importe = facturaRequestDto.Importe,
                Base = facturaRequestDto.Base,
                Iva = facturaRequestDto.Iva,
                Fecha = DateTime.ParseExact(facturaRequestDto.Fecha, "dd-MM-yy", CultureInfo.InvariantCulture)
            };
        }
        **/
    }
}
