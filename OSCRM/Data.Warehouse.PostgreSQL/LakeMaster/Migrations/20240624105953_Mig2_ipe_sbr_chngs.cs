using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Warehouse.PostgreSQL.LakeMaster.Migrations
{
    /// <inheritdoc />
    public partial class Mig2_ipe_sbr_chngs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "payment_frequency_mode_id",
                schema: "insurance",
                table: "scenario_based_recommendation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "commission_saved",
                schema: "insurance",
                table: "insurance_policy_evaluation",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "last_updated_at",
                schema: "insurance",
                table: "insurance_policy_evaluation",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "payment_frequency_mode_id",
                schema: "insurance",
                table: "insurance_policy_evaluation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "premium_saved",
                schema: "insurance",
                table: "insurance_policy_evaluation",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "surrender_val_received",
                schema: "insurance",
                table: "insurance_policy_evaluation",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "user_action_id",
                schema: "insurance",
                table: "insurance_policy_evaluation",
                type: "bigint",
                nullable: false,
                defaultValue: 339L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "payment_frequency_mode_id",
                schema: "insurance",
                table: "scenario_based_recommendation");

            migrationBuilder.DropColumn(
                name: "commission_saved",
                schema: "insurance",
                table: "insurance_policy_evaluation");

            migrationBuilder.DropColumn(
                name: "last_updated_at",
                schema: "insurance",
                table: "insurance_policy_evaluation");

            migrationBuilder.DropColumn(
                name: "payment_frequency_mode_id",
                schema: "insurance",
                table: "insurance_policy_evaluation");

            migrationBuilder.DropColumn(
                name: "premium_saved",
                schema: "insurance",
                table: "insurance_policy_evaluation");

            migrationBuilder.DropColumn(
                name: "surrender_val_received",
                schema: "insurance",
                table: "insurance_policy_evaluation");

            migrationBuilder.DropColumn(
                name: "user_action_id",
                schema: "insurance",
                table: "insurance_policy_evaluation");
        }
    }
}
