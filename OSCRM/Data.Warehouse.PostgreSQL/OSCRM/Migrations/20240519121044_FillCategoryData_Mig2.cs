using Microsoft.EntityFrameworkCore.Migrations;
using Shared.Lib.Models;

#nullable disable

namespace Data.Warehouse.PostgreSQL.OSCRM.Migrations
{
    /// <inheritdoc />
    public partial class FillCategoryData_Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var is_active = true;

            migrationBuilder.InsertData(
                table: "category",
                columns: new string[]
                {
                    nameof(Category.id),
                    nameof(Category.name),
                    nameof(Category.parent_category_id),
                    nameof(Category.weightage),
                    nameof(Category.guidance),
                    nameof(Category.is_active),
                    nameof(Category.prescripton)
                },
                values: new object[,]
                {
                    {1, "City", null, null, null, is_active, null},
                    {2, "Profession", null, null, null, is_active, null},
                    {3, "Builder", 2, null, null, is_active, "A builder profession involves constructing and renovating structures, interpreting blueprints, and managing construction projects."},
                    {4, "Chartered Accountant", 2, null, null, is_active, "A Chartered Accountant is a financial professional who provides accounting, auditing, tax, and advisory services to individuals, businesses, and organizations, ensuring compliance with financial regulations and optimizing financial performance."},
                    {5, "DSA/DST", 2, null, null, is_active, "A DSA/DST (Data Structures and Algorithms/Data Science and Technology) professional is someone who leverages expertise in both traditional computer science concepts such as data structures and algorithms, as well as modern data science techniques and technologies, to solve complex problems related to data manipulation, analysis, and interpretation, spanning various domains such as software engineering, research, finance, healthcare, and more."},
                    {6, "Ex-banker", 2, null, null, is_active, "An ex-banker is someone who previously worked in the banking industry but has since transitioned out of that career path, often to pursue opportunities in other fields or industries."},
                    {7, "Financial Analyst", 2, null, null, is_active, "A financial analyst is a professional who assesses the financial performance of companies and industries, analyzes data, prepares reports, and makes recommendations to aid in decision-making regarding investments, budgeting, and other financial matters."},
                    {8, "Financial Consultant", 2, null, null, is_active, "A financial consultant is a professional who provides expert advice and guidance to individuals, businesses, or organizations on various aspects of finance, including investments, retirement planning, insurance, tax strategies, and overall financial management, tailored to their specific goals and circumstances."},
                    {9, "Freelancer", 2, null, null, is_active, "A freelancer is a self-employed individual who offers their services to clients on a contract basis, typically in fields such as writing, design, programming, consulting, or other specialized areas. They have the flexibility to work with multiple clients simultaneously and often operate remotely, managing their own schedules and projects."},
                    {10, "Insurance Advisor", 2, null, null, is_active, "An insurance advisor assesses and recommends insurance policies to mitigate financial risks for individuals and businesses."},
                    {11, "Loan Agent", 2, null, null, is_active, "A loan agent assists individuals or businesses in securing loans by providing guidance, facilitating the application process, and connecting borrowers with lenders."},
                    {12, "Mutual Fund Agent", 2, null, null, is_active, "A mutual fund agent assists investors in selecting and managing mutual fund investments, providing guidance on fund selection, portfolio diversification, and investment strategies."},
                    {13, "Real Estate Agent/Broker", 2, null, null, is_active, "A real estate agent/broker facilitates property transactions, representing buyers or sellers in negotiating deals, arranging viewings, and guiding clients through the sales process."},
                    {14, "Tax Consultant", 2, null, null, is_active, "A tax consultant advises individuals or businesses on tax-related matters, including compliance with tax laws, maximizing deductions, and minimizing tax liabilities, to ensure financial efficiency and regulatory compliance."},
                    {15, "Others", 2, null, null, is_active, null},
                    {16, "Mumbai", 1, null, null, is_active, "City of Dreams"},
                    {17, "Kashi", 1, null, null, is_active, "Kashi is older than history, older than tradition, older even than legend and looks twice as old as all of them put together"},
                    {18, "Bangalore", 1, null, null, is_active, "Silicon Valley of India"}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
