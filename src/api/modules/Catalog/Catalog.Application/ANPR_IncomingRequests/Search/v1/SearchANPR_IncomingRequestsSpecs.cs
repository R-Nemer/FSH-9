using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.ANPRIncomingRequests.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.ANPRIncomingRequests.Search.v1;
public class SearchANPR_IncomingRequestspecs : EntitiesByPaginationFilterSpec<ANPR_IncomingRequests, ANPR_IncomingRequestsResponse>
{
    public SearchANPR_IncomingRequestspecs(SearchANPR_IncomingRequestsCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.Plate, !command.HasOrderBy())
            .Where(b => b.Plate.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
