using FluentValidation;
using ItAcademy.SchoolAdmin.Web.Models;

namespace ItAcademy.SchoolAdmin.Web.Validators
{
    public class SubjectViewModelValidator : AbstractValidator<SubjectViewModel>
    {
        public SubjectViewModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(_ => _.Name).NotNull().WithMessage("*Required")
                .MinimumLength(2).WithMessage("*Name must be more than 2 characters")
                .MaximumLength(255).WithMessage("*Name must be less than 256 characters");
        }
    }
}