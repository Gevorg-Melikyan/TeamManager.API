using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamManager.Domain.Entities.ProjectAggregation;
using TeamManager.Domain.Entities.ProjectAgregation;

namespace TeamManager.Infra.Data.AppContexts.Config
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name);
            builder.Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}