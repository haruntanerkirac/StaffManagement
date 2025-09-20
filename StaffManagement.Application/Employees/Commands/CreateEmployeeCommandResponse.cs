namespace StaffManagement.Application.Employees.Commands
{
    public sealed class CreateEmployeeCommandResponse
    {
        public string Message { get; set; } = default!;
        public bool Success { get; set; }
    }
}
