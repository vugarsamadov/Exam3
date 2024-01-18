using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exam3.Core.Entities
{
    public class TeamMember : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<SocialMediaTeamMember> TeamMemberSocialMedias { get; set; }
    }
}
