using FluentValidation;
using MediatR;

namespace Classifiers.Application.Classifiers.Commands.UpdateClassifier
{
    public class UpdateClassifierCommandValidator : AbstractValidator<UpdateClassifierCommand>
    {
        public UpdateClassifierCommandValidator()
        {
            RuleFor(updateClassifierCommand =>
                updateClassifierCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(updateClassifierCommand =>
                updateClassifierCommand.Id).NotEmpty();
        }
    }
}
