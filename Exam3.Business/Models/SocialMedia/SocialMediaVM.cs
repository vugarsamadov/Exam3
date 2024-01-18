using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam3.Core.Entities;

namespace Exam3.Business.Models.SocialMedia
{
    public class SocialMediaVM
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        
        public string Name { get; set; }
        public string IconUrl { get; set; }
    }

    public class TeamMemberSocialMediaVM
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public string SocialMediaName { get; set; }
        public string SocialMediaIconUrl { get; set; }

        public string TeamMemberSocialMediaUrl { get; set; }

    }
}
