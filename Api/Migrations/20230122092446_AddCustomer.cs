using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name_customer",
                table: "sklad_rashods");

            migrationBuilder.DropColumn(
                name: "phone_customer",
                table: "sklad_rashods");

            migrationBuilder.AddColumn<int>(
                name: "customer_id",
                table: "sklad_rashods",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_sklad_rashods_customer_id",
                table: "sklad_rashods",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_rashods_users_customer_id",
                table: "sklad_rashods",
                column: "customer_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_sklad_rashods_users_customer_id",
                table: "sklad_rashods");

            migrationBuilder.DropIndex(
                name: "ix_sklad_rashods_customer_id",
                table: "sklad_rashods");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "sklad_rashods");

            migrationBuilder.AddColumn<string>(
                name: "name_customer",
                table: "sklad_rashods",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone_customer",
                table: "sklad_rashods",
                type: "text",
                nullable: true);
        }
    }
}
