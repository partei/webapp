using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    public class PhotoController : Controller
    {
        [HttpPost]
        public void UploadPhoto([FromBody]List<int> bits)
        {

        }
    }
}
