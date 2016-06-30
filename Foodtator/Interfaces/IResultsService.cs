using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpSharp.Data;

namespace Foodtator.Interfaces
{
    public interface IResultsService
    {
        SearchResults Results(string location);
    }
}
