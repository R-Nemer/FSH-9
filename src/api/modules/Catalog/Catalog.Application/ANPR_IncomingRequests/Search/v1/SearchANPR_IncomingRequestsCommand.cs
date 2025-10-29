using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.ANPRIncomingRequests.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.ANPRIncomingRequests.Search.v1;

public class SearchANPR_IncomingRequestsCommand : PaginationFilter, IRequest<PagedList<ANPR_IncomingRequestsResponse>>
{
    public string SiteName { get; set; }
    public string CamerIdentifier { get; set; }
    public string FeedIdentifier { get; set; }
    public string SourceIdentifier { get; set; }
    public string CaptureTime { get; set; }
    public double Capture_UnixTimeStamp { get; set; } = 0;
    public DateTime? CaptureDateTime { get; set; }
    public string Signature { get; set; }
    public string Username { get; set; }
    public string Plate { get; set; }
    public string BinaryDataType { get; set; }
    public string ImagePath { get; set; }
    public string IPAddress { get; set; }
}
