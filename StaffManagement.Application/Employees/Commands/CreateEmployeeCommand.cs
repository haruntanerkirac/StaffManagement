using Mapster;
using MediatR;
using StaffManagement.Domain.Employees;

namespace StaffManagement.Application.Employees.Commands;

public sealed record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    DateOnly BirthOfDate,
    decimal Salary,
    PersonelInformation PersonelInformation,
    Address? Address) : IRequest<CreateEmployeeCommandResponse>;

internal sealed class CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<CreateEmployeeCommand, CreateEmployeeCommandResponse>
{
    public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var isEmployeeExists = await employeeRepository.AnyAsync(p=>p.PersonelInformation.NationalId == request.PersonelInformation.NationalId, cancellationToken);
        if (isEmployeeExists)
        {
            return new CreateEmployeeCommandResponse
            {
                Message = "Bu TC numaralı işçi daha önce kaydedilmiş.",
                Success = false
            };
        }

        Employee employee = request.Adapt<Employee>();
        employeeRepository.Add(employee);
        await employeeRepository.SaveChangesAsync(cancellationToken);
        return new CreateEmployeeCommandResponse
        {
            Message = "Başarıyla oluşturuldu.",
            Success = true
        };
    }
}

