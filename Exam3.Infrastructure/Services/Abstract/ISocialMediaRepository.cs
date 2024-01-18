using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam3.Core.Entities;
using Exam3.Infrastructure.Repositories;
using Exam3.Infrastructure.Repositories.Abstract;

namespace Exam3.Infrastructure.Services.Abstract
{
    public interface ISocialMediaRepository : IGenericRepository<SocialMedia>
    {
        public Task<SocialMedia> GetByIdAsync(int id, bool tracking);

        public Task<IEnumerable<SocialMedia>> GetAllPaginatedAsync(int? currentPage, int? perPage);

        public Task<IEnumerable<SocialMedia>> GetLastNAsync(int n);

    }
}
