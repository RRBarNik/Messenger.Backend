using Messenger.Backend.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Backend.Api.Data.PostgreSql.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nickname).HasColumnName("nickname");
            builder.Property(x => x.Firstname).HasColumnName("firstname");
            builder.Property(x => x.Lastname).HasColumnName("lastname");
            builder.Property(x => x.Role).HasColumnName("role");
            builder.Property(x => x.ActiveStatus).HasColumnName("active_status");
            builder.Property(x => x.DateOfCreation).HasColumnName("date_of_creation");

            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
        }
    }
}
