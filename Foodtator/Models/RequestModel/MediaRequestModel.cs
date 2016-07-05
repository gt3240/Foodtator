using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Models.RequestModel
{
    public class MediaRequestModel
    {
        public string ID { get; set; }

        public string UserID { get; set; }

        public string MediaType { get; set; }

        public string Path { get; set; }

        public string FileName { get; set; }

        public string FileType { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ThumbnailPath { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}