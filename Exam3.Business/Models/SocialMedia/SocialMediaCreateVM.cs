using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Exam3.Business.Models.SocialMedia
{
    public class SocialMediaCreateVM
    {
        public string Name { get; set; }
        public IFormFile Icon { get; set; }
    }
}
