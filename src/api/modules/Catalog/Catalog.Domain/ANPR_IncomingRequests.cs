using System.ComponentModel.DataAnnotations.Schema;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Framework.Core.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Events;
using System.Xml.Linq;
using System;

namespace FSH.Starter.WebApi.Catalog.Domain;

public class ANPR_IncomingRequests : AuditableEntity, IAggregateRoot
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


    private ANPR_IncomingRequests() { }

    private ANPR_IncomingRequests(Guid id, string siteName, string camerIdentifier, string feedIdentifier, string sourceIdentifier,
        string captureTime, double capture_UnixTimeStamp, DateTime? captureDateTime, string signature, string username, string plate, 
        string binaryDataType, string imagePath, string iPAddress)
    {
        Id = id;
        SiteName = siteName;
        CamerIdentifier = camerIdentifier;
        FeedIdentifier = feedIdentifier;
        SourceIdentifier = sourceIdentifier;
        CaptureTime = captureTime;
        Capture_UnixTimeStamp = capture_UnixTimeStamp;
        CaptureDateTime = captureDateTime;
        Signature = signature;
        Username = username;
        Plate = plate;
        BinaryDataType = binaryDataType;
        ImagePath = imagePath;
        IPAddress = iPAddress;

        QueueDomainEvent(new ANPR_IncomingRequestsCreated { ANPR_IncomingRequests = this });
    }

    public static ANPR_IncomingRequests Create(string siteName, string camerIdentifier, string feedIdentifier, string sourceIdentifier,
        string captureTime, double capture_UnixTimeStamp, DateTime? captureDateTime, string signature, string username, string plate,
        string binaryDataType, string imagePath, string iPAddress)
    {
        return new ANPR_IncomingRequests(Guid.NewGuid(), siteName, camerIdentifier, feedIdentifier, sourceIdentifier,
         captureTime, capture_UnixTimeStamp, captureDateTime, signature, username, plate,
         binaryDataType, imagePath, iPAddress);
    }

    public ANPR_IncomingRequests Update(string siteName, string camerIdentifier, string feedIdentifier, string sourceIdentifier,
        string captureTime, double capture_UnixTimeStamp, DateTime? captureDateTime, string signature, string username, string plate,
        string binaryDataType, string imagePath, string iPAddress)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(siteName) && !string.Equals(SiteName, siteName, StringComparison.OrdinalIgnoreCase))
        {
            SiteName = siteName;
            isUpdated = true;
        }

        if (!string.Equals(CamerIdentifier, camerIdentifier, StringComparison.OrdinalIgnoreCase))
        {
            CamerIdentifier = camerIdentifier;
            isUpdated = true;
        }
        if (!string.Equals(FeedIdentifier, feedIdentifier, StringComparison.OrdinalIgnoreCase))
        {
            FeedIdentifier = feedIdentifier;
            isUpdated = true;
        }
        if (!string.Equals(SourceIdentifier, sourceIdentifier, StringComparison.OrdinalIgnoreCase))
        {
            SourceIdentifier = sourceIdentifier;
            isUpdated = true;
        }
        if (!string.Equals(CaptureTime, captureTime, StringComparison.OrdinalIgnoreCase))
        {
            CaptureTime = captureTime;
            isUpdated = true;
        }
        
        if (AreEqual(Capture_UnixTimeStamp, capture_UnixTimeStamp))
        {
            Capture_UnixTimeStamp = capture_UnixTimeStamp;
            isUpdated = true;
        }

        if (CaptureDateTime != captureDateTime)
        {
            CaptureDateTime = captureDateTime;
            isUpdated = true;
        }

        if (!string.Equals(Signature, signature, StringComparison.OrdinalIgnoreCase))
        {
            Signature = signature;
            isUpdated = true;
        }
        if (!string.Equals(Username, username, StringComparison.OrdinalIgnoreCase))
        {
            Username = username;
            isUpdated = true;
        }
        if (!string.Equals(Plate, plate, StringComparison.OrdinalIgnoreCase))
        {
            Plate = plate;
            isUpdated = true;
        }
        if (!string.Equals(BinaryDataType, binaryDataType, StringComparison.OrdinalIgnoreCase))
        {
            BinaryDataType = binaryDataType;
            isUpdated = true;
        }
        if (!string.Equals(BinaryDataType, binaryDataType, StringComparison.OrdinalIgnoreCase))
        {
            BinaryDataType = binaryDataType;
            isUpdated = true;
        }

        if (!string.Equals(ImagePath, imagePath, StringComparison.OrdinalIgnoreCase))
        {
            ImagePath = imagePath;
            isUpdated = true;
        }

        if (!string.Equals(IPAddress, iPAddress, StringComparison.OrdinalIgnoreCase))
        {
            IPAddress = iPAddress;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new ANPR_IncomingRequestsUpdated { ANPR_IncomingRequests = this });
        }

        return this;
    }
    private bool AreEqual(double a, double b, double tolerance = 0.000001)
    {
        return Math.Abs(a - b) < tolerance;
    }
}

