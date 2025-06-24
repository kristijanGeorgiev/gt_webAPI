using HomeServices.Application.Interfaces;
using Microsoft.AspNetCore.Http;

public class UploadService : IUploadService
{
    public async Task<string> UploadImageAsync(IFormFile file, string subfolder)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is empty or null");

        var folderName = Path.Combine("Resources", subfolder);
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        if (!Directory.Exists(pathToSave))
            Directory.CreateDirectory(pathToSave);

        var fileName = Path.GetFileName(file.FileName);
        var fullPath = Path.Combine(pathToSave, fileName);
        var dbPath = Path.Combine(folderName, fileName).Replace("\\", "/");

        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return dbPath;
    }
}
