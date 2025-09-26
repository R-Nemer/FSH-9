using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.ANPRIncomingRequests.Get.v1;
public class GetANPR_IncomingRequestsRequest : IRequest<ANPR_IncomingRequestsResponse>
{
    public Guid Id { get; set; }
    public GetANPR_IncomingRequestsRequest(Guid id) => Id = id;
}
