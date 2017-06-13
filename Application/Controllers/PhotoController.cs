using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Domain;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    public class PhotoController : Controller
    {
        private readonly IFileRepository _fileRepository;

        public PhotoController(IFileRepository fileRepository) {
            _fileRepository = fileRepository;
        }

        [HttpPost]
        public async Task UploadPhoto(IFormFile photo)
        {
            using (var stream = new MemoryStream())
            {
                await photo.CopyToAsync(stream);
                await _fileRepository.StorePhoto(stream);  
            }
        }

        [HttpGet]
        public string getPhoto()
        {
            return "Hello world!";
        }
    }

}
