using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam3.Core.Entities;
using Exam3.Infrastructure.Repositories;
using Exam3.Infrastructure.Services.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Exam3.Infrastructure.Services
{
    public class TeamMemberRepository : GenericRepository<TeamMember>, ITeamMemberRepository
    {
        private ApplicationDbContext _dbContext { get; }
        public TeamMemberRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TeamMember>> GetAllPaginatedAsync(int? currentPage, int? perPage)
        {
            var query = _dbContext.Set<TeamMember>().AsQueryable()
                .Include(c=>c.TeamMemberSocialMedias)
                .ThenInclude(s=>s.SocialMedia);

            if (currentPage != null && perPage != null)
                return await query.Skip(((int)currentPage - 1) * (int)perPage).Take((int)perPage).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<TeamMember> GetByIdAsync(int id, bool tracking)
        {
            var query = _dbContext.Set<TeamMember>().AsQueryable().Include(c => c.TeamMemberSocialMedias)
                .ThenInclude(s => s.SocialMedia).AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            var entity = await query.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }


        public async Task<IEnumerable<TeamMember>> GetLastNAsync(int n)
        {
            var query = _dbContext.Set<TeamMember>().AsQueryable().Include(c => c.TeamMemberSocialMedias)
                .ThenInclude(s => s.SocialMedia);

            var entities = await query.OrderByDescending(e => e.CreatedAt).Take(3).ToListAsync();

            return entities;
        }
    }
}
