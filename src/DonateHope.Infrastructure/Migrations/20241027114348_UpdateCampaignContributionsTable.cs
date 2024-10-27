using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonateHope.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCampaignContributionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_campaign_contribution_app_users_user_id",
                table: "campaign_contribution");

            migrationBuilder.DropForeignKey(
                name: "fk_campaign_contribution_campaigns_campaign_id",
                table: "campaign_contribution");

            migrationBuilder.DropPrimaryKey(
                name: "pk_campaign_contribution",
                table: "campaign_contribution");

            migrationBuilder.RenameTable(
                name: "campaign_contribution",
                newName: "campaign_contributions");

            migrationBuilder.RenameIndex(
                name: "ix_campaign_contribution_user_id",
                table: "campaign_contributions",
                newName: "ix_campaign_contributions_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_campaign_contribution_campaign_id",
                table: "campaign_contributions",
                newName: "ix_campaign_contributions_campaign_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_campaign_contributions",
                table: "campaign_contributions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_campaign_contributions_app_users_user_id",
                table: "campaign_contributions",
                column: "user_id",
                principalTable: "app_users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_campaign_contributions_campaigns_campaign_id",
                table: "campaign_contributions",
                column: "campaign_id",
                principalTable: "campaigns",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_campaign_contributions_app_users_user_id",
                table: "campaign_contributions");

            migrationBuilder.DropForeignKey(
                name: "fk_campaign_contributions_campaigns_campaign_id",
                table: "campaign_contributions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_campaign_contributions",
                table: "campaign_contributions");

            migrationBuilder.RenameTable(
                name: "campaign_contributions",
                newName: "campaign_contribution");

            migrationBuilder.RenameIndex(
                name: "ix_campaign_contributions_user_id",
                table: "campaign_contribution",
                newName: "ix_campaign_contribution_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_campaign_contributions_campaign_id",
                table: "campaign_contribution",
                newName: "ix_campaign_contribution_campaign_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_campaign_contribution",
                table: "campaign_contribution",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_campaign_contribution_app_users_user_id",
                table: "campaign_contribution",
                column: "user_id",
                principalTable: "app_users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_campaign_contribution_campaigns_campaign_id",
                table: "campaign_contribution",
                column: "campaign_id",
                principalTable: "campaigns",
                principalColumn: "id");
        }
    }
}
