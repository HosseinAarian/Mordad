namespace BNPL.Domain.Entities;

public class Proforma
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public ICollection<ProformaDetail> ProformaDetails { get; set; } = new List<ProformaDetail>();
}
