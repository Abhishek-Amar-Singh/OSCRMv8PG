
using DB.Models.LakeMaster.Customers;
using DB.Models.LakeMaster.Insurances;
using DB.Models.LakeMaster.PMWells;
using Microsoft.EntityFrameworkCore;
using Shared.Lib.Models;

namespace Data.Warehouse.PostgreSQL.LakeMaster.DAL
{
    public class LakeMasterDbContext : DbContext
    {
        public LakeMasterDbContext(DbContextOptions<LakeMasterDbContext> options) : base(options) { }

        public DbSet<Category> CategoryTbl { get; set; }
        public DbSet<CustomerProfile> CustomerProfileTbl { get; set; }
        public DbSet<CategoryIP> CategoryIPTbl { get; set; }
        public DbSet<Insurance> InsuranceTbl { get; set; }
        public DbSet<InsurancePolicyEvaluation> InsurancePolicyEvaluationTbl { get; set; }
        public DbSet<PlanType> PlanTypeTbl { get; set; }
        public DbSet<RecommendationSummary> RecommendationSummaryTbl { get; set; }
        public DbSet<ScenarioBasedRecommendation> ScenarioBasedRecommendationTbl { get; set; }
        public DbSet<MasterTI> MasterTITbl { get; set; }
        public DbSet<PMWellResponse> PMWellResponseTbl { get; set; }
        public DbSet<InsuranceCategory> InsuranceCategoryTbl { get; set; }
        public DbSet<InsuranceWeightage> InsuranceWeightageTbl { get; set; }
        public DbSet<ProductFeatureTI> ProductFeatureTITbl { get; set; }
        public DbSet<MaintainVersionTI> MaintainVersionTITbl { get; set; }
        public DbSet<UniqueSentenceTI> UniqueSentenceTITbl { get; set; }
        public DbSet<RationaleTI> RationaleTITbl { get; set; }
        public DbSet<OutputTI> OutputTITbl { get; set; }
        public DbSet<AboutInsurer> AboutInsurerTbl { get; set; }
        public DbSet<ClaimsExperienceHI> ClaimsExperienceHITbl { get; set; }
        public DbSet<MaintainVersionHI> MaintainVersionHITbl { get; set; }
        public DbSet<MasterHI> MasterHITbl { get; set; }
        public DbSet<ProductCardHI> ProductCardHITbl { get; set; }
        public DbSet<StandardFeatureHI> StandardFeatureHITbl { get; set; }
        public DbSet<OutputHI> OutputHITbl { get; set; }
        public DbSet<OutputFFHI> OutputFFHITbl { get; set; }
    }
}
