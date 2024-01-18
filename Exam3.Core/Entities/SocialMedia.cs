using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3.Core.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public ICollection<SocialMediaTeamMember> TeamMemberSocialMedias { get; set; }
    }


    public class SocialMediaTeamMember : BaseEntity
    {
        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; }

        public int TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; }

        public string TeamMemberSocialMediaUrl { get; set; }
    }
}
