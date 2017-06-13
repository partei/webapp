using System.IO;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Options;

namespace Domain
{
    public interface IFileRepository
    {
        Task StorePhoto(Stream photo);
    }

    public class AmazonFileRepository : IFileRepository
    {
        private readonly ITransferUtility _transferUtility;
        private readonly IGuidService _guidService;

        public AmazonFileRepository(IGuidService guidService, IOptions<CredentialProfileOptions> credentialProfileOptions)
        {
            _transferUtility = new TransferUtility(CreateAmazonS3Client(credentialProfileOptions));
            _guidService = guidService;
        }

        private static AmazonS3Client CreateAmazonS3Client(IOptions<CredentialProfileOptions> credentialProfileOptions)
        {
            return new AmazonS3Client(CreateBasicAWSCredentials(credentialProfileOptions), Amazon.RegionEndpoint.EUCentral1);
        }

        private static BasicAWSCredentials CreateBasicAWSCredentials(IOptions<CredentialProfileOptions> credentialProfileOptions)
        {
            return new BasicAWSCredentials(credentialProfileOptions.Value.AccessKey, credentialProfileOptions.Value.SecretKey);
        }

        public Task StorePhoto(Stream photo)
        {
            return _transferUtility.UploadAsync(photo, "partei-photos", _guidService.NewGuid().ToString());
        }
    }
}