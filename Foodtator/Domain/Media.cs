using Foodtator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Domain
{
    public class Media
    {
        public int ID { get; set; }
        public string MediaType { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }
        public string ThumbnailPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string FullUrl
        {
            get
            {
                switch (MediaType)
                {

                    case "2":
                        return this.Path;

                    default:
                        return ConfigService.uploadFileS3BaseUrl + this.Path + "/" + this.FileName;

                }
            }
        }
        public int LogoId { get; set; }
        public int DealerId { get; set; }
        public int RecordId { get; set; }
        public int MediaId { get; set; }
        public bool IsCoverPhoto { get; set; }
        public bool IsLogoPhoto { get; set; }
    }
}
