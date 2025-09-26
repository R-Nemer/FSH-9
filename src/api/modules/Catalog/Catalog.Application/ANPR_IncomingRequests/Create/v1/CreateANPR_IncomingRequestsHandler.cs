using System.Net;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.ANPRIncomingRequests.Create.v1;
public sealed class CreateANPR_IncomingRequestsHandler(
    ILogger<CreateANPR_IncomingRequestsHandler> logger,
    [FromKeyedServices("catalog:aNPR_IncomingRequests")] IRepository<ANPR_IncomingRequests> repository)
    : IRequestHandler<CreateANPR_IncomingRequestsCommand, CreateANPR_IncomingRequestsResponse>
{
    public async Task<CreateANPR_IncomingRequestsResponse> Handle(CreateANPR_IncomingRequestsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var aNPR_IncomingRequests = ANPR_IncomingRequests.Create(request.siteName, request.camerIdentifier, request.feedIdentifier, request.sourceIdentifier,
        request.captureTime, request.capture_UnixTimeStamp, request.captureDateTime, request.signature, request.username, request.plate,
        request.binaryDataType, request.imagePath, request.iPAddress);
        await repository.AddAsync(aNPR_IncomingRequests, cancellationToken);
        logger.LogInformation("ANPR_IncomingRequests created {ANPR_IncomingRequestsId}", aNPR_IncomingRequests.Id);
        return new CreateANPR_IncomingRequestsResponse(aNPR_IncomingRequests.Id);
    }
}
