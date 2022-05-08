using Messenger.Backend.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messenger.Backend.Api.Data.PostgreSql.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("messages");

            builder.Property(x => x.ChatId).HasColumnName("chat_id");
            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.Property(x => x.DateOfCreation).HasColumnName("date_of_creation");
            builder.Property(x => x.Body).HasColumnName("body");

            builder.HasKey(m => new { m.UserId, m.ChatId, m.DateOfCreation });
            builder
                .HasOne(pt => pt.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(pt => pt.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(pt => pt.Chat)
                .WithMany(ch => ch.Messages)
                .HasForeignKey(pt => pt.ChatId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
