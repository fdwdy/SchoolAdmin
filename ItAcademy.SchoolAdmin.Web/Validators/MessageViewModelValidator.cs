using FluentValidation;
using ItAcademy.SchoolAdmin.Web.Models;

namespace ItAcademy.SchoolAdmin.Web.Validators
{
    public class MessageViewModelValidator : AbstractValidator<MessageViewModel>
    {
        public MessageViewModelValidator()
        {
            RuleFor(msg => msg.Text)
                .NotNull().WithMessage("ShouldNot be empty")
                .MaximumLength(120)
                .When(msg => msg.Length == 120).WithMessage("Max length 120 symbols")
                .MaximumLength(500)
                .When(msg => msg.Length == 500).WithMessage("Max length 500 symbols");
        }
    }
}