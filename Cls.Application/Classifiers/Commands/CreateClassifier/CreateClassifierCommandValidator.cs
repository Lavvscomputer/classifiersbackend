using MediatR;
using FluentValidation;

namespace Classifiers.Application.Classifiers.Commands.CreateClassifier
{
    public class CreateClassifierCommandValidator : AbstractValidator<CreateClassifierCommand>
    {
        public CreateClassifierCommandValidator()
        {
            RuleFor(createClassifierCommand => 
                createClassifierCommand.Name).NotEmpty().MaximumLength(100);
        }
    }
}
