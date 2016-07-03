using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodtator.Interfaces
{
    public interface IFileUploadService
    {
        bool sendMyFileToS3(string localFilePath, string subDirectoryInBucket, string fileNameInS3);
        void uploadFiles(string filePath, string fileName);

    }
}
