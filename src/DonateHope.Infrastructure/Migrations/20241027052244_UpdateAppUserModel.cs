using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonateHope.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAppUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "refresh_token_expiry_date_time",
                table: "app_users",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "app_users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "app_users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "date_of_birth",
                table: "app_users",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "active_status_note",
                table: "app_users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "banned_status_note",
                table: "app_users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "app_users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "created_by",
                table: "app_users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "app_users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "deleted_by",
                table: "app_users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "app_users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_banned",
                table: "app_users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "app_users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "app_users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updated_by",
                table: "app_users",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "active_status_note",
                table: "app_users");

            migrationBuilder.DropColumn(
                name: "banned_status_note",
                table: "app_users");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "app_users");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "app_users");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "app_users");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "app_users");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "app_users");

            migrationBuilder.DropColumn(
                name: "is_banned",
                table: "app_users");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "app_users");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "app_users");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "app_users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "refresh_token_expiry_date_time",
                table: "app_users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "app_users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "app_users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "date_of_birth",
                table: "app_users",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);
        }
    }
}
