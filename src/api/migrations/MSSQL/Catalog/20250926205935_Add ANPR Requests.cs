using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSH.Starter.WebApi.Migrations.MSSQL.Catalog
{
    /// <inheritdoc />
    public partial class AddANPRRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ANPR_IncomingRequests",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CamerIdentifier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FeedIdentifier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SourceIdentifier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CaptureTime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capture_UnixTimeStamp = table.Column<double>(type: "float", nullable: false),
                    CaptureDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BinaryDataType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANPR_IncomingRequests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ANPR_IncomingRequests",
                schema: "catalog");
        }
    }
}
