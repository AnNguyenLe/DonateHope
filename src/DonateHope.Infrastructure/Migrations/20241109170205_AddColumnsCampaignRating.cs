using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonateHope.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsCampaignRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_campaign_contributions_app_users_user_id",
                table: "campaign_contributions");

            migrationBuilder.DropForeignKey(
                name: "fk_campaign_contributions_campaigns_campaign_id",
                table: "campaign_contributions");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "campaign_ratings",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "created_by",
                table: "campaign_ratings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "campaign_ratings",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by",
                table: "campaign_ratings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "campaign_ratings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "reason_for_deletion",
                table: "campaign_ratings",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "campaign_ratings",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by",
                table: "campaign_ratings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "campaign_contributions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "campaign_id",
                table: "campaign_contributions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_campaign_contributions_app_users_user_id",
                table: "campaign_contributions",
                column: "user_id",
                principalTable: "app_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_campaign_contributions_campaigns_campaign_id",
                table: "campaign_contributions",
                column: "campaign_id",
                principalTable: "campaigns",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "campaign_ratings");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "campaign_ratings");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "campaign_ratings");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "campaign_ratings");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "campaign_ratings");

            migrationBuilder.DropColumn(
                name: "reason_for_deletion",
                table: "campaign_ratings");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "campaign_ratings");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "campaign_ratings");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "campaign_contributions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "campaign_id",
                table: "campaign_contributions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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
    }
}
