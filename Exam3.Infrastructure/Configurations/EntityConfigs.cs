using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam3.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam3.Infrastructure.Configurations
{
    public class SocialMediaConfig : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.HasMany(sm => sm.TeamMemberSocialMedias).WithOne(tmsm => tmsm.SocialMedia)
                .HasForeignKey(tmsm=>tmsm.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class TeamMemberConfig : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.HasMany(tm => tm.TeamMemberSocialMedias).WithOne(tmsm => tmsm.TeamMember)
                .HasForeignKey(tmsm => tmsm.TeamMemberId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
