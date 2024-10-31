using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonateHope.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingCampaignStatusesTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_campaigns_campaign_statuses_campaign_status_id",
                table: "campaigns");

            migrationBuilder.DropIndex(
                name: "ix_campaigns_campaign_status_id",
                table: "campaigns");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
