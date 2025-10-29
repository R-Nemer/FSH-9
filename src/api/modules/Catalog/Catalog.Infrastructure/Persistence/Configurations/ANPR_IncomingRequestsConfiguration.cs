using Finbuckle.MultiTenant;
using FSH.Starter.WebApi.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Persistence.Configurations;
internal sealed class ANPR_IncomingRequestsConfiguration : IEntityTypeConfiguration<ANPR_IncomingRequests>
{
    public void Configure(EntityTypeBuilder<ANPR_IncomingRequests> builder)
    {
        builder.IsMultiTenant();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.SiteName).HasMaxLength(100);
        builder.Property(x => x.CamerIdentifier).HasMaxLength(100);
        builder.Property(x => x.FeedIdentifier).HasMaxLength(100);
        builder.Property(x => x.SourceIdentifier).HasMaxLength(100);
        builder.Property(x => x.CaptureTime).HasMaxLength(100);
        builder.Property(x => x.Signature).HasMaxLength(100);
        builder.Property(x => x.Username).HasMaxLength(100);
        builder.Property(x => x.Plate).HasMaxLength(100);
        builder.Property(x => x.BinaryDataType).HasMaxLength(100);
        builder.Property(x => x.ImagePath).HasMaxLength(200);
        builder.Property(x => x.IPAddress).HasMaxLength(100);
    }
}
