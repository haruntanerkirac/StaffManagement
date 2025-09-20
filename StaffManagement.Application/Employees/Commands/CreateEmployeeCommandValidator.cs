using FluentValidation;

namespace StaffManagement.Application.Employees.Commands
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.FirstName).MinimumLength(3).WithMessage("Ad alanı en az 3 karakter olmalıdır!");
            RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Soyad alanı en az 3 karakter olmalıdır!");
            RuleFor(x => x.PersonelInformation.NationalId)
                .MinimumLength(11).WithMessage("Geçerli bir TC numarası yazınız.")
                .MaximumLength(11).WithMessage("Geçerli bir TC numarası yazınız.");
        }
    }
}
