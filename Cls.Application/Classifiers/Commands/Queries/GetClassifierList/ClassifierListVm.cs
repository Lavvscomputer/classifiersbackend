using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifiers.Application.Classifiers.Commands.Queries.GetClassifierList
{
    public class ClassifierListVm
    {
        public IList<ClassifierLookupDto>? Classifiers { get; set; }
    }
}
