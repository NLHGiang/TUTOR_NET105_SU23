using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TUTOR_NET105_SU23.B2.DAL.Entities;

namespace TUTOR_NET105_SU23.B2.DAL.Configurations
{
    public class UserConfigs : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.RoleId).IsRequired(false);
            builder.Property(c => c.UserName).HasMaxLength(20).IsUnicode(false).IsRequired();
            builder.Property(c => c.Password).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(20).IsRequired();
            builder.Property(c => c.PhoneNumber).HasMaxLength(10).IsUnicode(false).IsRequired();
            builder.Property(c => c.Status).IsRequired();

            builder.HasOne<Role>(c => c.Role)
                .WithMany(c => c.Users)
                .HasForeignKey(c => c.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
