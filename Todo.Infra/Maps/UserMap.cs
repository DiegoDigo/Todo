using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.UserContext.Entities;

namespace Todo.Infra.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(x => x.Address).IsRequired().HasColumnName("Email").HasColumnType("varchar(160)");
            });
            builder.Property(x => x.Password).IsRequired().HasColumnType("varchar(60)");
            builder.Property(x => x.Role).HasConversion<string>();
        }
    }
}