using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_transactions_accounts_receiver_account_id",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "fk_transactions_accounts_sender_account_id",
                table: "transactions");

            migrationBuilder.CreateIndex(
                name: "ix_accounts_account_number",
                table: "accounts",
                column: "account_number",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_transactions_accounts_receiver_account_id",
                table: "transactions",
                column: "receiver_account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_transactions_accounts_sender_account_id",
                table: "transactions",
                column: "sender_account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_transactions_accounts_receiver_account_id",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "fk_transactions_accounts_sender_account_id",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "ix_accounts_account_number",
                table: "accounts");

            migrationBuilder.AddForeignKey(
                name: "fk_transactions_accounts_receiver_account_id",
                table: "transactions",
                column: "receiver_account_id",
                principalTable: "accounts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_transactions_accounts_sender_account_id",
                table: "transactions",
                column: "sender_account_id",
                principalTable: "accounts",
                principalColumn: "id");
        }
    }
}
