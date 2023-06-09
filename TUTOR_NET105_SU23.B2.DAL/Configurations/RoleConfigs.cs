using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TUTOR_NET105_SU23.B2.DAL.Entities;

namespace TUTOR_NET105_SU23.B2.DAL.Configurations
{
    public class RoleConfigs : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.RoleName).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Status).IsRequired();

        }
    }
}
