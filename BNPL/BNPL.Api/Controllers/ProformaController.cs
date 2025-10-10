using BNPL.Application.Features.Proformas.Commands.CreateProforma;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BNPL.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProformaController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProformaCommand command)
    {
        var id = await mediator.Send(command);

        return Ok(id);
    }
}
