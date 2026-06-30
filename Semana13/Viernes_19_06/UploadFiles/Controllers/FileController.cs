using Microsoft.AspNetCore.Mvc;
using UploadFiles.ViewModel;

namespace UploadFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("uploadFiles")]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadModel model)
        {
            if(model.File ==  null || model.File.Length == 0)
            {
                return BadRequest("Invalid Reqwest");
            }

            var folderName = Path.Combine("Resources", "AllFiles");

            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if(!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }

            var fileName = model.File.FileName;
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);

            if (System.IO.File.Exists(fullPath))
            {
                return BadRequest("file already exists");
            }
            using(var stream = new FileStream(fullPath, FileMode.Create))
            {
                model.File.CopyTo(stream);
            }

            return Ok( new { dbPath});
        }

        [HttpPost("multipleUploadFiles")]
        public async Task<IActionResult> MultipleUploadFile([FromForm] MultipleUploadModel model)
        {
            var response = new Dictionary<string, string>();

            if (model.Files == null || model.Files.Count == 0)
            {
                return BadRequest("Invalid Request");
            }

            foreach(var file in model.Files)
            {

                var folderName = Path.Combine("Resources", "AllFiles");

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (!Directory.Exists(pathToSave))
                {
                    Directory.CreateDirectory(pathToSave);
                }

                var fileName = file.FileName;
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                if (System.IO.File.Exists(fullPath))
                {
                    return BadRequest("file already exists");
                }
                else
                {
                    using var memoryStream = new MemoryStream();
                    await file.CopyToAsync(memoryStream);

                    await System.IO.File.WriteAllBytesAsync(fullPath, memoryStream.ToArray());
                    response.Add(fileName, fullPath);
                }
            }

            return Ok(response);
        }
    }
}
