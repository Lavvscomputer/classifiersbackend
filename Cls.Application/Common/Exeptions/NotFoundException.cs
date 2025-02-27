using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifiers.Application.Common.Exeptions
{
    public class NotFoundException(string name, object key) : Exception($"Entity \"{name}\" - {key} not found")
    {
    }
}
