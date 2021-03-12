using HiddenVilla_Server.Service.Iservice;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HiddenVilla_Server.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public bool DeleteFile(string fileName)
        {
            try
            {
                var path = $"{_webHostEnvironment.WebRootPath}\\RoomImages\\{fileName}";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(file.Name);
                var filename = Guid.NewGuid().ToString() + fileInfo.Extension;
                var folderdirectory = $"{_webHostEnvironment.WebRootPath}\\RoomImages";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "RoomImages",filename);

                var memorystream = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memorystream);

                if (!Directory.Exists(folderdirectory))
                {
                    Directory.CreateDirectory(folderdirectory);
                }

                await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    memorystream.WriteTo(fs);
                }

                var fullpath = $"RoomImages/{filename}";
                return fullpath;

            }
            catch (Exception)
            {

                throw;
            }




        }
    }
}
