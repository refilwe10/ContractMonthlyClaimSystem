namespace ContractMonthlyClaimSystem.Models;
public class Claim
{
    public int ClaimId { get; set; }
    public int LecturerId { get; set; }
    public double HoursWorked { get; set; }
    public double HourlyRate { get; set; }
    public double TotalAmount { get; set; }
    public string? Status { get; set; } // E.g., Pending, Approved, Rejected
    public string? SupportingDocuments { get; set; } // Path to uploaded documents

    public Lecturer? Lecturer { get; set; }
}

