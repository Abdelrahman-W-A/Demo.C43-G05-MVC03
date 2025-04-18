using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Demo.BLL.Services.Attachment_Services
{
    public interface IAttachmentServices
    {
        // upload file
        public string? Upload(IFormFile File, string FolderName);

        // Delete file
        bool Delete(string FileName);
    }
}
