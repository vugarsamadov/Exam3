using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Exam3.Business.Models.SocialMedia;
using Exam3.Business.Models.TeamMember;
using Exam3.Core.Entities;
using Microsoft.AspNetCore.Hosting;

namespace Exam3.Business.Profiles
{
    public class TeamMemberProfile : Profile
    {
        public TeamMemberProfile(IWebHostEnvironment env)
        {
            CreateMap<CreateTeamMemberVM, TeamMember>()
                .ForMember(c => c.ImageUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if (src.Image != null)
                        dest.ImageUrl = await src.Image.SaveAndRetrieveImageAddressAsync(FileExtensions.TeamMemberImagesPath,env);
                });

            CreateMap<UpdateTeamMemberVM, TeamMember>()
                .ForMember(c => c.ImageUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if (src.Image != null)
                        dest.ImageUrl = await src.Image.SaveAndRetrieveImageAddressAsync(FileExtensions.TeamMemberImagesPath, env);
                });

            CreateMap<SocialMediaTeamMember, TeamMemberSocialMediaVM>()
                .ForMember(c => c.SocialMediaIconUrl, opt => opt.MapFrom(c => c.SocialMedia.IconUrl))
                .ForMember(c => c.SocialMediaName, opt => opt.MapFrom(c => c.SocialMedia.Name));


            CreateMap<TeamMember, TeamMemberVM>()
                .ForMember(c=>c.SocialMedias,opt=>opt.MapFrom(a=>a.TeamMemberSocialMedias));

            
        }

    }
}
