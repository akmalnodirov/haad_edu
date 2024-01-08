using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HaadEdu.Application.Extension;

public class FormFileExtansion 
{
    public static async Task<string> UploadFile(string filePath, IFormFile formFile)
    {
        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName);
        var rootPath = Path.Combine(Path.GetExtension(formFile.FileName));
        var assetsFolderPath = Path.Combine("wwwroot", "Media", filePath, fileName);

        if (!Directory.Exists(rootPath))
        {
            Directory.CreateDirectory(rootPath);
        }

        var filePathWithFileName = Path.Combine(rootPath, fileName);

        using (var stream = new FileStream(filePathWithFileName, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        return assetsFolderPath;
    }
}
