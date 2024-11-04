﻿// <auto-generated />
using System;
using DonateHope.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DonateHope.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DonateHope.Domain.Entities.Campaign", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("AchievedAmount")
                        .HasColumnType("numeric")
                        .HasColumnName("achieved_amount");

                    b.Property<string>("ActiveStatusNote")
                        .HasColumnType("text")
                        .HasColumnName("active_status_note");

                    b.Property<double>("AverageRatingPoint")
                        .HasColumnType("double precision")
                        .HasColumnName("average_rating_point");

                    b.Property<int>("CampaignStatusId")
                        .HasColumnType("integer")
                        .HasColumnName("campaign_status_id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("deleted_by");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<DateTime?>("ExpectingEndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expecting_end_date");

                    b.Property<DateTime?>("ExpectingStartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expecting_start_date");

                    b.Property<decimal>("GoalAmount")
                        .HasColumnType("numeric")
                        .HasColumnName("goal_amount");

                    b.Property<string>("GoalStatus")
                        .HasColumnType("text")
                        .HasColumnName("goal_status");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<int>("NumberOfRatings")
                        .HasColumnType("integer")
                        .HasColumnName("number_of_ratings");

                    b.Property<string>("ProofsUrl")
                        .HasColumnType("text")
                        .HasColumnName("proofs_url");

                    b.Property<decimal>("SpendingAmount")
                        .HasColumnType("numeric")
                        .HasColumnName("spending_amount");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<string>("Subtitle")
                        .HasColumnType("text")
                        .HasColumnName("subtitle");

                    b.Property<string>("Summary")
                        .HasColumnType("text")
                        .HasColumnName("summary");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("UnitOfMeasurement")
                        .HasColumnType("text")
                        .HasColumnName("unit_of_measurement");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("updated_by");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_campaigns");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_campaigns_user_id");

                    b.ToTable("campaigns", (string)null);
                });

            modelBuilder.Entity("DonateHope.Domain.Entities.CampaignComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("BannedStatusNote")
                        .HasColumnType("text")
                        .HasColumnName("banned_status_note");

                    b.Property<Guid?>("CampaignId")
                        .HasColumnType("uuid")
                        .HasColumnName("campaign_id");

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("deleted_by");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("boolean")
                        .HasColumnName("is_banned");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("updated_by");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_campaign_comments");

                    b.HasIndex("CampaignId")
                        .HasDatabaseName("ix_campaign_comments_campaign_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_campaign_comments_user_id");

                    b.ToTable("campaign_comments", (string)null);
                });

            modelBuilder.Entity("DonateHope.Domain.Entities.CampaignContribution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<Guid?>("CampaignId")
                        .HasColumnType("uuid")
                        .HasColumnName("campaign_id");

                    b.Property<string>("ContributionMethod")
                        .HasColumnType("text")
                        .HasColumnName("contribution_method");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("deleted_by");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("UnitOfMeasurement")
                        .HasColumnType("text")
                        .HasColumnName("unit_of_measurement");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("updated_by");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_campaign_contributions");

                    b.HasIndex("CampaignId")
                        .HasDatabaseName("ix_campaign_contributions_campaign_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_campaign_contributions_user_id");

                    b.ToTable("campaign_contributions", (string)null);
                });

            modelBuilder.Entity("DonateHope.Domain.Entities.CampaignLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CampaignId")
                        .HasColumnType("uuid")
                        .HasColumnName("campaign_id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("deleted_by");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("ModifiedContents")
                        .HasColumnType("text")
                        .HasColumnName("modified_contents");

                    b.Property<string>("ModifiedFields")
                        .HasColumnType("text")
                        .HasColumnName("modified_fields");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_campaign_logs");

                    b.HasIndex("CampaignId")
                        .HasDatabaseName("ix_campaign_logs_campaign_id");

                    b.ToTable("campaign_logs", (string)null);
                });

            modelBuilder.Entity("DonateHope.Domain.Entities.CampaignRating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("uuid")
                        .HasColumnName("campaign_id");

                    b.Property<string>("Feedback")
                        .HasColumnType("text")
                        .HasColumnName("feedback");

                    b.Property<double>("RatingPoint")
                        .HasColumnType("double precision")
                        .HasColumnName("rating_point");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_campaign_ratings");

                    b.HasIndex("CampaignId")
                        .HasDatabaseName("ix_campaign_ratings_campaign_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_campaign_ratings_user_id");

                    b.ToTable("campaign_ratings", (string)null);
                });

            modelBuilder.Entity("DonateHope.Domain.Entities.CampaignReport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<Guid?>("CampaignId")
                        .HasColumnType("uuid")
                        .HasColumnName("campaign_id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("deleted_by");

                    b.Property<string>("Detail")
                        .HasColumnType("text")
                        .HasColumnName("detail");

                    b.Property<string>("DocumentsUrl")
                        .HasColumnType("text")
                        .HasColumnName("documents_url");

                    b.Property<DateTime?>("FromDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("from_date_time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Subtitle")
                        .HasColumnType("text")
                        .HasColumnName("subtitle");

                    b.Property<string>("Summary")
                        .HasColumnType("text")
                        .HasColumnName("summary");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<DateTime?>("ToDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("to_date_time");

                    b.Property<string>("UnitOfMeasurement")
                        .HasColumnType("text")
                        .HasColumnName("unit_of_measurement");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("updated_by");

                    b.HasKey("Id")
                        .HasName("pk_campaign_reports");

                    b.HasIndex("CampaignId")
                        .HasDatabaseName("ix_campaign_reports_campaign_id");

                    b.ToTable("campaign_reports", (string)null);
                });

            modelBuilder.Entity("DonateHope.Domain.Entities.CampaignStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_campaign_statuses");

                    b.ToTable("campaign_statuses", (string)null);
                });

            modelBuilder.Entity("DonateHope.Domain.IdentityEntities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_app_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("app_roles", (string)null);
                });

            modelBuilder.Entity("DonateHope.Domain.IdentityEntities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ActiveStatusNote")
                        .HasColumnType("text")
                        .HasColumnName("active_status_note");

                    b.Property<string>("BannedStatusNote")
                        .HasColumnType("text")
                        .HasColumnName("banned_status_note");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("deleted_by");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("boolean")
                        .HasColumnName("is_banned");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<DateTime?>("RefreshTokenExpiryDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("refresh_token_expiry_date_time");

                    b.Property<string>("RefreshTokenHash")
                        .HasColumnType("text")
                        .HasColumnName("refresh_token_hash");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("updated_by");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_app_users");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("app_users", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_app_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_app_role_claims_role_id");

                    b.ToTable("app_role_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_app_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_app_user_claims_user_id");

                    b.ToTable("app_user_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_app_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_app_user_logins_user_id");

                    b.ToTable("app_user_logins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_app_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_app_user_roles_role_id");

                    b.ToTable("app_user_roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_app_user_tokens");

                    b.ToTable("app_user_tokens", (string)null);
                });

            modelBuilder.Entity("DonateHope.Domain.Entities.Campaign", b =>
                {
                    b.HasOne("DonateHope.Domain.IdentityEntities.AppUser", null)
                        .WithMany("Campaigns")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_campaigns_app_users_user_id");
                });

            modelBuilder.Entity("DonateHope.Domain.Entities.CampaignComment", b =>
                {
                    b.HasOne("DonateHope.Domain.Entities.Campaign", null)
                        .WithMany("CampaignComments")
                        .HasForeignKey("CampaignId")
                        .HasConstraintName("fk_campaign_comments_campaigns_campaign_id");

                    b.HasOne("DonateHope.Domain.IdentityEntities.AppUser", null)
                        .WithMany("CampaignComments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_campaign_comments_app_users_user_id");
                });

            modelBuilder.Entity("DonateHope.Domain.Entities.CampaignContribution", b =>
                {
                    b.HasOne("DonateHope.Domain.Entities.Campaign", null)
                        .WithMany("CampaignContributions")
                        .HasForeignKey("CampaignId")
                        .HasConstraintName("fk_campaign_contributions_campaigns_campaign_id");

                    b.HasOne("DonateHope.Domain.IdentityEntities.AppUser", null)
                        .WithMany("CampaignContributions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_campaign_contributions_app_users_user_id");
                });

            modelBuilder.Entity("DonateHope.Domain.Entities.CampaignLog", b =>
                {
                    b.HasOne("DonateHope.Domain.Entities.Campaign", null)
                        .WithMany("CampaignLogs")
                        .HasForeignKey("CampaignId")
                        .HasConstraintName("fk_campaign_logs_campaigns_campaign_id");
                });

            modelBuilder.Entity("DonateHope.Domain.Entities.CampaignRating", b =>
                {
                    b.HasOne("DonateHope.Domain.Entities.Campaign", null)
                        .WithMany("CampaignRatings")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_campaign_ratings_campaigns_campaign_id");

                    b.HasOne("DonateHope.Domain.IdentityEntities.AppUser", null)
                        .WithMany("CampaignRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_campaign_ratings_app_users_user_id");
                });

            modelBuilder.Entity("DonateHope.Domain.Entities.CampaignReport", b =>
                {
                    b.HasOne("DonateHope.Domain.Entities.Campaign", null)
                        .WithMany("CampaignReports")
                        .HasForeignKey("CampaignId")
                        .HasConstraintName("fk_campaign_reports_campaigns_campaign_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("DonateHope.Domain.IdentityEntities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_role_claims_app_roles_role_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("DonateHope.Domain.IdentityEntities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_user_claims_app_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("DonateHope.Domain.IdentityEntities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_user_logins_app_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("DonateHope.Domain.IdentityEntities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_user_roles_app_roles_role_id");

                    b.HasOne("DonateHope.Domain.IdentityEntities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_user_roles_app_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("DonateHope.Domain.IdentityEntities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_app_user_tokens_app_users_user_id");
                });

            modelBuilder.Entity("DonateHope.Domain.Entities.Campaign", b =>
                {
                    b.Navigation("CampaignComments");

                    b.Navigation("CampaignContributions");

                    b.Navigation("CampaignLogs");

                    b.Navigation("CampaignRatings");

                    b.Navigation("CampaignReports");
                });

            modelBuilder.Entity("DonateHope.Domain.IdentityEntities.AppUser", b =>
                {
                    b.Navigation("CampaignComments");

                    b.Navigation("CampaignContributions");

                    b.Navigation("CampaignRatings");

                    b.Navigation("Campaigns");
                });
#pragma warning restore 612, 618
        }
    }
}
