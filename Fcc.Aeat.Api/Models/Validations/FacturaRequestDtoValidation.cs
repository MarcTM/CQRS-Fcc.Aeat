using FluentValidation;

namespace Fcc.Aeat.Api.Models.Validations
{
    public class FacturaRequestDtoValidation : AbstractValidator<FacturaRequestDto>
    {
        public FacturaRequestDtoValidation()
        {
            RuleFor(p => p.Fecha).NotEmpty();
            RuleFor(p => p.FechaInicio).NotEmpty();
            RuleFor(p => p.FechaFin).NotEmpty();
            RuleFor(p => p.Importe).NotEmpty();
            RuleFor(p => p.Iva).NotEmpty();
            RuleFor(p => p.Base).NotEmpty();
            RuleFor(p => p.Nif).NotEmpty();
            RuleFor(p => p.Pais).NotEmpty();
        }
    }
}
