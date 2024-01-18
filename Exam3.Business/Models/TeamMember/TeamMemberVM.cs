using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam3.Business.Models.SocialMedia;

namespace Exam3.Business.Models.TeamMember
{
    public class TeamMemberVM
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<TeamMemberSocialMediaVM> SocialMedias { get; set; }
    }
}
