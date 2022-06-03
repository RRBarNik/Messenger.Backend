using Messenger.Backend.Api.Core.Abstractions;
using Messenger.Backend.Api.Core.Entities;
using Messenger.Backend.Api.Data.PostgreSql.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Backend.Api.Data.PostgreSql
{
    public class MessengerDbContext : IdentityDbContext, IMessengerDbContext
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="options">Параметры подключения к БД</param>
        public MessengerDbContext(DbContextOptions<MessengerDbContext> options) 
            : base(options)
        {
        }

        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Чаты
        /// </summary>
        public DbSet<Chat> Chats { get; set; }

        /// <summary>
        /// Сообщения
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<IdentityUser> IdentityUsers { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
