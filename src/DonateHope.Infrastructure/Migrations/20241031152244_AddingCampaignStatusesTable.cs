using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DonateHope.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingCampaignStatusesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "campaign_status",
                table: "campaigns");

            migrationBuilder.AddColumn<int>(
                name: "campaign_status_id",
                table: "campaigns",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "campaign_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_campaign_statuses", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_campaigns_campaign_status_id",
                table: "campaigns",
                column: "campaign_status_id");

            migrationBuilder.AddForeignKey(
                name: "fk_campaigns_campaign_statuses_campaign_status_id",
                table: "campaigns",
                column: "campaign_status_id",
                principalTable: "campaign_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_campaigns_campaign_statuses_campaign_status_id",
                table: "campaigns");

            migrationBuilder.DropTable(
                name: "campaign_statuses");

            migrationBuilder.DropIndex(
                name: "ix_campaigns_campaign_status_id",
                table: "campaigns");

            migrationBuilder.DropColumn(
                name: "campaign_status_id",
                table: "campaigns");

            migrationBuilder.AddColumn<string>(
                name: "campaign_status",
                table: "campaigns",
                type: "text",
                nullable: true);
        }
    }
}
