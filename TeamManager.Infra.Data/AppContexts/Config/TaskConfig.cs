using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamManager.Domain.Entities.TaskAgregation;

namespace TeamManager.Infra.Data.AppContexts.Config
{
    public class TaskConfig : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name);
            builder.Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(b => b.Description)
                .IsRequired();
            builder.HasOne(x => x.Project)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.ProjectId);
            builder.HasOne(x => x.ApplicationUser).WithMany(x => x.Tasks)
              .HasForeignKey(x => x.ApplicationUserId);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}