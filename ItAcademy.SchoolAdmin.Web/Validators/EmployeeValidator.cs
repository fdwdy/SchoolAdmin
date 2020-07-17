using System.Linq;
using FluentValidation;
using ItAcademy.SchoolAdmin.Web.Models;
using Microsoft.Ajax.Utilities;

namespace ItAcademy.SchoolAdmin.Web.Validators
{
    public class EmployeeValidator : AbstractValidator<CreateEmployeeViewModel>
    {
        public EmployeeValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(_ => _.Name).NotNull().WithMessage("*Required")
                .MinimumLength(2).WithMessage("*Name must be more than 2 characters")
                .MaximumLength(255).WithMessage("*Name must be less than 256 characters");
            RuleFor(_ => _.Middlename).NotNull().WithMessage("*Required")
                .MinimumLength(5).WithMessage("*Middlename must be more than 5 characters")
                .MaximumLength(255).WithMessage("*Middlename must be less than 256 characters");
            RuleFor(_ => _.Surname).NotNull().WithMessage("*Required")
                .MinimumLength(2).WithMessage("*Surname must be more than 2 characters")
                .MaximumLength(255).WithMessage("*Surname must be less than 256 characters");
            RuleFor(_ => _.Phones).NotNull().WithMessage("*At least one phone Required");
            RuleFor(_ => _.Email).NotNull().WithMessage("*Required")
                .EmailAddress().WithMessage("*Incorrect email");
            RuleFor(_ => _.BirthDate).NotNull().WithMessage("*Required");
        }
    }
}