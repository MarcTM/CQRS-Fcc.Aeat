using AutoMapper;
using Fcc.Aeat.Api.Models;
using Fcc.Aeat.Factura.Contracts.Commands;
using Fcc.Aeat.Factura.Contracts.Models;
using Fcc.Aeat.Factura.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fcc.Aeat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IFacturaQueries _facturaQueries;

        private readonly Mapper _mapper;

        public FacturaController(IFacturaQueries facturaQueries, IMediator mediator, Mapper mapper)
        {
            _facturaQueries = facturaQueries;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string nif)
        {
            try
            {
                var facturas = await _facturaQueries.GetAll(nif);

                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return BadRequest(new ProblemDetails { 
                    Status = 500,
                    Detail = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var factura = await _facturaQueries.GetOne(id);

                return Ok(factura);
            }
            catch (Exception ex)
            {
                return BadRequest(new ProblemDetails
                {
                    Status = 500,
                    Detail = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FacturaRequestDto facturaRequestDto)
        {
            FacturaAddCommand facturaAddCommand = _mapper.Map<FacturaRequestDto, FacturaAddCommand>(facturaRequestDto);

            FacturaResponse factura = await _mediator.Send(facturaAddCommand);

            return Ok(factura);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] FacturaRequestDto facturaRequestDto, int id)
        {
            FacturaUpdateCommand facturaUpdateCommand = _mapper.Map<FacturaUpdateCommand>(facturaRequestDto);

            facturaUpdateCommand.Id = id;

            FacturaResponse factura = await _mediator.Send(facturaUpdateCommand);

            return Ok(factura);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            FacturaDeleteCommand facturaDeleteCommand = new() { Id = id };

            await _mediator.Send(facturaDeleteCommand);

            return Ok();
        }
    }
}
