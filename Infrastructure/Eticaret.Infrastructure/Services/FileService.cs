using Eticaret.Application.Services;
using Infrastructure.StaticServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class FileService : IFileService
{
    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    readonly IWebHostEnvironment _webHostEnvironment;
    
    public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
    {
        string uploadedPath = Path.Combine(_webHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(uploadedPath))
        {
            Directory.CreateDirectory(uploadedPath);
        }
        
        List<(string fileName, string path)> data = new();
        
        foreach (IFormFile file in files)
        {
            string fileNewName =  FileRename(file.FileName, uploadedPath);
            bool result = await CopyFileAsync(Path.Combine(uploadedPath, fileNewName), file);
            if (!result)
                data.Add((fileNewName, Path.Combine(uploadedPath, fileNewName)));
            else throw new Exception();
            // to do: exception log?
        }
        

        return data;
    }

    private string FileRename(string fileName, string path)
    {
        string extension = Path.GetExtension(fileName);
        string oldName = Path.GetFileNameWithoutExtension(fileName);
        string newName = NameOperation.ChracterRegulatory(oldName);
        string newFileName = newName + extension;
        
        if (newFileName == "")
           newFileName = "file";  //seo için fileName düzenlemesi sonrası fileName'in boş olması ihtimaline karşın
        
        
        int fileCount = 0;
        while (File.Exists(Path.Combine(path,newFileName)))
        {
            if (fileCount == 25)
            {
                // Aynı isimde çok fazla varsa blabla-200, blabla-201 olarak gitmek yerine bir noktadan sonra
                // random sayı versin.
                Random random = new Random();
                newFileName = $"{newName}-{random.Next(100000, 999999)}{extension}";
            }
            else
            {
                fileCount++; 
                newFileName = newName + "-" +fileCount + extension;
            }

        }
        
        return newFileName;

    }
    
    public async Task<bool> CopyFileAsync(string path, IFormFile file)
    {
        try
        {
            await using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024* 1024, useAsync:false);
            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            return true;
        }
        catch (Exception e)
        {
            //todo log
            throw new Exception(e.Message);
        }
    }
}