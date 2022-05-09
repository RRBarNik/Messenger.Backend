using Messenger.Backend.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Abstractions
{
    public interface IMessengerDbContext
    {
        /// <summary>
        /// Пользователи
        /// </summary>
        DbSet<User> Users { get; }

        /// <summary>
        /// Чаты
        /// </summary>
        DbSet<Chat> Chats { get; }

        /// <summary>
        /// Сообщения
        /// </summary>
        DbSet<Message> Messages { get; }

        /// <summary>
        /// Сохранить изменения единицы работы
        /// </summary>
        /// <param name="cancellationToken">Токен отмены запроса</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
