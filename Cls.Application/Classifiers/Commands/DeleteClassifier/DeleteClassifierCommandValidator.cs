using MediatR;
using FluentValidation;

namespace Classifiers.Application.Classifiers.Commands.DeleteClassifier
{
    public class DeleteClassifierCommandValidator : AbstractValidator<DeleteClassifierCommand>
    {
        public DeleteClassifierCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty()
                .WithMessage("Id не может быть пустым.");
        }
    }
}
