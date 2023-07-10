using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace pk_loan_crud.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PK_LOAN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Company = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Year_No = table.Column<int>(type: "integer", nullable: false),
                    Month_No = table.Column<int>(type: "integer", nullable: false),
                    Loan_Type = table.Column<int>(type: "integer", nullable: false),
                    CV_Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Bank_Code = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Rate = table.Column<decimal>(type: "numeric(15,4)", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(15,4)", nullable: false),
                    Interest_amt = table.Column<decimal>(type: "numeric(15,4)", nullable: false),
                    Fr_amount = table.Column<decimal>(type: "numeric(15,4)", nullable: false),
                    Fr_interest_amt = table.Column<decimal>(type: "numeric(15,4)", nullable: false),
                    Currency_code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PK_LOAN", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PK_LOAN");
        }
    }
}
