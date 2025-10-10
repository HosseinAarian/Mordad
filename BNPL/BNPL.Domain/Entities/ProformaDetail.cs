namespace BNPL.Domain.Entities;

public class ProformaDetail
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Amount { get; set; }

    public Guid ProformaId { get; set; }
    public Proforma Proforma { get; set; } = null!;
}
