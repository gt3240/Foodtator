using Foodtator.Domain;
using Foodtator.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodtator.Interfaces
{
    public interface ISearchService
    {
        List<UserDetails> ListUsers(UserSearchRequestModel model);


    }
}
