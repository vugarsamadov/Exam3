using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exam3.Business.Models;
using Exam3.Business.Models.SocialMedia;
using Exam3.Business.Models.TeamMember;
using Exam3.Core.Entities;
using Exam3.Infrastructure.Repositories.Abstract;
using Exam3.Infrastructure.Services;
using Exam3.Infrastructure.Services.Abstract;

namespace Exam3.Business.Services.TeamMembers
{
    public class TeamMemberService : ITeamMemberService
    {

        private ITeamMemberRepository _teamMemberRepository { get; }
        private IMapper _mapper { get; }

        public TeamMemberService(ITeamMemberRepository teamMemberRepo,IMapper mapper)
        {
            _teamMemberRepository = teamMemberRepo;
            _mapper = mapper;
        }


        public async Task AddAsync(CreateTeamMemberVM model)
        {
            var entity = _mapper.Map<TeamMember>(model);
            await _teamMemberRepository.AddAsync(entity);
            await _teamMemberRepository.SaveChangesAsync();
        }

        public async Task AddSocialMediaAsync(int id, AddSocialMediaVM model)
        {
            var teamMember = await _teamMemberRepository.GetByIdAsync(id,true);
            var socialMediaTeamMember = _mapper.Map<SocialMediaTeamMember>(model);
            teamMember.TeamMemberSocialMedias.Add(socialMediaTeamMember);
            await _teamMemberRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TeamMemberVM>> GetAllAsync()
        {
            var entities = await _teamMemberRepository.GetAllPaginatedAsync(null, null);
            var models = _mapper.Map<IEnumerable<TeamMemberVM>>(entities);
            return models;
        }

        public async Task<IEnumerable<TeamMemberVM>> GetLastNTeamMembersAsync(int n)
        {
            var entities = await _teamMemberRepository.GetLastNAsync(n);
            var models = _mapper.Map<IEnumerable<TeamMemberVM>>(entities);
            return models;
        }

        public async Task RevokeSoftDeleteAsync(int id)
        {
            var teamMember = await _teamMemberRepository.GetByIdAsync(id, true);
            teamMember.RevokeDelete();
            await _teamMemberRepository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var teamMember = await _teamMemberRepository.GetByIdAsync(id, true);
            teamMember.Delete();
            await _teamMemberRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateTeamMemberVM model)
        {
            var teamMember = await _teamMemberRepository.GetByIdAsync(id, true);
            _mapper.Map(model, teamMember);
            await _teamMemberRepository.SaveChangesAsync();
        }

        public async Task<GenericPaginatedModel<TeamMemberVM>> GetAllPaginatedAsync(int currentpage, int perPage)
        {
            var entities = await _teamMemberRepository.GetAllPaginatedAsync(currentpage, perPage);
            var count = await _teamMemberRepository.CountAsync();
            var models = _mapper.Map<IEnumerable<TeamMemberVM>>(entities);
            var pmodel = new GenericPaginatedModel<TeamMemberVM>(currentpage, count, perPage, models);
            return pmodel;
        }
        public async Task<TeamMemberVM> GetByIdAsync(int id)
        {
            var entity = await _teamMemberRepository.GetByIdAsync(id, false);
            var model = _mapper.Map<TeamMemberVM>(entity);
            return model;
        }
    }
}
