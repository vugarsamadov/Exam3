using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam3.Business.Models.SocialMedia;
using Microsoft.AspNetCore.Http;

namespace Exam3.Business.Models.TeamMember
{
    public class CreateTeamMemberVM 
    {
        public IFormFile Image { get; set; }
        public string Name { get; set; }
    }
}
