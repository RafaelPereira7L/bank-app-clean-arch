using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBalanceColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "balance",
                table: "accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "balance",
                table: "accounts",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
