using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.ANPRIncomingRequests.EventHandlers;

public class ANPR_IncomingRequestsCreatedEventHandler(ILogger<ANPR_IncomingRequestsCreatedEventHandler> logger) : INotificationHandler<ANPR_IncomingRequestsCreated>
{
    public async Task Handle(ANPR_IncomingRequestsCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling ANPR_IncomingRequests created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling ANPR_IncomingRequests created domain event..");
    }
}
