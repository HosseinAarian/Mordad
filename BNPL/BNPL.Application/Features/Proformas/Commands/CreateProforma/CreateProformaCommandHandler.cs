using BNPL.Domain.Entities;
using BNPL.Infrastructure.Repository.Context;
using MediatR;

namespace BNPL.Application.Features.Proformas.Commands.CreateProforma;

public class CreateProformaCommandHandler(BNPLDBContext context) : IRequestHandler<CreateProformaCommand, Guid>
{
    public async Task<Guid> Handle(CreateProformaCommand request, CancellationToken cancellationToken)
    {
        var proforma = new Proforma
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
        };

        foreach (var detailDto in request.Details)
        {
            var detail = new ProformaDetail
            {
                Id = Guid.NewGuid(),
                Name = detailDto.Name,
                Description = detailDto.Description,
                Amount = detailDto.Amount,
                Proforma = proforma
            };
            proforma.ProformaDetails.Add(detail);
        }

        context.Proformas.Add(proforma);
        await context.SaveChangesAsync(cancellationToken);

        return proforma.Id;
    }
}
