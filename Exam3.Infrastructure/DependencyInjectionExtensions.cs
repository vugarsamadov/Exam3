using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam3.Infrastructure.Repositories;
using Exam3.Infrastructure.Repositories.Abstract;
using Exam3.Infrastructure.Services;
using Exam3.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Exam3.Infrastructure
{
    public static class DependencyInjectionExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>()
            //    .AddIdentityCore<IdentityUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();    

            return services;
        }
    }
}
