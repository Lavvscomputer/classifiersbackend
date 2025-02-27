using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classifiers.Application.Classifiers.Commands.Queries.GetClassifierSection;
using FluentValidation;

namespace Classifiers.Application.Classifiers.Commands.Queries.GetClassifierSection
{
    public class GetClassifierSectionQueryValidator : AbstractValidator<GetClassifierSectionQuery>
    {
        public GetClassifierSectionQueryValidator()
        {
            RuleFor(command => command.ParentId)
                .NotEmpty()
                .WithMessage("ParentId не может быть пустым.");
        }
    }
}
