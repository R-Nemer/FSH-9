using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using System.Net;

namespace FSH.Starter.WebApi.Catalog.Application.ANPRIncomingRequests.Get.v1;
public sealed class GetANPR_IncomingRequestsHandler(
    [FromKeyedServices("catalog:aNPR_IncomingRequests")] IReadRepository<ANPR_IncomingRequests> repository,
    ICacheService cache)
    : IRequestHandler<GetANPR_IncomingRequestsRequest, ANPR_IncomingRequestsResponse>
{
    public async Task<ANPR_IncomingRequestsResponse> Handle(GetANPR_IncomingRequestsRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"ANPR_IncomingRequests:{request.Id}",
            async () =>
            {
                var aNPR_IncomingRequestsItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (aNPR_IncomingRequestsItem == null) throw new ANPR_IncomingRequestsNotFoundException(request.Id);
                return new ANPR_IncomingRequestsResponse(aNPR_IncomingRequestsItem.Id, aNPR_IncomingRequestsItem.SiteName, aNPR_IncomingRequestsItem.CamerIdentifier, aNPR_IncomingRequestsItem.FeedIdentifier, aNPR_IncomingRequestsItem.SourceIdentifier,
                aNPR_IncomingRequestsItem.CaptureTime, aNPR_IncomingRequestsItem.Capture_UnixTimeStamp, aNPR_IncomingRequestsItem.CaptureDateTime, aNPR_IncomingRequestsItem.Signature, aNPR_IncomingRequestsItem.Username, aNPR_IncomingRequestsItem.Plate,
                aNPR_IncomingRequestsItem.BinaryDataType, aNPR_IncomingRequestsItem.ImagePath, aNPR_IncomingRequestsItem.IPAddress);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
