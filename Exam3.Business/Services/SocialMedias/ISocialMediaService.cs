using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam3.Business.Models;
using Exam3.Business.Models.SocialMedia;
using Exam3.Business.Models.TeamMember;

namespace Exam3.Business.Services.SocialMedias
{
    public interface ISocialMediaService
    {
        public Task AddAsync(SocialMediaCreateVM model);
        public Task UpdateAsync(int id, SocialMediaUpdateVM model);

        public Task SoftDeleteAsync(int id);
        public Task RevokeSoftDeleteAsync(int id);
        public Task<SocialMediaVM> GetByIdAsync(int id);
        public Task<IEnumerable<SocialMediaVM>> GetAllAsync();
        
        public Task<GenericPaginatedModel<SocialMediaVM>> GetAllPaginatedAsync(int currentpage,int perPage);
    }
}
