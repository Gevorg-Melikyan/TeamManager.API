using TeamManager.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamManager.Infra.Data.AppContexts.Config
{
    public class UserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(ApplicationUser.Tasks));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Surname);
            builder.Property(b => b.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(b => b.Surname)
                .HasMaxLength(50)
                .IsRequired();           
        }
    }
}
