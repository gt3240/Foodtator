using Amazon;
using Amazon.S3.Transfer;
using Foodtator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Services
{
    public class FileUploadService:BaseService,IFileUploadService
    {
        private string _bucketName = ConfigService.uploadFileS3BucketName;
        private string _accessKey = ConfigService.uploadFileS3AccessKey;
        private string _secretKey = ConfigService.uploadFileS3SecretKey;

        public bool sendMyFileToS3(string localFilePath, string subDirectoryInBucket, string fileNameInS3)
        {
            // input explained :
            // localFilePath = the full local file path e.g. "c:\mydir\mysubdir\myfilename.zip"
            // bucketName : the name of the bucket in S3 ,the bucket should be alreadt created
            // subDirectoryInBucket : if this string is not empty the file will be uploaded to
            // a subdirectory with this name
            // fileNameInS3 = the file name in the S3

            // create an instance of IAmazonS3 class ,in my case i choose RegionEndpoint.EUWest1
            // you can change that to APNortheast1 , APSoutheast1 , APSoutheast2 , CNNorth1
            // SAEast1 , USEast1 , USGovCloudWest1 , USWest1 , USWest2 . this choice will not
            // store your file in a different cloud storage but (i think) it differ in performance
            // depending on your location


            var client = AWSClientFactory.CreateAmazonS3Client(_accessKey, _secretKey, RegionEndpoint.USWest2);

            //IAmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client(RegionEndpoint.EUWest1);



            // create a TransferUtility instance passing it the IAmazonS3 created in the first step
            TransferUtility utility = new TransferUtility(client);
            // making a TransferUtilityUploadRequest instance
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

            request.BucketName = _bucketName + @"/" + subDirectoryInBucket;
            request.Key = fileNameInS3; //file name up in S3
            request.FilePath = localFilePath; //local file name
            utility.Upload(request); //commensing the transfer
            return true; //indicate that the file was sent
        }

        public void uploadFiles(string filePath, string fileName)
        {
            // preparing our file and directory names
            //string fileToBackup = @"C:\SF.Code\C15\Sabio.Web\Media\04.jpg"; // test file
            string s3DirectoryName = ConfigService.uploadFileS3Prefix;
            //string s3FileName = @"test file.jpg";

            FileUploadService myUploader = new FileUploadService();

            myUploader.sendMyFileToS3(filePath, s3DirectoryName, fileName);
        }
    }
}