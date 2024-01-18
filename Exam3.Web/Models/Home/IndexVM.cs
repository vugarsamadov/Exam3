using Exam3.Business.Models.TeamMember;

namespace Exam3.Web.Models.Home
{
    public class IndexVM
    {
        public IEnumerable<TeamMemberVM> TeamMembers { get; set; }
    }
}
