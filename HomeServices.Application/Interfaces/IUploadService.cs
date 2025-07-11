﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeServices.Application.Interfaces
{
    public interface IUploadService
    {
        Task<string> UploadImageAsync(IFormFile file, string subfolder);
    }
}
