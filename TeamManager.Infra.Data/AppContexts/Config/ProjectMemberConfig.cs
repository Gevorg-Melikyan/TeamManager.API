using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamManager.Domain.Entities.ProjectAggregation;

namespace TeamManager.Infra.Data.AppContexts.Config
{
    public class ProjectMemberConfig : IEntityTypeConfiguration<ProjectMember>
    {
        public void Configure(EntityTypeBuilder<ProjectMember> builder)
        {
            builder.HasOne(b => b.Project).WithMany(b => b.Members).HasForeignKey(b => b.ProjectId);
      

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}
