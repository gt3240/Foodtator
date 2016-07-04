using Foodtator.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodtator.Interfaces
{
    public interface IMediaService
    {
        int InsertMedia(MediaRequestModel model);
        void UpdateMedia(MediaRequestModel model);
        List<Domain.Media> GetMediaByUserID(int UserID);
        Domain.Media GetMediaByID(int ID);
        void DeleteMedia(int id);

    }
}
