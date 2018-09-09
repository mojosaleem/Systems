using ManegmentSystems.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;


using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ManegmentSystems.ViewModel
{
    public class Filerepo : Ifile
    {
        private readonly IHostingEnvironment _env;

        public Filerepo(IHostingEnvironment env)
        {
            _env = env;
          
        }
        public void DeleteFiles(string userId)
        {
          

        string dirPath = "/UserFiles/" + userId + "/Check/";
            var webRoot = _env.WebRootPath;
            if (Directory.Exists(webRoot + dirPath))
            {
                string[] strfiles = Directory.GetFiles(webRoot + dirPath);
                if (strfiles.Length > 0)
                {
                    for (int i = 0; i < strfiles.Length; i++)
                    {

                        string _CurrentFile = strfiles[i].ToString();
                        if (System.IO.File.Exists(_CurrentFile))
                        {
                            try
                            {
                                System.IO.File.Delete(_CurrentFile);
                            }
                            catch (Exception ex)
                            {
                                //throw;
                            }
                        }
                    }
                }
            }
        }

        public async Task<IActionResult> DownloadAsync(string img, string userId)
        {
            string filename = img;


            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot" + "/UserFiles/" + userId + "/Check/", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return new JsonResult("");
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        public Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                  {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"}
            };
        }

        public async Task<string> Upload_Image(FormFile file,string name)
        {
            var newFileName = string.Empty;
            if (file.Length > 0)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                //Getting FileName
                fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                
                //Assigning Unique Filename (Guid)
                var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                //Getting file Extension
                var FileExtension = Path.GetExtension(fileName);

                // concating  FileName + FileExtension
                newFileName = myUniqueFileName + FileExtension;
              
                 _env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), name);
              
                // Combines two strings into a path.
                fileName = _env.WebRootPath + '\\' + newFileName;

                // if you want to store path of folder in database
                PathDB = name+"/" + newFileName;
                newFileName = PathDB;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    await file.CopyToAsync(fs);
                    fs.Flush();
                }
            }

            return newFileName;

        }
    }
}
