using FluentValidation;
using MediatR;
using Messenger.Backend.Api.Core.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core
{
    /// <summary>
    /// Регистрация зависимостей проекта
    /// </summary>
    public static class Entry
    {
        /// <summary>
        /// Регистрация зависимостей проекта
        /// </summary>
        /// <param name="services">сервисы</param>
        /// <returns>Контейнер зависимостей</returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));

            return services;
        }
    }
}
