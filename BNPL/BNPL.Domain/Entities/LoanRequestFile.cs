namespace BNPL.Domain.Entities;

public class LoanRequestFile
{
    public Guid Id { get; set; }
    public Guid LoanRequestId { get; set; }

    public required string FileName { get; set; }
    public required Guid FileId { get; set; }
    public required string Extension { get; set; }
    public long Length { get; set; }

    public Guid CreatedBy { get; init; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public LoanRequest? LoanRequest { get; set; }
}
