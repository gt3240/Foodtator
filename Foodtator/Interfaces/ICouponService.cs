using Foodtator.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodtator.Interfaces
{
    public interface ICouponService
    {
        int CreateCoupon(CouponRequestModel model);
        List<Domain.Coupon> GetCouponsByUserID();
        int UpdateCoupon(CouponRequestModel model);
    }
}
