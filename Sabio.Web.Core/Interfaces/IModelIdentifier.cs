using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodtator.Core
{
    public interface IModelIdentifier
    {
        object Id { get; set; }
    }
}
