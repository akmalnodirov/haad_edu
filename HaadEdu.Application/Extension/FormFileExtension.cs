using Microsoft.AspNetCore.Http;

namespace HaadEdu.Application.Extension;

public class FormFileExtension 
{
    public static async Task<string> UploadFile(string filePath, IFormFile formFile)
    {
        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(formFile.FileName);
        var assetsFolderPath = Path.Combine("wwwroot", "Media", filePath, fileName);

        if (!Directory.Exists(assetsFolderPath))
        {
            Directory.CreateDirectory(assetsFolderPath);
        }

        using (var stream = new FileStream(assetsFolderPath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        return assetsFolderPath;
    }
}
