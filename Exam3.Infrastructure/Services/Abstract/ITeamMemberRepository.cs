using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam3.Core.Entities;
using Exam3.Infrastructure.Repositories.Abstract;
using Exam3.Infrastructure.Repositories;

namespace Exam3.Infrastructure.Services.Abstract
{
    public interface ITeamMemberRepository : IGenericRepository<TeamMember>
    {
        public Task<TeamMember> GetByIdAsync(int id, bool tracking);

        public Task<IEnumerable<TeamMember>> GetAllPaginatedAsync(int? currentPage, int? perPage);

        public Task<IEnumerable<TeamMember>> GetLastNAsync(int n);
    }
}
