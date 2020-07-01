using FluentValidation;
using ItAcademy.SchoolAdmin.Web.Models;

namespace ItAcademy.SchoolAdmin.Web.Validators
{
    public class PositionViewModelValidator : AbstractValidator<PositionViewModel>
    {
        public PositionViewModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(_ => _.Name).NotNull().WithMessage("*Required")
                .MinimumLength(2).WithMessage("*Name must be more than 2 characters")
                .MaximumLength(255).WithMessage("*Name must be less than 256 characters");
            RuleFor(_ => _.MaxEmployees).NotNull().WithMessage("*Required");
        }
    }
}