using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Core
{
    public static class ICacheServiceExt
    {
        public static string GetCachKey(this ICacheService cache, params string[] cachParts)
        {

            return String.Concat(cachParts);
        }

    }
}