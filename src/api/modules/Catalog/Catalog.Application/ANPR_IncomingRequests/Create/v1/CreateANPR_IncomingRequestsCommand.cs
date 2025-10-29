using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.ANPRIncomingRequests.Create.v1;
public sealed record CreateANPR_IncomingRequestsCommand(
    [property: DefaultValue("siteName")] string siteName,
    [property: DefaultValue("camerIdentifier")] string camerIdentifier,
    [property: DefaultValue("feedIdentifier")] string feedIdentifier,
    [property: DefaultValue("sourceIdentifier")] string sourceIdentifier,
        [property: DefaultValue("captureTime")] string captureTime,
        [property: DefaultValue(0)] double capture_UnixTimeStamp,
        DateTime? captureDateTime,
        [property: DefaultValue("signature")] string signature,
        [property: DefaultValue("username")] string username,
        [property: DefaultValue("plate")] string plate,
        [property: DefaultValue("binaryDataType")] string binaryDataType,
        [property: DefaultValue("imagePath")] string imagePath,
        [property: DefaultValue("iPAddress")] string iPAddress) : IRequest<CreateANPR_IncomingRequestsResponse>;

