using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Casename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_parentID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Products_productID",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_categoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Shet_prods_Products_productID",
                table: "Shet_prods");

            migrationBuilder.DropForeignKey(
                name: "FK_Shet_prods_Shets_shetID",
                table: "Shet_prods");

            migrationBuilder.DropForeignKey(
                name: "FK_Shets_Contractors_contractorID",
                table: "Shets");

            migrationBuilder.DropForeignKey(
                name: "FK_Shets_Users_userID",
                table: "Shets");

            migrationBuilder.DropForeignKey(
                name: "FK_Sklad_dostavki_Karta_karta_id",
                table: "Sklad_dostavki");

            migrationBuilder.DropForeignKey(
                name: "FK_Sklad_dostavki_Shets_shet",
                table: "Sklad_dostavki");

            migrationBuilder.DropForeignKey(
                name: "FK_Sklad_dostavki_Sklad_rashods_sklad_rashod_id",
                table: "Sklad_dostavki");

            migrationBuilder.DropForeignKey(
                name: "FK_Sklad_dostavki_Types_oplaty_tip_opl_id",
                table: "Sklad_dostavki");

            migrationBuilder.DropForeignKey(
                name: "FK_Sklad_prihod_prods_Products_productID",
                table: "Sklad_prihod_prods");

            migrationBuilder.DropForeignKey(
                name: "FK_Sklad_prihod_prods_Sklad_prihods_prihodID",
                table: "Sklad_prihod_prods");

            migrationBuilder.DropForeignKey(
                name: "FK_Sklad_prihods_Contractors_contractorID",
                table: "Sklad_prihods");

            migrationBuilder.DropForeignKey(
                name: "FK_Sklad_prihods_Users_userID",
                table: "Sklad_prihods");

            migrationBuilder.DropForeignKey(
                name: "FK_Sklad_rashod_prods_Products_productID",
                table: "Sklad_rashod_prods");

            migrationBuilder.DropForeignKey(
                name: "FK_Sklad_rashod_prods_Sklad_rashods_rashodID",
                table: "Sklad_rashod_prods");

            migrationBuilder.DropForeignKey(
                name: "FK_Sklad_rashods_Shets_shetID",
                table: "Sklad_rashods");

            migrationBuilder.DropForeignKey(
                name: "FK_Sklad_rashods_Types_oplaty_type_oplatyID",
                table: "Sklad_rashods");

            migrationBuilder.DropForeignKey(
                name: "FK_Sklad_rashods_Users_userID",
                table: "Sklad_rashods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Types_oplaty",
                table: "Types_oplaty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sklad_rashods",
                table: "Sklad_rashods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sklad_rashod_prods",
                table: "Sklad_rashod_prods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sklad_prihods",
                table: "Sklad_prihods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sklad_prihod_prods",
                table: "Sklad_prihod_prods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sklad_dostavki",
                table: "Sklad_dostavki");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shets",
                table: "Shets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shet_prods",
                table: "Shet_prods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prices",
                table: "Prices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufactures",
                table: "Manufactures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Karta",
                table: "Karta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contractors",
                table: "Contractors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Types_oplaty",
                newName: "types_oplaty");

            migrationBuilder.RenameTable(
                name: "Sklad_rashods",
                newName: "sklad_rashods");

            migrationBuilder.RenameTable(
                name: "Sklad_rashod_prods",
                newName: "sklad_rashod_prods");

            migrationBuilder.RenameTable(
                name: "Sklad_prihods",
                newName: "sklad_prihods");

            migrationBuilder.RenameTable(
                name: "Sklad_prihod_prods",
                newName: "sklad_prihod_prods");

            migrationBuilder.RenameTable(
                name: "Sklad_dostavki",
                newName: "sklad_dostavki");

            migrationBuilder.RenameTable(
                name: "Shets",
                newName: "shets");

            migrationBuilder.RenameTable(
                name: "Shet_prods",
                newName: "shet_prods");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.RenameTable(
                name: "Prices",
                newName: "prices");

            migrationBuilder.RenameTable(
                name: "Manufactures",
                newName: "manufactures");

            migrationBuilder.RenameTable(
                name: "Karta",
                newName: "karta");

            migrationBuilder.RenameTable(
                name: "Contractors",
                newName: "contractors");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "types_oplaty",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "sklad_rashods",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "sklad_rashods",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "type_oplatyID",
                table: "sklad_rashods",
                newName: "type_oplaty_id");

            migrationBuilder.RenameColumn(
                name: "shetID",
                table: "sklad_rashods",
                newName: "shet_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sklad_rashods_userID",
                table: "sklad_rashods",
                newName: "ix_sklad_rashods_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sklad_rashods_type_oplatyID",
                table: "sklad_rashods",
                newName: "ix_sklad_rashods_type_oplaty_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sklad_rashods_shetID",
                table: "sklad_rashods",
                newName: "ix_sklad_rashods_shet_id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "sklad_rashod_prods",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "rashodID",
                table: "sklad_rashod_prods",
                newName: "rashod_id");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "sklad_rashod_prods",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sklad_rashod_prods_rashodID",
                table: "sklad_rashod_prods",
                newName: "ix_sklad_rashod_prods_rashod_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sklad_rashod_prods_productID",
                table: "sklad_rashod_prods",
                newName: "ix_sklad_rashod_prods_product_id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "sklad_prihods",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "sklad_prihods",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "contractorID",
                table: "sklad_prihods",
                newName: "contractor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sklad_prihods_userID",
                table: "sklad_prihods",
                newName: "ix_sklad_prihods_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sklad_prihods_contractorID",
                table: "sklad_prihods",
                newName: "ix_sklad_prihods_contractor_id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "sklad_prihod_prods",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "sklad_prihod_prods",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "prihodID",
                table: "sklad_prihod_prods",
                newName: "prihod_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sklad_prihod_prods_productID",
                table: "sklad_prihod_prods",
                newName: "ix_sklad_prihod_prods_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sklad_prihod_prods_prihodID",
                table: "sklad_prihod_prods",
                newName: "ix_sklad_prihod_prods_prihod_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sklad_dostavki_tip_opl_id",
                table: "sklad_dostavki",
                newName: "ix_sklad_dostavki_tip_opl_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sklad_dostavki_sklad_rashod_id",
                table: "sklad_dostavki",
                newName: "ix_sklad_dostavki_sklad_rashod_id");

            migrationBuilder.RenameIndex(
                name: "IX_Sklad_dostavki_shet",
                table: "sklad_dostavki",
                newName: "ix_sklad_dostavki_shet");

            migrationBuilder.RenameIndex(
                name: "IX_Sklad_dostavki_karta_id",
                table: "sklad_dostavki",
                newName: "ix_sklad_dostavki_karta_id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "shets",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "shets",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "contractorID",
                table: "shets",
                newName: "contractor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Shets_userID",
                table: "shets",
                newName: "ix_shets_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Shets_contractorID",
                table: "shets",
                newName: "ix_shets_contractor_id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "shet_prods",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "shetID",
                table: "shet_prods",
                newName: "shet_id");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "shet_prods",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Shet_prods_shetID",
                table: "shet_prods",
                newName: "ix_shet_prods_shet_id");

            migrationBuilder.RenameIndex(
                name: "IX_Shet_prods_productID",
                table: "shet_prods",
                newName: "ix_shet_prods_product_id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "manufID",
                table: "products",
                newName: "manuf_id");

            migrationBuilder.RenameColumn(
                name: "categoryID",
                table: "products",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_categoryID",
                table: "products",
                newName: "ix_products_category_id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "prices",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "prices",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Prices_productID",
                table: "prices",
                newName: "ix_prices_product_id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "manufactures",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "karta",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "OGRN",
                table: "contractors",
                newName: "ogrn");

            migrationBuilder.RenameColumn(
                name: "KPP",
                table: "contractors",
                newName: "kpp");

            migrationBuilder.RenameColumn(
                name: "INN",
                table: "contractors",
                newName: "inn");

            migrationBuilder.RenameColumn(
                name: "BIK",
                table: "contractors",
                newName: "bik");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "contractors",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "parentID",
                table: "categories",
                newName: "parent_id");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_parentID",
                table: "categories",
                newName: "ix_categories_parent_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_types_oplaty",
                table: "types_oplaty",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sklad_rashods",
                table: "sklad_rashods",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sklad_rashod_prods",
                table: "sklad_rashod_prods",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sklad_prihods",
                table: "sklad_prihods",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sklad_prihod_prods",
                table: "sklad_prihod_prods",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sklad_dostavki",
                table: "sklad_dostavki",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_shets",
                table: "shets",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_shet_prods",
                table: "shet_prods",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_products",
                table: "products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_prices",
                table: "prices",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_manufactures",
                table: "manufactures",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_karta",
                table: "karta",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_contractors",
                table: "contractors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_categories",
                table: "categories",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_categories_categories_parent_id",
                table: "categories",
                column: "parent_id",
                principalTable: "categories",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_prices_products_product_id",
                table: "prices",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_products_categories_category_id",
                table: "products",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_shet_prods_products_product_id",
                table: "shet_prods",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_shet_prods_shets_shet_id",
                table: "shet_prods",
                column: "shet_id",
                principalTable: "shets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_shets_contractors_contractor_id",
                table: "shets",
                column: "contractor_id",
                principalTable: "contractors",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_shets_users_user_id",
                table: "shets",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_dostavki_karta_karta_id",
                table: "sklad_dostavki",
                column: "karta_id",
                principalTable: "karta",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_dostavki_shets_shet",
                table: "sklad_dostavki",
                column: "shet",
                principalTable: "shets",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_dostavki_sklad_rashods_sklad_rashod_id",
                table: "sklad_dostavki",
                column: "sklad_rashod_id",
                principalTable: "sklad_rashods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_dostavki_types_oplaty_tip_opl_id",
                table: "sklad_dostavki",
                column: "tip_opl_id",
                principalTable: "types_oplaty",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_prihod_prods_products_product_id",
                table: "sklad_prihod_prods",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_prihod_prods_sklad_prihods_prihod_id",
                table: "sklad_prihod_prods",
                column: "prihod_id",
                principalTable: "sklad_prihods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_prihods_contractors_contractor_id",
                table: "sklad_prihods",
                column: "contractor_id",
                principalTable: "contractors",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_prihods_users_user_id",
                table: "sklad_prihods",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_rashod_prods_products_product_id",
                table: "sklad_rashod_prods",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_rashod_prods_sklad_rashods_rashod_id",
                table: "sklad_rashod_prods",
                column: "rashod_id",
                principalTable: "sklad_rashods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_rashods_shets_shet_id",
                table: "sklad_rashods",
                column: "shet_id",
                principalTable: "shets",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_rashods_types_oplaty_type_oplaty_id",
                table: "sklad_rashods",
                column: "type_oplaty_id",
                principalTable: "types_oplaty",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sklad_rashods_users_user_id",
                table: "sklad_rashods",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_categories_categories_parent_id",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "fk_prices_products_product_id",
                table: "prices");

            migrationBuilder.DropForeignKey(
                name: "fk_products_categories_category_id",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "fk_shet_prods_products_product_id",
                table: "shet_prods");

            migrationBuilder.DropForeignKey(
                name: "fk_shet_prods_shets_shet_id",
                table: "shet_prods");

            migrationBuilder.DropForeignKey(
                name: "fk_shets_contractors_contractor_id",
                table: "shets");

            migrationBuilder.DropForeignKey(
                name: "fk_shets_users_user_id",
                table: "shets");

            migrationBuilder.DropForeignKey(
                name: "fk_sklad_dostavki_karta_karta_id",
                table: "sklad_dostavki");

            migrationBuilder.DropForeignKey(
                name: "fk_sklad_dostavki_shets_shet",
                table: "sklad_dostavki");

            migrationBuilder.DropForeignKey(
                name: "fk_sklad_dostavki_sklad_rashods_sklad_rashod_id",
                table: "sklad_dostavki");

            migrationBuilder.DropForeignKey(
                name: "fk_sklad_dostavki_types_oplaty_tip_opl_id",
                table: "sklad_dostavki");

            migrationBuilder.DropForeignKey(
                name: "fk_sklad_prihod_prods_products_product_id",
                table: "sklad_prihod_prods");

            migrationBuilder.DropForeignKey(
                name: "fk_sklad_prihod_prods_sklad_prihods_prihod_id",
                table: "sklad_prihod_prods");

            migrationBuilder.DropForeignKey(
                name: "fk_sklad_prihods_contractors_contractor_id",
                table: "sklad_prihods");

            migrationBuilder.DropForeignKey(
                name: "fk_sklad_prihods_users_user_id",
                table: "sklad_prihods");

            migrationBuilder.DropForeignKey(
                name: "fk_sklad_rashod_prods_products_product_id",
                table: "sklad_rashod_prods");

            migrationBuilder.DropForeignKey(
                name: "fk_sklad_rashod_prods_sklad_rashods_rashod_id",
                table: "sklad_rashod_prods");

            migrationBuilder.DropForeignKey(
                name: "fk_sklad_rashods_shets_shet_id",
                table: "sklad_rashods");

            migrationBuilder.DropForeignKey(
                name: "fk_sklad_rashods_types_oplaty_type_oplaty_id",
                table: "sklad_rashods");

            migrationBuilder.DropForeignKey(
                name: "fk_sklad_rashods_users_user_id",
                table: "sklad_rashods");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_types_oplaty",
                table: "types_oplaty");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sklad_rashods",
                table: "sklad_rashods");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sklad_rashod_prods",
                table: "sklad_rashod_prods");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sklad_prihods",
                table: "sklad_prihods");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sklad_prihod_prods",
                table: "sklad_prihod_prods");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sklad_dostavki",
                table: "sklad_dostavki");

            migrationBuilder.DropPrimaryKey(
                name: "pk_shets",
                table: "shets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_shet_prods",
                table: "shet_prods");

            migrationBuilder.DropPrimaryKey(
                name: "pk_products",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "pk_prices",
                table: "prices");

            migrationBuilder.DropPrimaryKey(
                name: "pk_manufactures",
                table: "manufactures");

            migrationBuilder.DropPrimaryKey(
                name: "pk_karta",
                table: "karta");

            migrationBuilder.DropPrimaryKey(
                name: "pk_contractors",
                table: "contractors");

            migrationBuilder.DropPrimaryKey(
                name: "pk_categories",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "types_oplaty",
                newName: "Types_oplaty");

            migrationBuilder.RenameTable(
                name: "sklad_rashods",
                newName: "Sklad_rashods");

            migrationBuilder.RenameTable(
                name: "sklad_rashod_prods",
                newName: "Sklad_rashod_prods");

            migrationBuilder.RenameTable(
                name: "sklad_prihods",
                newName: "Sklad_prihods");

            migrationBuilder.RenameTable(
                name: "sklad_prihod_prods",
                newName: "Sklad_prihod_prods");

            migrationBuilder.RenameTable(
                name: "sklad_dostavki",
                newName: "Sklad_dostavki");

            migrationBuilder.RenameTable(
                name: "shets",
                newName: "Shets");

            migrationBuilder.RenameTable(
                name: "shet_prods",
                newName: "Shet_prods");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "prices",
                newName: "Prices");

            migrationBuilder.RenameTable(
                name: "manufactures",
                newName: "Manufactures");

            migrationBuilder.RenameTable(
                name: "karta",
                newName: "Karta");

            migrationBuilder.RenameTable(
                name: "contractors",
                newName: "Contractors");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Types_oplaty",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Sklad_rashods",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Sklad_rashods",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "type_oplaty_id",
                table: "Sklad_rashods",
                newName: "type_oplatyID");

            migrationBuilder.RenameColumn(
                name: "shet_id",
                table: "Sklad_rashods",
                newName: "shetID");

            migrationBuilder.RenameIndex(
                name: "ix_sklad_rashods_user_id",
                table: "Sklad_rashods",
                newName: "IX_Sklad_rashods_userID");

            migrationBuilder.RenameIndex(
                name: "ix_sklad_rashods_type_oplaty_id",
                table: "Sklad_rashods",
                newName: "IX_Sklad_rashods_type_oplatyID");

            migrationBuilder.RenameIndex(
                name: "ix_sklad_rashods_shet_id",
                table: "Sklad_rashods",
                newName: "IX_Sklad_rashods_shetID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Sklad_rashod_prods",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "rashod_id",
                table: "Sklad_rashod_prods",
                newName: "rashodID");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Sklad_rashod_prods",
                newName: "productID");

            migrationBuilder.RenameIndex(
                name: "ix_sklad_rashod_prods_rashod_id",
                table: "Sklad_rashod_prods",
                newName: "IX_Sklad_rashod_prods_rashodID");

            migrationBuilder.RenameIndex(
                name: "ix_sklad_rashod_prods_product_id",
                table: "Sklad_rashod_prods",
                newName: "IX_Sklad_rashod_prods_productID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Sklad_prihods",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Sklad_prihods",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "contractor_id",
                table: "Sklad_prihods",
                newName: "contractorID");

            migrationBuilder.RenameIndex(
                name: "ix_sklad_prihods_user_id",
                table: "Sklad_prihods",
                newName: "IX_Sklad_prihods_userID");

            migrationBuilder.RenameIndex(
                name: "ix_sklad_prihods_contractor_id",
                table: "Sklad_prihods",
                newName: "IX_Sklad_prihods_contractorID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Sklad_prihod_prods",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Sklad_prihod_prods",
                newName: "productID");

            migrationBuilder.RenameColumn(
                name: "prihod_id",
                table: "Sklad_prihod_prods",
                newName: "prihodID");

            migrationBuilder.RenameIndex(
                name: "ix_sklad_prihod_prods_product_id",
                table: "Sklad_prihod_prods",
                newName: "IX_Sklad_prihod_prods_productID");

            migrationBuilder.RenameIndex(
                name: "ix_sklad_prihod_prods_prihod_id",
                table: "Sklad_prihod_prods",
                newName: "IX_Sklad_prihod_prods_prihodID");

            migrationBuilder.RenameIndex(
                name: "ix_sklad_dostavki_tip_opl_id",
                table: "Sklad_dostavki",
                newName: "IX_Sklad_dostavki_tip_opl_id");

            migrationBuilder.RenameIndex(
                name: "ix_sklad_dostavki_sklad_rashod_id",
                table: "Sklad_dostavki",
                newName: "IX_Sklad_dostavki_sklad_rashod_id");

            migrationBuilder.RenameIndex(
                name: "ix_sklad_dostavki_shet",
                table: "Sklad_dostavki",
                newName: "IX_Sklad_dostavki_shet");

            migrationBuilder.RenameIndex(
                name: "ix_sklad_dostavki_karta_id",
                table: "Sklad_dostavki",
                newName: "IX_Sklad_dostavki_karta_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Shets",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Shets",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "contractor_id",
                table: "Shets",
                newName: "contractorID");

            migrationBuilder.RenameIndex(
                name: "ix_shets_user_id",
                table: "Shets",
                newName: "IX_Shets_userID");

            migrationBuilder.RenameIndex(
                name: "ix_shets_contractor_id",
                table: "Shets",
                newName: "IX_Shets_contractorID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Shet_prods",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "shet_id",
                table: "Shet_prods",
                newName: "shetID");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Shet_prods",
                newName: "productID");

            migrationBuilder.RenameIndex(
                name: "ix_shet_prods_shet_id",
                table: "Shet_prods",
                newName: "IX_Shet_prods_shetID");

            migrationBuilder.RenameIndex(
                name: "ix_shet_prods_product_id",
                table: "Shet_prods",
                newName: "IX_Shet_prods_productID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "manuf_id",
                table: "Products",
                newName: "manufID");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Products",
                newName: "categoryID");

            migrationBuilder.RenameIndex(
                name: "ix_products_category_id",
                table: "Products",
                newName: "IX_Products_categoryID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Prices",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Prices",
                newName: "productID");

            migrationBuilder.RenameIndex(
                name: "ix_prices_product_id",
                table: "Prices",
                newName: "IX_Prices_productID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Manufactures",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Karta",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ogrn",
                table: "Contractors",
                newName: "OGRN");

            migrationBuilder.RenameColumn(
                name: "kpp",
                table: "Contractors",
                newName: "KPP");

            migrationBuilder.RenameColumn(
                name: "inn",
                table: "Contractors",
                newName: "INN");

            migrationBuilder.RenameColumn(
                name: "bik",
                table: "Contractors",
                newName: "BIK");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Contractors",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "parent_id",
                table: "Categories",
                newName: "parentID");

            migrationBuilder.RenameIndex(
                name: "ix_categories_parent_id",
                table: "Categories",
                newName: "IX_Categories_parentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Types_oplaty",
                table: "Types_oplaty",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sklad_rashods",
                table: "Sklad_rashods",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sklad_rashod_prods",
                table: "Sklad_rashod_prods",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sklad_prihods",
                table: "Sklad_prihods",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sklad_prihod_prods",
                table: "Sklad_prihod_prods",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sklad_dostavki",
                table: "Sklad_dostavki",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shets",
                table: "Shets",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shet_prods",
                table: "Shet_prods",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prices",
                table: "Prices",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufactures",
                table: "Manufactures",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Karta",
                table: "Karta",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contractors",
                table: "Contractors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_parentID",
                table: "Categories",
                column: "parentID",
                principalTable: "Categories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Products_productID",
                table: "Prices",
                column: "productID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_categoryID",
                table: "Products",
                column: "categoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shet_prods_Products_productID",
                table: "Shet_prods",
                column: "productID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shet_prods_Shets_shetID",
                table: "Shet_prods",
                column: "shetID",
                principalTable: "Shets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shets_Contractors_contractorID",
                table: "Shets",
                column: "contractorID",
                principalTable: "Contractors",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shets_Users_userID",
                table: "Shets",
                column: "userID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sklad_dostavki_Karta_karta_id",
                table: "Sklad_dostavki",
                column: "karta_id",
                principalTable: "Karta",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sklad_dostavki_Shets_shet",
                table: "Sklad_dostavki",
                column: "shet",
                principalTable: "Shets",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sklad_dostavki_Sklad_rashods_sklad_rashod_id",
                table: "Sklad_dostavki",
                column: "sklad_rashod_id",
                principalTable: "Sklad_rashods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sklad_dostavki_Types_oplaty_tip_opl_id",
                table: "Sklad_dostavki",
                column: "tip_opl_id",
                principalTable: "Types_oplaty",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sklad_prihod_prods_Products_productID",
                table: "Sklad_prihod_prods",
                column: "productID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sklad_prihod_prods_Sklad_prihods_prihodID",
                table: "Sklad_prihod_prods",
                column: "prihodID",
                principalTable: "Sklad_prihods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sklad_prihods_Contractors_contractorID",
                table: "Sklad_prihods",
                column: "contractorID",
                principalTable: "Contractors",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sklad_prihods_Users_userID",
                table: "Sklad_prihods",
                column: "userID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sklad_rashod_prods_Products_productID",
                table: "Sklad_rashod_prods",
                column: "productID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sklad_rashod_prods_Sklad_rashods_rashodID",
                table: "Sklad_rashod_prods",
                column: "rashodID",
                principalTable: "Sklad_rashods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sklad_rashods_Shets_shetID",
                table: "Sklad_rashods",
                column: "shetID",
                principalTable: "Shets",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sklad_rashods_Types_oplaty_type_oplatyID",
                table: "Sklad_rashods",
                column: "type_oplatyID",
                principalTable: "Types_oplaty",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sklad_rashods_Users_userID",
                table: "Sklad_rashods",
                column: "userID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
