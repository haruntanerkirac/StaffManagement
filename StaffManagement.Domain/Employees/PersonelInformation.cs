namespace StaffManagement.Domain.Employees;

public sealed record PersonelInformation
{
    public string NationalId { get; set; } = default!;
    public string? Email { get; set; }
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
}