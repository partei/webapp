using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3.Transfer;

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

        public AmazonFileRepository(ITransferUtility transferUtility, IGuidService guidService) {
            _transferUtility = transferUtility;
            _guidService = guidService;
        }
        
        public Task StorePhoto(Stream photo)
        {
            return _transferUtility.UploadAsync(photo, "partei-photos", _guidService.NewGuid().ToString());
        }
    }
}