using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examintaion.Service.DTOs.StudentForCreation
{
    public class StudentFileForCreation
    {
        public IFormFile Passport { get; set; }
        public IFormFile Image { get; set; }

    }
}
