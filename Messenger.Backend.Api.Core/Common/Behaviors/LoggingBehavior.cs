using MediatR;
using Messenger.Backend.Api.Core.Abstractions;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Backend.Api.Core.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest
        : IRequest<TResponse>
    {
        ICurrentUserService _currentUserService;

        public LoggingBehavior(ICurrentUserService currentUserService) =>
            _currentUserService = currentUserService;

        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId;

            Log.Information("Messages Request: {Name} {@UserId} {@Request}",
                requestName, userId, request);

            var response = await next();
            return response;
        }
    }
}
