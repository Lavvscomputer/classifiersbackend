using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Classifiers.Application.Classifiers.Commands.Queries.GetClassifierDetails
{
    public class GetClassifierDetailsQueryValidator : AbstractValidator<GetClassifierDetailsQuery>
    {
        public GetClassifierDetailsQueryValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty()
                .WithMessage("Id не может быть пустым.");
        }
    }
}
