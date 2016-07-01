using Foodtator.Domain;
using Foodtator.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodtator.Interfaces
{
    public interface IAdminUsersService
    {
        void Update(AdminUsersRequestModel model, Guid Id);
        List<UserDetails> ListUsers();
        UserDetails GetUserById(Guid id);
        void DeleteUserById(Guid id);
        List<Domain.UserDetails> GetPaginationList(PaginateListRequestModel model);
        int AdminUserCount(PaginateListRequestModel model);
    }
}
