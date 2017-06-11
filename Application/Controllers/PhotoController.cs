using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Amazon.S3.Transfer;
using Amazon.S3;
using System;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    public class PhotoController : Controller
    {
        [HttpPost]
        public async Task UploadPhoto(IFormFile photo)
        {
            using (var stream = new MemoryStream())
            {
                await photo.CopyToAsync(stream);
                var chain = new CredentialProfileStoreChain();
                AWSCredentials awsCredentials;
                if (chain.TryGetAWSCredentials("shared_profile", out awsCredentials))
                {
                    var fileTransferUtility = new TransferUtility(new AmazonS3Client(awsCredentials, Amazon.RegionEndpoint.EUCentral1));
                    await fileTransferUtility.UploadAsync(stream,
                                               "partei-photos", Guid.NewGuid().ToString());
                    return;
                }
                throw new Exception("Login AWS failed");
            }
        }

        [HttpGet]
        public string getPhoto()
        {
            return "Hello world!";
        }
    }

}
