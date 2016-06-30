﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodtator.Core.Services
{
    public interface IIdentityProvider<T>
    {
        T GetCurrentUserId();
    }
}
