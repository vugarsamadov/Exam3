using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam3.Business.Models;
using Exam3.Business.Models.SocialMedia;
using Exam3.Business.Models.TeamMember;

namespace Exam3.Business.Services.TeamMembers
{
    public interface ITeamMemberService
    {
        public Task AddAsync(CreateTeamMemberVM model);
        public Task UpdateAsync(int id, UpdateTeamMemberVM model);

        public Task AddSocialMediaAsync(int id, AddSocialMediaVM model);

        public Task SoftDeleteAsync(int id);
        public Task RevokeSoftDeleteAsync(int id);
        public Task<TeamMemberVM> GetByIdAsync(int id);
        public Task<IEnumerable<TeamMemberVM>> GetLastNTeamMembersAsync(int n);
        public Task<IEnumerable<TeamMemberVM>> GetAllAsync();
        public Task<GenericPaginatedModel<TeamMemberVM>> GetAllPaginatedAsync(int currentpage,int perPage);

    }
}
