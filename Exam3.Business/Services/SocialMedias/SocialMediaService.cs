using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exam3.Business.Models;
using Exam3.Business.Models.SocialMedia;
using Exam3.Core.Entities;
using Exam3.Infrastructure.Repositories.Abstract;
using Exam3.Infrastructure.Services.Abstract;

namespace Exam3.Business.Services.SocialMedias
{
    public class SocialMediaService : ISocialMediaService
    {

        private ISocialMediaRepository _socialMediaRepository { get; }
        private IMapper _mapper { get; }

        public SocialMediaService(ISocialMediaRepository socialMediaRepo, IMapper mapper)
        {
            _socialMediaRepository = socialMediaRepo;
            _mapper = mapper;
        }

        public async Task AddAsync(SocialMediaCreateVM model)
        {
            var entity = _mapper.Map<SocialMedia>(model);
            await _socialMediaRepository.AddAsync(entity);
            await _socialMediaRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<SocialMediaVM>> GetAllAsync()
        {
            var entities = await _socialMediaRepository.GetAllPaginatedAsync(null, null);
            var models = _mapper.Map<IEnumerable<SocialMediaVM>>(entities);
            return models;
        }

        public async Task RevokeSoftDeleteAsync(int id)
        {
            var entity = await _socialMediaRepository.GetByIdAsync(id, true);
            entity.RevokeDelete();
            await _socialMediaRepository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var entity = await _socialMediaRepository.GetByIdAsync(id, true);
            entity.Delete();
            await _socialMediaRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, SocialMediaUpdateVM model)
        {
            var entity = await _socialMediaRepository.GetByIdAsync(id, true);
            _mapper.Map(model,entity);
            await _socialMediaRepository.SaveChangesAsync();
        }

        public async Task<GenericPaginatedModel<SocialMediaVM>> GetAllPaginatedAsync(int currentpage, int perPage)
        {
            var entities = await _socialMediaRepository.GetAllPaginatedAsync(currentpage, perPage);
            var count = await _socialMediaRepository.CountAsync();
            var models = _mapper.Map<IEnumerable<SocialMediaVM>>(entities);
            var pmodel = new GenericPaginatedModel<SocialMediaVM>(currentpage, count, perPage, models);
            return pmodel;
        }

        public async Task<SocialMediaVM> GetByIdAsync(int id)
        {
            var entity = await _socialMediaRepository.GetByIdAsync(id,false);
            var model = _mapper.Map<SocialMediaVM>(entity);
            return model;
        }
    }
}
