using MediatR;

namespace BNPL.Application.Features.Proformas.Commands.CreateProforma;

public record CreateProformaCommand(string Name, string Description, List<CreateProformaDetailDto> Details) : IRequest<Guid>;

public record CreateProformaDetailDto(string Name, string Description, decimal Amount);
