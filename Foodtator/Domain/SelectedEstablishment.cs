using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Domain
{
    public class SelectedEstablishment
    {
        public string establishmentName { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public string imageUrl { get; set; }
        public int id { get; set; }

    }
}