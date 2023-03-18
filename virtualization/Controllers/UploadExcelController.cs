using Microsoft.AspNetCore.Mvc;

namespace virtualization.Controllers;

[ApiController]
[Route("upload-excel")]
public class UploadExcelController : ControllerBase
{
    private readonly string[] _permittedExtensions = { ".xlsx", ".xls" };

    // POST /upload-excel
    [HttpPost]
    public async Task<IActionResult> UploadExcel()
    {
        var file = Request.Form.Files.FirstOrDefault();

        if (file == null)
        {
            return BadRequest("No file uploaded.");
        }

        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

        if (!_permittedExtensions.Contains(fileExtension))
        {
            return BadRequest("Invalid file type. Only Excel files are allowed.");
        }

        // Do something with the uploaded file
        // For example, save the file to disk or process the data in the file

        return Ok();
    }
}
