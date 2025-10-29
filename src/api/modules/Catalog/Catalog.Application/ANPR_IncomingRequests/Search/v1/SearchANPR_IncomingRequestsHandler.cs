using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.ANPRIncomingRequests.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.ANPRIncomingRequests.Search.v1;
public sealed class SearchANPR_IncomingRequestsHandler(
    [FromKeyedServices("catalog:aNPR_IncomingRequests")] IReadRepository<ANPR_IncomingRequests> repository)
    : IRequestHandler<SearchANPR_IncomingRequestsCommand, PagedList<ANPR_IncomingRequestsResponse>>
{
    public async Task<PagedList<ANPR_IncomingRequestsResponse>> Handle(SearchANPR_IncomingRequestsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchANPR_IncomingRequestspecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<ANPR_IncomingRequestsResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
