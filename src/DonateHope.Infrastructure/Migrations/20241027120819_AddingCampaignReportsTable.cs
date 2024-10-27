using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonateHope.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingCampaignReportsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "campaign_status",
                table: "campaigns",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "campaign_reports",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    from_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    to_date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    title = table.Column<string>(type: "text", nullable: true),
                    subtitle = table.Column<string>(type: "text", nullable: true),
                    summary = table.Column<string>(type: "text", nullable: true),
                    detail = table.Column<string>(type: "text", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unit_of_measurement = table.Column<string>(type: "text", nullable: true),
                    documents_url = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true),
                    campaign_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_campaign_reports", x => x.id);
                    table.ForeignKey(
                        name: "fk_campaign_reports_campaigns_campaign_id",
                        column: x => x.campaign_id,
                        principalTable: "campaigns",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_campaign_reports_campaign_id",
                table: "campaign_reports",
                column: "campaign_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "campaign_reports");

            migrationBuilder.DropColumn(
                name: "campaign_status",
                table: "campaigns");
        }
    }
}
