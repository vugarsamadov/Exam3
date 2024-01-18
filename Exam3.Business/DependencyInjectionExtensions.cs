using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam3.Infrastructure.Repositories.Abstract;
using Exam3.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Exam3.Business.Models.TeamMember;
using Exam3.Business.Services.TeamMembers;
using Exam3.Business.Services.SocialMedias;
using Microsoft.AspNetCore.Hosting;
using Exam3.Business.Profiles;

namespace Exam3.Business
{
    public static class DependencyInjectionExtensions
    {


        public static IServiceCollection AddBusiness(this IServiceCollection services,IWebHostEnvironment env)
        {
            services.AddAutoMapper(options=>
                {
                    options.AddProfile(new TeamMemberProfile(env));
                    options.AddProfile(new SocialMediaProfile(env));
                });

            services.AddScoped<ITeamMemberService, TeamMemberService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();

            return services;
        }

    }
}
