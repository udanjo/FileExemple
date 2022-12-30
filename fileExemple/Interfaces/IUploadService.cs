using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fileExemple.Helpers;
using Microsoft.AspNetCore.Http;

namespace fileExemple.Interfaces
{
    public interface IUploadService
    {
       Task<HandlerResponse> Upload(IFormFile file);
    }
}