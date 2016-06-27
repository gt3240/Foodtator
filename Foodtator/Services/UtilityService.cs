using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Services
{
    public static class UtilityService
    {
        public static int NextNumber(Random rng)
        {
            return rng.Next(18) + 1;
        }

    }
}