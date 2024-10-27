using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonateHope.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingCampaignsAndCampaignRatingsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "campaigns",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    subtitle = table.Column<string>(type: "text", nullable: true),
                    summary = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    goal_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    achieved_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unit_of_measurement = table.Column<string>(type: "text", nullable: true),
                    goal_status = table.Column<string>(type: "text", nullable: true),
                    expecting_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    expecting_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    number_of_ratings = table.Column<int>(type: "integer", nullable: false),
                    average_rating_point = table.Column<double>(type: "double precision", nullable: false),
                    spending_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    proofs_url = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    active_status_note = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_campaigns", x => x.id);
                    table.ForeignKey(
                        name: "fk_campaigns_app_users_user_id",
                        column: x => x.user_id,
                        principalTable: "app_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "campaign_ratings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    feedback = table.Column<string>(type: "text", nullable: true),
                    rating_point = table.Column<double>(type: "double precision", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    campaign_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_campaign_ratings", x => x.id);
                    table.ForeignKey(
                        name: "fk_campaign_ratings_app_users_user_id",
                        column: x => x.user_id,
                        principalTable: "app_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_campaign_ratings_campaigns_campaign_id",
                        column: x => x.campaign_id,
                        principalTable: "campaigns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_campaign_ratings_campaign_id",
                table: "campaign_ratings",
                column: "campaign_id");

            migrationBuilder.CreateIndex(
                name: "ix_campaign_ratings_user_id",
                table: "campaign_ratings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_campaigns_user_id",
                table: "campaigns",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "campaign_ratings");

            migrationBuilder.DropTable(
                name: "campaigns");
        }
    }
}
