namespace FSH.Starter.WebApi.Catalog.Application.ANPRIncomingRequests.Get.v1;
public sealed record ANPR_IncomingRequestsResponse(Guid Id, string siteName, string camerIdentifier, string feedIdentifier, string sourceIdentifier,
        string captureTime, double capture_UnixTimeStamp, DateTime? captureDateTime, string signature, string username, string plate,
        string binaryDataType, string imagePath, string iPAddress);
