using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManegmentSystems.Data.Models;

namespace ManegmentSystems.Services
{
    public interface Ifile
    {
        Task<string> Upload_Image(FormFile file,string name);
        void DeleteFiles(string userId);
        Task<IActionResult> DownloadAsync(string img, string userId);
         Dictionary<string, string> GetMimeTypes();
    }
}
