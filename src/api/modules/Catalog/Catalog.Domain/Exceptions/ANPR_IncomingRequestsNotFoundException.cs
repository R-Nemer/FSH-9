using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class ANPR_IncomingRequestsNotFoundException : NotFoundException
{
    public ANPR_IncomingRequestsNotFoundException(Guid id)
        : base($"ANPR_IncomingRequest with id {id} not found")
    {
    }
}
