using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Warehouse.PostgreSQL.LakeMaster.Migrations
{
    /// <inheritdoc />
    public partial class InsuranceMig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "insurance");

            migrationBuilder.CreateTable(
                name: "about_insurer",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    founded_in = table.Column<int>(type: "integer", nullable: false),
                    ceo = table.Column<string>(type: "text", nullable: false),
                    headquarters = table.Column<string>(type: "text", nullable: false),
                    aum = table.Column<string>(type: "text", nullable: false),
                    gwp = table.Column<string>(type: "text", nullable: true),
                    combined_ratio = table.Column<string>(type: "text", nullable: true),
                    premium_underwritten = table.Column<string>(type: "text", nullable: true),
                    nof_policies = table.Column<double>(type: "double precision", nullable: true),
                    nof_claims = table.Column<double>(type: "double precision", nullable: true),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_about_insurer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    parent_category_id = table.Column<long>(type: "bigint", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    guidance = table.Column<string>(type: "text", nullable: true),
                    weightage = table.Column<double>(type: "double precision", nullable: true),
                    prescripton = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_id = table.Column<long>(type: "bigint", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    parent_category_id = table.Column<long>(type: "bigint", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    existence_year = table.Column<int>(type: "integer", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer_profile",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_code = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    dob = table.Column<DateOnly>(type: "date", nullable: true),
                    gender = table.Column<string>(type: "text", nullable: true),
                    mobile_number = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    money_sign = table.Column<string>(type: "text", nullable: true),
                    martial_status = table.Column<string>(type: "text", nullable: true),
                    education = table.Column<string>(type: "text", nullable: true),
                    retirement_age = table.Column<long>(type: "bigint", nullable: true),
                    member_id = table.Column<string>(type: "text", nullable: true),
                    pan_no = table.Column<string>(type: "text", nullable: true),
                    pan_name = table.Column<string>(type: "text", nullable: true),
                    email_verified = table.Column<bool>(type: "boolean", nullable: true),
                    ms_completed_date = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_profile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hi_claims_experience",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    logo_url = table.Column<string>(type: "text", nullable: true),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    claim_settled_ratio = table.Column<decimal>(type: "numeric", nullable: false),
                    ageing_of_claim = table.Column<decimal>(type: "numeric", nullable: false),
                    incurred_claim_ratio = table.Column<decimal>(type: "numeric", nullable: false),
                    network_hospitals = table.Column<long>(type: "bigint", nullable: true),
                    claim_settled_ratio_abs_amt = table.Column<decimal>(type: "numeric", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hi_claims_experience", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hi_maintain_version",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hi_mst = table.Column<long>(type: "bigint", nullable: false),
                    hi_claims_experience = table.Column<long>(type: "bigint", nullable: false),
                    hi_standard_features = table.Column<long>(type: "bigint", nullable: false),
                    hi_product_card = table.Column<long>(type: "bigint", nullable: false),
                    hi_about_insurer = table.Column<long>(type: "bigint", nullable: false),
                    v = table.Column<long>(type: "bigint", nullable: false),
                    health_cat_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hi_maintain_version", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hi_mst",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    uin_code = table.Column<string>(type: "text", nullable: true),
                    cover_plan = table.Column<decimal>(type: "numeric", nullable: false),
                    pricing_1a = table.Column<decimal>(type: "numeric", nullable: true),
                    min_age = table.Column<decimal>(type: "numeric", nullable: true),
                    max_age = table.Column<decimal>(type: "numeric", nullable: true),
                    pricing_1a_1c = table.Column<decimal>(type: "numeric", nullable: true),
                    pricing_1a_2c = table.Column<decimal>(type: "numeric", nullable: true),
                    pricing_2a = table.Column<decimal>(type: "numeric", nullable: true),
                    pricing_2a_1c = table.Column<decimal>(type: "numeric", nullable: true),
                    pricing_2a_2c = table.Column<decimal>(type: "numeric", nullable: true),
                    min_age_ff = table.Column<decimal>(type: "numeric", nullable: true),
                    max_age_ff = table.Column<decimal>(type: "numeric", nullable: true),
                    room_description = table.Column<string>(type: "text", nullable: false),
                    room_rent_score = table.Column<decimal>(type: "numeric", nullable: false),
                    no_claim_bonus = table.Column<string>(type: "text", nullable: false),
                    ncb_score = table.Column<decimal>(type: "numeric", nullable: false),
                    recharge_sum_insured = table.Column<string>(type: "text", nullable: false),
                    si_recharge_score = table.Column<decimal>(type: "numeric", nullable: false),
                    pre_existing_disease = table.Column<string>(type: "text", nullable: false),
                    ped_score = table.Column<decimal>(type: "numeric", nullable: false),
                    co_pay = table.Column<string>(type: "text", nullable: false),
                    co_pay_score = table.Column<decimal>(type: "numeric", nullable: false),
                    health_and_wellness = table.Column<string>(type: "text", nullable: false),
                    hw_score = table.Column<decimal>(type: "numeric", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    as_on_date = table.Column<DateOnly>(type: "date", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hi_mst", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hi_output",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    uin_code = table.Column<string>(type: "text", nullable: false),
                    logo_url = table.Column<string>(type: "text", nullable: false),
                    parent_category_id = table.Column<long>(type: "bigint", nullable: true),
                    insurer = table.Column<string>(type: "text", nullable: true),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    insurance_plan = table.Column<string>(type: "text", nullable: false),
                    cover_plan = table.Column<decimal>(type: "numeric", nullable: false),
                    pricing = table.Column<decimal>(type: "numeric", nullable: false),
                    min_age = table.Column<decimal>(type: "numeric", nullable: false),
                    max_age = table.Column<decimal>(type: "numeric", nullable: true),
                    room_description = table.Column<string>(type: "text", nullable: false),
                    room_rent_score = table.Column<decimal>(type: "numeric", nullable: false),
                    no_claim_bonus = table.Column<string>(type: "text", nullable: false),
                    ncb_score = table.Column<decimal>(type: "numeric", nullable: false),
                    recharge_sum_insured = table.Column<string>(type: "text", nullable: false),
                    si_recharge_score = table.Column<decimal>(type: "numeric", nullable: false),
                    pre_existing_disease = table.Column<string>(type: "text", nullable: false),
                    ped_score = table.Column<decimal>(type: "numeric", nullable: false),
                    co_pay = table.Column<string>(type: "text", nullable: false),
                    co_pay_score = table.Column<decimal>(type: "numeric", nullable: false),
                    health_and_wellness = table.Column<string>(type: "text", nullable: false),
                    hw_score = table.Column<decimal>(type: "numeric", nullable: false),
                    pricing_score = table.Column<decimal>(type: "numeric", nullable: false),
                    claim_settlement_ratio = table.Column<decimal>(type: "numeric", nullable: false),
                    csr_score = table.Column<decimal>(type: "numeric", nullable: true),
                    ageing_of_claim = table.Column<decimal>(type: "numeric", nullable: false),
                    aoc_score = table.Column<decimal>(type: "numeric", nullable: true),
                    incurred_claim_ratio = table.Column<decimal>(type: "numeric", nullable: false),
                    icr_score = table.Column<decimal>(type: "numeric", nullable: true),
                    network_hospitals = table.Column<long>(type: "bigint", nullable: true),
                    nh_score = table.Column<decimal>(type: "numeric", nullable: false),
                    claim_settled_ratio_abs_amt = table.Column<decimal>(type: "numeric", nullable: false),
                    csr_abs_amt_score = table.Column<decimal>(type: "numeric", nullable: false),
                    one_fin_score = table.Column<decimal>(type: "numeric", nullable: true),
                    one_fin_rank = table.Column<long>(type: "bigint", nullable: false),
                    total_ranking = table.Column<long>(type: "bigint", nullable: false),
                    rank_ratio = table.Column<string>(type: "text", nullable: false),
                    avg_claims_experience_score = table.Column<decimal>(type: "numeric", nullable: true),
                    avg_product_features_score = table.Column<decimal>(type: "numeric", nullable: true),
                    standard_feature = table.Column<string>(type: "json", nullable: false),
                    product_card = table.Column<string>(type: "text", nullable: false),
                    pros = table.Column<string>(type: "jsonb", nullable: true),
                    cons = table.Column<string>(type: "jsonb", nullable: true),
                    hi_about_insurer = table.Column<string>(type: "json", nullable: true),
                    sequence = table.Column<int>(type: "integer", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hi_output", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hi_output_ff",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    uin_code = table.Column<string>(type: "text", nullable: false),
                    logo_url = table.Column<string>(type: "text", nullable: false),
                    parent_category_id = table.Column<long>(type: "bigint", nullable: true),
                    insurer = table.Column<string>(type: "text", nullable: true),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    insurance_plan = table.Column<string>(type: "text", nullable: false),
                    cover_plan = table.Column<decimal>(type: "numeric", nullable: false),
                    pricing = table.Column<decimal>(type: "numeric", nullable: false),
                    min_age = table.Column<decimal>(type: "numeric", nullable: false),
                    max_age = table.Column<decimal>(type: "numeric", nullable: true),
                    room_description = table.Column<string>(type: "text", nullable: false),
                    room_rent_score = table.Column<decimal>(type: "numeric", nullable: false),
                    no_claim_bonus = table.Column<string>(type: "text", nullable: false),
                    ncb_score = table.Column<decimal>(type: "numeric", nullable: false),
                    recharge_sum_insured = table.Column<string>(type: "text", nullable: false),
                    si_recharge_score = table.Column<decimal>(type: "numeric", nullable: false),
                    pre_existing_disease = table.Column<string>(type: "text", nullable: false),
                    ped_score = table.Column<decimal>(type: "numeric", nullable: false),
                    co_pay = table.Column<string>(type: "text", nullable: false),
                    co_pay_score = table.Column<decimal>(type: "numeric", nullable: false),
                    health_and_wellness = table.Column<string>(type: "text", nullable: false),
                    hw_score = table.Column<decimal>(type: "numeric", nullable: false),
                    pricing_score = table.Column<decimal>(type: "numeric", nullable: false),
                    claim_settlement_ratio = table.Column<decimal>(type: "numeric", nullable: false),
                    csr_score = table.Column<decimal>(type: "numeric", nullable: true),
                    ageing_of_claim = table.Column<decimal>(type: "numeric", nullable: false),
                    aoc_score = table.Column<decimal>(type: "numeric", nullable: true),
                    incurred_claim_ratio = table.Column<decimal>(type: "numeric", nullable: false),
                    icr_score = table.Column<decimal>(type: "numeric", nullable: true),
                    network_hospitals = table.Column<long>(type: "bigint", nullable: true),
                    nh_score = table.Column<decimal>(type: "numeric", nullable: false),
                    claim_settled_ratio_abs_amt = table.Column<decimal>(type: "numeric", nullable: false),
                    csr_abs_amt_score = table.Column<decimal>(type: "numeric", nullable: false),
                    one_fin_score = table.Column<decimal>(type: "numeric", nullable: true),
                    one_fin_rank = table.Column<long>(type: "bigint", nullable: false),
                    total_ranking = table.Column<long>(type: "bigint", nullable: false),
                    rank_ratio = table.Column<string>(type: "text", nullable: false),
                    avg_claims_experience_score = table.Column<decimal>(type: "numeric", nullable: true),
                    avg_product_features_score = table.Column<decimal>(type: "numeric", nullable: true),
                    standard_feature = table.Column<string>(type: "json", nullable: false),
                    product_card = table.Column<string>(type: "text", nullable: false),
                    pros = table.Column<string>(type: "jsonb", nullable: true),
                    cons = table.Column<string>(type: "jsonb", nullable: true),
                    hi_about_insurer = table.Column<string>(type: "json", nullable: true),
                    sequence = table.Column<int>(type: "integer", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hi_output_ff", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hi_product_card",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    min_score = table.Column<decimal>(type: "numeric", nullable: false),
                    max_score = table.Column<decimal>(type: "numeric", nullable: false),
                    pricing = table.Column<string>(type: "text", nullable: false),
                    claim_settled_ratio = table.Column<string>(type: "text", nullable: false),
                    claim_settled_ratio_abs_amt = table.Column<string>(type: "text", nullable: false),
                    incurred_claim_ratio = table.Column<string>(type: "text", nullable: false),
                    ageing_of_claim = table.Column<string>(type: "text", nullable: false),
                    network_hospitals = table.Column<string>(type: "text", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hi_product_card", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hi_standard_feature",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    pre_hospitalisation = table.Column<string>(type: "text", nullable: false),
                    post_hospitalisation = table.Column<string>(type: "text", nullable: false),
                    daycare_treatments = table.Column<string>(type: "text", nullable: true),
                    ambulance_cover = table.Column<string>(type: "text", nullable: true),
                    domiciliary_hospitalisation = table.Column<string>(type: "text", nullable: true),
                    organ_donor_cover = table.Column<string>(type: "text", nullable: true),
                    second_opinion = table.Column<string>(type: "text", nullable: true),
                    daily_allowance = table.Column<string>(type: "text", nullable: true),
                    ayush_treatment = table.Column<string>(type: "text", nullable: true),
                    modern_treatment = table.Column<string>(type: "text", nullable: true),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hi_standard_feature", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_code = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    accrued_bonus = table.Column<double>(type: "double precision", nullable: true),
                    expiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_manual_entry = table.Column<bool>(type: "boolean", nullable: false),
                    fetched_source = table.Column<string>(type: "text", nullable: true),
                    months = table.Column<long>(type: "bigint", nullable: false),
                    coverage = table.Column<double>(type: "double precision", nullable: true),
                    annual_premium = table.Column<double>(type: "double precision", nullable: true),
                    pending_tenure = table.Column<double>(type: "double precision", nullable: true),
                    payment_frequency = table.Column<long>(type: "bigint", nullable: true),
                    start_date = table.Column<DateOnly>(type: "date", nullable: true),
                    maturity_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_date = table.Column<DateOnly>(type: "date", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurance", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "insurance_policy_evaluation",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_code = table.Column<Guid>(type: "uuid", nullable: false),
                    policy_name = table.Column<string>(type: "text", nullable: false),
                    plan_type_id = table.Column<int>(type: "integer", nullable: false),
                    plan_type = table.Column<string>(type: "text", nullable: false),
                    plan_category_id = table.Column<int>(type: "integer", nullable: true),
                    plan_category = table.Column<string>(type: "text", nullable: true),
                    policy_start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    policy_tenure = table.Column<int>(type: "integer", nullable: false),
                    premium_paying_tenure = table.Column<int>(type: "integer", nullable: false),
                    annual_premium = table.Column<decimal>(type: "numeric", nullable: false),
                    life_cover = table.Column<decimal>(type: "numeric", nullable: false),
                    premium_paid_till_date = table.Column<decimal>(type: "numeric", nullable: false),
                    premium_payable = table.Column<decimal>(type: "numeric", nullable: false),
                    suggested_action = table.Column<string>(type: "text", nullable: true),
                    surrender_value = table.Column<string>(type: "text", nullable: true),
                    surrender_value_integer = table.Column<decimal>(type: "numeric", nullable: false),
                    scenario = table.Column<int>(type: "integer", nullable: true),
                    accrued_bonus = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurance_policy_evaluation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ip_category",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_id = table.Column<long>(type: "bigint", nullable: true),
                    uin_code = table.Column<string>(type: "text", nullable: true),
                    logo_url = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    parent_category_id = table.Column<long>(type: "bigint", nullable: true),
                    financial_year = table.Column<string>(type: "text", nullable: true),
                    distribution_method_id = table.Column<long>(type: "bigint", nullable: true),
                    plan_type_id = table.Column<long>(type: "bigint", nullable: true),
                    opening_date = table.Column<DateOnly>(type: "date", nullable: true),
                    closing_date = table.Column<DateOnly>(type: "date", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    existing_year = table.Column<int>(type: "integer", nullable: true),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ip_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ipe_recommendation_summary",
                schema: "insurance",
                columns: table => new
                {
                    customer_code = table.Column<Guid>(type: "uuid", nullable: false),
                    existing_annual_premium = table.Column<decimal>(type: "numeric", nullable: false),
                    existing_cover = table.Column<decimal>(type: "numeric", nullable: false),
                    recommended_term_annual_premium = table.Column<decimal>(type: "numeric", nullable: false),
                    recommended_term_cover = table.Column<decimal>(type: "numeric", nullable: false),
                    net_savings = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ipe_recommendation_summary", x => x.customer_code);
                });

            migrationBuilder.CreateTable(
                name: "plan_type",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    parent_type_id = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    category_id = table.Column<long>(type: "bigint", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plan_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pmwell_response",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_code = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    duration = table.Column<long>(type: "bigint", nullable: true),
                    start_age = table.Column<long>(type: "bigint", nullable: true),
                    cover = table.Column<double>(type: "double precision", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pmwell_response", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "scenario_based_recommendation",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    plan_type_id = table.Column<long>(type: "bigint", nullable: false),
                    plan_category_description = table.Column<string>(type: "text", nullable: true),
                    scenario = table.Column<long>(type: "bigint", nullable: false),
                    action_rule = table.Column<string>(type: "text", nullable: false),
                    applicability = table.Column<string>(type: "text", nullable: true),
                    rationale = table.Column<string>(type: "text", nullable: true),
                    based_on_suggested = table.Column<string>(type: "text", nullable: true),
                    remark = table.Column<string>(type: "text", nullable: true),
                    comment = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scenario_based_recommendation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ti_maintain_version",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ti_mst = table.Column<long>(type: "bigint", nullable: false),
                    ti_about_insurer = table.Column<long>(type: "bigint", nullable: false),
                    ti_product_feature = table.Column<long>(type: "bigint", nullable: false),
                    ti_unique_sentence = table.Column<long>(type: "bigint", nullable: false),
                    ti_rationale = table.Column<long>(type: "bigint", nullable: false),
                    v = table.Column<long>(type: "bigint", nullable: false),
                    term_cat_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ti_maintain_version", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ti_mst",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    uin_code = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: true),
                    min_age = table.Column<decimal>(type: "numeric", nullable: false),
                    max_age = table.Column<decimal>(type: "numeric", nullable: true),
                    policy_term = table.Column<int>(type: "integer", nullable: false),
                    sum_assured = table.Column<decimal>(type: "numeric", nullable: false),
                    annual_premium = table.Column<decimal>(type: "numeric", nullable: false),
                    max_age_at_maturity = table.Column<decimal>(type: "numeric", nullable: false),
                    max_policy_term = table.Column<decimal>(type: "numeric", nullable: false),
                    premium_payment_options = table.Column<string[]>(type: "text[]", nullable: false),
                    payment_frequency = table.Column<string[]>(type: "text[]", nullable: false),
                    payout_option = table.Column<string>(type: "text", nullable: false),
                    rider_type = table.Column<string>(type: "text", nullable: false),
                    nof_diseases_covered_critical_illness = table.Column<int>(type: "integer", nullable: true),
                    max_age_cover_for_ci = table.Column<int>(type: "integer", nullable: true),
                    max_age_cover_for_accidental_disability = table.Column<int>(type: "integer", nullable: true),
                    max_age_at_entry = table.Column<int>(type: "integer", nullable: false),
                    min_sum_assured = table.Column<string>(type: "text", nullable: false),
                    max_sum_assured = table.Column<string>(type: "text", nullable: false),
                    solvency_ratio = table.Column<decimal>(type: "numeric", nullable: false),
                    pr_13M_by_nof_policies_per = table.Column<decimal>(type: "numeric", nullable: false),
                    pr_13M_by_annualized_premium_per = table.Column<decimal>(type: "numeric", nullable: false),
                    pr_61M_by_nof_policies_per = table.Column<decimal>(type: "numeric", nullable: false),
                    pr_61M_by_by_annualized_premium_per = table.Column<decimal>(type: "numeric", nullable: false),
                    commission_ratio_per = table.Column<decimal>(type: "numeric", nullable: false),
                    claimed_paid_benefit_amt_per = table.Column<decimal>(type: "numeric", nullable: false),
                    claim_settlement_ratio_per = table.Column<decimal>(type: "numeric", nullable: false),
                    claim_paid_nof_policies_per = table.Column<decimal>(type: "numeric", nullable: false),
                    nof_claims_complaints_per_10000 = table.Column<decimal>(type: "numeric", nullable: false),
                    aoc_paid_less_than_3_mos_per = table.Column<decimal>(type: "numeric", nullable: false),
                    aoc_paid_from_3_to_6_mos_per = table.Column<decimal>(type: "numeric", nullable: false),
                    aoc_paid_from_6_to_12_mos_per = table.Column<decimal>(type: "numeric", nullable: false),
                    aoc_paid_more_than_1_yr_per = table.Column<decimal>(type: "numeric", nullable: false),
                    aoc_pending_eoy_per = table.Column<decimal>(type: "numeric", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ti_mst", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ti_output",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    sum_assured = table.Column<decimal>(type: "numeric", nullable: false),
                    min_age = table.Column<decimal>(type: "numeric", nullable: false),
                    max_age = table.Column<decimal>(type: "numeric", nullable: true),
                    annual_premium = table.Column<decimal>(type: "numeric", nullable: false),
                    logo_url = table.Column<string>(type: "text", nullable: true),
                    parent_category_id = table.Column<long>(type: "bigint", nullable: true),
                    insurer = table.Column<string>(type: "text", nullable: true),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    uin_code = table.Column<string>(type: "text", nullable: false),
                    insurance_plan = table.Column<string>(type: "text", nullable: false),
                    one_fin_score = table.Column<decimal>(type: "numeric", nullable: false),
                    one_fin_rank = table.Column<long>(type: "bigint", nullable: false),
                    total_ranking = table.Column<long>(type: "bigint", nullable: false),
                    rank_ratio = table.Column<string>(type: "text", nullable: false),
                    pricing_score = table.Column<decimal>(type: "numeric", nullable: false),
                    financial_ratios_score = table.Column<decimal>(type: "numeric", nullable: false),
                    product_features_score = table.Column<decimal>(type: "numeric", nullable: false),
                    claims_experience_score = table.Column<decimal>(type: "numeric", nullable: false),
                    brand_existence_score = table.Column<decimal>(type: "numeric", nullable: false),
                    solvency_ratio_score = table.Column<decimal>(type: "numeric", nullable: false),
                    pr_13M_by_nof_policies_score = table.Column<decimal>(type: "numeric", nullable: false),
                    pr_13M_by_annualized_premium_score = table.Column<decimal>(type: "numeric", nullable: false),
                    pr_61M_by_nof_policies_score = table.Column<decimal>(type: "numeric", nullable: false),
                    pr_61M_by_annualized_premium_score = table.Column<decimal>(type: "numeric", nullable: false),
                    commission_ratio_score = table.Column<decimal>(type: "numeric", nullable: false),
                    policy_duration_score = table.Column<decimal>(type: "numeric", nullable: false),
                    death_benefit_payout_option_score = table.Column<decimal>(type: "numeric", nullable: false),
                    premium_payment_mode_score = table.Column<decimal>(type: "numeric", nullable: false),
                    premium_payment_frequency_score = table.Column<decimal>(type: "numeric", nullable: false),
                    max_maturity_age_score = table.Column<decimal>(type: "numeric", nullable: false),
                    rider_type_score = table.Column<decimal>(type: "numeric", nullable: false),
                    nof_diseases_covered_critical_illness_score = table.Column<decimal>(type: "numeric", nullable: false),
                    max_age_cover_ci_score = table.Column<decimal>(type: "numeric", nullable: false),
                    max_age_cover_for_accidental_disability_score = table.Column<decimal>(type: "numeric", nullable: false),
                    csr_value_of_claims_score = table.Column<decimal>(type: "numeric", nullable: false),
                    csr_nof_policies_score = table.Column<decimal>(type: "numeric", nullable: false),
                    nof_claims_complaints_per_10000_score = table.Column<decimal>(type: "numeric", nullable: false),
                    aoc_avg_num_and_amt_score = table.Column<decimal>(type: "numeric", nullable: false),
                    pricing = table.Column<string>(type: "text", nullable: false),
                    product_features = table.Column<string>(type: "json", nullable: true),
                    pros = table.Column<string>(type: "jsonb", nullable: true),
                    cons = table.Column<string>(type: "jsonb", nullable: true),
                    ti_about_insurer = table.Column<string>(type: "json", nullable: true),
                    sequence = table.Column<int>(type: "integer", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ti_output", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ti_product_feature",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    min_score = table.Column<decimal>(type: "numeric", nullable: false),
                    max_score = table.Column<decimal>(type: "numeric", nullable: false),
                    pricing = table.Column<string>(type: "text", nullable: false),
                    policy_duration = table.Column<string>(type: "text", nullable: true),
                    claim_payout = table.Column<string>(type: "text", nullable: true),
                    premium_payout_mode = table.Column<string[]>(type: "text[]", nullable: true),
                    premium_payout_frequency = table.Column<string[]>(type: "text[]", nullable: true),
                    max_maturity_age = table.Column<string>(type: "text", nullable: true),
                    solvency_ratio = table.Column<string>(type: "text", nullable: true),
                    rider_type = table.Column<string>(type: "text", nullable: true),
                    claim_settled = table.Column<string>(type: "text", nullable: false),
                    nof_claims_registered_per_10000 = table.Column<string>(type: "text", nullable: false),
                    ageing_of_claim = table.Column<string>(type: "text", nullable: false),
                    pr_13M_by_annualized_premium = table.Column<string>(type: "text", nullable: false),
                    pr_13M_by_no_of_policies = table.Column<string>(type: "text", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ti_product_feature", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ti_rationale",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    policy_duration_score = table.Column<decimal>(type: "numeric", nullable: false),
                    premium_payment_option_score = table.Column<decimal>(type: "numeric", nullable: false),
                    premium_payment_frequency_score = table.Column<decimal>(type: "numeric", nullable: false),
                    maximum_maturity_age_score = table.Column<decimal>(type: "numeric", nullable: false),
                    rider_type_score = table.Column<decimal>(type: "numeric", nullable: false),
                    max_age_cover_ci_score = table.Column<decimal>(type: "numeric", nullable: false),
                    max_age_cover_accidental_disability_score = table.Column<decimal>(type: "numeric", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ti_rationale", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ti_unique_sentence",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    logo_url = table.Column<string>(type: "text", nullable: false),
                    max_maturity_age = table.Column<string>(type: "text", nullable: false),
                    premium_payment_mode = table.Column<string>(type: "text", nullable: false),
                    premium_payment_frequency = table.Column<string>(type: "text", nullable: false),
                    death_benefit_payout_option = table.Column<string>(type: "text", nullable: false),
                    solvency_ratio = table.Column<string>(type: "text", nullable: false),
                    pr_13M_by_nof_policies = table.Column<string>(type: "text", nullable: false),
                    pr_61M_by_nof_policies = table.Column<string>(type: "text", nullable: false),
                    commission_ratio = table.Column<string>(type: "text", nullable: false),
                    csr_value_of_claims = table.Column<string>(type: "text", nullable: false),
                    csr_nof_policies = table.Column<string>(type: "text", nullable: false),
                    nof_claims_complaints_per_10000 = table.Column<string>(type: "text", nullable: false),
                    aoc_avg_num_and_amt = table.Column<string>(type: "text", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ti_unique_sentence", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "weightage",
                schema: "insurance",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    weightage = table.Column<decimal>(type: "numeric", nullable: true),
                    parent_parameter_id = table.Column<long>(type: "bigint", nullable: true),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weightage", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "about_insurer",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "category",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "customer_profile");

            migrationBuilder.DropTable(
                name: "hi_claims_experience",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "hi_maintain_version",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "hi_mst",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "hi_output",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "hi_output_ff",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "hi_product_card",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "hi_standard_feature",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "insurance");

            migrationBuilder.DropTable(
                name: "insurance_policy_evaluation",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "ip_category",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "ipe_recommendation_summary",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "plan_type",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "pmwell_response");

            migrationBuilder.DropTable(
                name: "scenario_based_recommendation",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "ti_maintain_version",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "ti_mst",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "ti_output",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "ti_product_feature",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "ti_rationale",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "ti_unique_sentence",
                schema: "insurance");

            migrationBuilder.DropTable(
                name: "weightage",
                schema: "insurance");
        }
    }
}
