using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YelpSharp.Data;

namespace Foodtator.Models.ViewModels
{
    public class YelpResultsViewModel : BaseViewModel
    {
        public SearchResults results { get; set; }
    }
}