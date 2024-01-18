using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Exam3.Business.Models.TeamMember
{
    public class UpdateTeamMemberVM
    {
        public IFormFile? Image { get; set; }
        public string Name { get; set; }
    }
}
