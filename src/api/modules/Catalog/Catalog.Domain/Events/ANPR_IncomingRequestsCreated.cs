using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record ANPR_IncomingRequestsCreated : DomainEvent
{
    public ANPR_IncomingRequests? ANPR_IncomingRequests { get; set; }
}
