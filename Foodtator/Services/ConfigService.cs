using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Foodtator.Services
{
    public class ConfigService
    {
        public static string AWSProfileName
        {
            get { return ConfigService.GetFromConfig("AWSProfileName"); }
        }

        public static string uploadFileS3AccessKey
        {
            get { return ConfigService.GetFromConfig("uploadFileS3AccessKey"); }
        }

        public static string uploadFileS3SecretKey
        {
            get { return ConfigService.GetFromConfig("uploadFileS3SecretKey"); }
        }

        public static string uploadFileS3Prefix
        {
            get { return ConfigService.GetFromConfig("uploadFileS3Prefix"); }
        }

        public static string uploadFileS3BucketName
        {
            get { return ConfigService.GetFromConfig("uploadFileS3BucketName"); }
        }

        public static string uploadFileS3BaseUrl
        {
            get { return ConfigService.GetFromConfig("uploadFileS3BaseUrl"); }
        }

        //**********************************************************************

        private static string GetFromConfig(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }

        // DIY Principles 
        //private static string GetElasticSearch(string key)
        //{
        //    return WebConfigurationManager.AppSettings[key];
        //}


    }
}