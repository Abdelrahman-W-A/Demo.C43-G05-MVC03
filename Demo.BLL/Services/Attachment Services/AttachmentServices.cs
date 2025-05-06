using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Demo.BLL.Services.Attachment_Services
{
    public class AttachmentServices : IAttachmentServices
    {

        List<string> allowedExtensions = new List<string>() { ".jpg", ".png", ".jpeg"};
        const int MaxSize = 2 * 1024 * 1024; // 2 MB

        public bool Delete(string FileName)
        {
            if(!File.Exists(FileName)) return false;
            else
            {
                File.Delete(FileName);
                return true;
            }
        }


        public string? Upload(IFormFile File, string FolderName)
        {
            // 1.Check Extension
            var Extension = Path.GetExtension(File.FileName);
            if (!allowedExtensions.Contains(Extension))
            {
                return null;
            }

            // 2.Check Size
            if (File.Length > MaxSize || File.Length == 0)
            {
                return null;
            }

            // 3.Get Located Folder Path
            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);

            // 4.Make Attachment Name Unique-- GUID
            var fileName = $"{Guid.NewGuid()}_{File.FileName}";

            // 5.Get File Path
            var filePath = Path.Combine(FolderPath, fileName);

            // 6.Create File Stream To Copy File[Unmanaged]
            using FileStream fileStream = new FileStream(filePath, FileMode.Create);

            // 7.Use Stream To Copy File
            File.CopyTo(fileStream);

            // 8.Return FileName To Store In Database
            return fileName;
        }
    }
}
