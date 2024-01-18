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
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Exam3.Business.Profiles
{
    public class SocialMediaProfile : Profile
    {

        public SocialMediaProfile(IWebHostEnvironment env)
        {
            CreateMap<SocialMediaCreateVM, SocialMedia>()
                .ForMember(c => c.IconUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if (src.Icon != null)
                        dest.IconUrl = await src.Icon.SaveAndRetrieveImageAddressAsync(FileExtensions.SocialMediaImagesPath, env);
                });

            CreateMap<SocialMediaUpdateVM, SocialMedia>()
                .ForMember(c => c.IconUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if (src.Icon != null)
                        dest.IconUrl = await src.Icon.SaveAndRetrieveImageAddressAsync(FileExtensions.SocialMediaImagesPath, env);
                });


            CreateMap<SocialMedia,SocialMediaVM>();
            CreateMap<SocialMediaVM,SocialMediaUpdateVM>();
        }


    }
}
