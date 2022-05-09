using Messenger.Backend.Api.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Backend.Api.Data.PostgreSql
{
    /// <summary>
    /// Регистрация зависимостей проекта
    /// </summary>
    public static class Entry
    {
        /// <summary>
        ///Регистрация зависимостей проекта
        /// </summary>
        /// <param name="services">Сервис</param>
        /// <param name="configuration">Конфигурация</param>
        /// <returns>Контейнер зависимостей</returns>
        public static IServiceCollection AddPostgreSql(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<MessengerDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IMessengerDbContext>(provider =>
                provider.GetService<MessengerDbContext>());

            return services;
        }
    }
}
