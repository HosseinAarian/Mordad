namespace BNPL.Domain.Entities;

public class LoanRequest
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid BajetInquiryId { get; private set; }
    public Guid ShahkarInquiryId { get; private set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string NationalCode { get; set; }
    public string PhoneNumber { get; set; }
    public string ServiceName { get; set; }
    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string? PaymentDescription { get; private set; }
    public Guid CreatedBy { get; init; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }

    public List<LoanRequestFile>? Files { get; set; }
}
