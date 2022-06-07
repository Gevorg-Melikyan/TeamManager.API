using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamManager.Domain.Entities.CommentAgregation;

namespace TeamManager.Infra.Data.AppContexts.Config
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Text);
            builder.Property(b => b.Text)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.Task)
               .WithMany(x => x.Comments)
               .HasForeignKey(x => x.TaskId);

            builder.HasOne(x => x.CommentAuthor).WithMany(x => x.Comments)
              .HasForeignKey(x => x.CommentAuthorId);

            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}
