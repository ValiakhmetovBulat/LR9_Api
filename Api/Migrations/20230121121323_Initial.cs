using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    shortname = table.Column<string>(name: "short_name", type: "text", nullable: true),
                    parentid = table.Column<int>(name: "parent_id", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_categories_categories_parent_id",
                        column: x => x.parentid,
                        principalTable: "categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "contractors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    shortname = table.Column<string>(name: "short_name", type: "text", nullable: false),
                    inn = table.Column<string>(type: "text", nullable: false),
                    kpp = table.Column<string>(type: "text", nullable: false),
                    ogrn = table.Column<string>(type: "text", nullable: false),
                    uradres = table.Column<string>(name: "ur_adres", type: "text", nullable: false),
                    rukovod = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    rashetshet = table.Column<string>(name: "rashet_shet", type: "text", nullable: false),
                    korrshet = table.Column<string>(name: "korr_shet", type: "text", nullable: false),
                    bik = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contractors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "karta",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_karta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "manufactures",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_manufactures", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "types_oplaty",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    naim = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_types_oplaty", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    surname = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    papaname = table.Column<string>(type: "text", nullable: true),
                    login = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    naim = table.Column<string>(type: "text", nullable: false),
                    dlina = table.Column<double>(type: "double precision", nullable: false),
                    shir = table.Column<double>(type: "double precision", nullable: false),
                    tol = table.Column<double>(type: "double precision", nullable: false),
                    nazn = table.Column<string>(type: "text", nullable: true),
                    sort = table.Column<string>(type: "text", nullable: true),
                    dekor = table.Column<string>(type: "text", nullable: true),
                    zvet = table.Column<string>(type: "text", nullable: true),
                    material = table.Column<string>(type: "text", nullable: true),
                    manufid = table.Column<int>(name: "manuf_id", type: "integer", nullable: true),
                    veslista = table.Column<double>(name: "ves_lista", type: "double precision", nullable: false),
                    kollistvpachke = table.Column<int>(name: "kol_list_v_pachke", type: "integer", nullable: false),
                    categoryid = table.Column<int>(name: "category_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_categories_category_id",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomshet = table.Column<int>(name: "nom_shet", type: "integer", nullable: false),
                    datesheta = table.Column<DateTime>(name: "date_sheta", type: "timestamp without time zone", nullable: false),
                    contractorid = table.Column<int>(name: "contractor_id", type: "integer", nullable: true),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    prim = table.Column<string>(type: "text", nullable: true),
                    iskorr = table.Column<bool>(name: "is_korr", type: "boolean", nullable: false),
                    oplachen = table.Column<bool>(type: "boolean", nullable: false),
                    dateoplaty = table.Column<DateTime>(name: "date_oplaty", type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shets", x => x.id);
                    table.ForeignKey(
                        name: "fk_shets_contractors_contractor_id",
                        column: x => x.contractorid,
                        principalTable: "contractors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_shets_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sklad_prihods",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomprih = table.Column<int>(name: "nom_prih", type: "integer", nullable: false),
                    dateprih = table.Column<DateTime>(name: "date_prih", type: "timestamp without time zone", nullable: false),
                    contractorid = table.Column<int>(name: "contractor_id", type: "integer", nullable: true),
                    transportotpost = table.Column<bool>(name: "transport_ot_post", type: "boolean", nullable: true),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    iskorr = table.Column<bool>(name: "is_korr", type: "boolean", nullable: true),
                    isinsklad = table.Column<bool>(name: "is_in_sklad", type: "boolean", nullable: false),
                    delivcost = table.Column<double>(name: "deliv_cost", type: "double precision", nullable: true),
                    doprash = table.Column<double>(name: "dop_rash", type: "double precision", nullable: true),
                    prim = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sklad_prihods", x => x.id);
                    table.ForeignKey(
                        name: "fk_sklad_prihods_contractors_contractor_id",
                        column: x => x.contractorid,
                        principalTable: "contractors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_sklad_prihods_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productid = table.Column<int>(name: "product_id", type: "integer", nullable: false),
                    pricenal = table.Column<double>(name: "price_nal", type: "double precision", nullable: false),
                    pricebeznal = table.Column<double>(name: "price_beznal", type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_prices", x => x.id);
                    table.ForeignKey(
                        name: "fk_prices_products_product_id",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shet_prods",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    shetid = table.Column<int>(name: "shet_id", type: "integer", nullable: false),
                    productid = table.Column<int>(name: "product_id", type: "integer", nullable: false),
                    count = table.Column<double>(type: "double precision", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shet_prods", x => x.id);
                    table.ForeignKey(
                        name: "fk_shet_prods_products_product_id",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_shet_prods_shets_shet_id",
                        column: x => x.shetid,
                        principalTable: "shets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sklad_rashods",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomrash = table.Column<int>(name: "nom_rash", type: "integer", nullable: false),
                    daterash = table.Column<DateTime>(name: "date_rash", type: "timestamp without time zone", nullable: false),
                    dateotgruzki = table.Column<DateTime>(name: "date_otgruzki", type: "timestamp without time zone", nullable: true),
                    datesozdania = table.Column<DateTime>(name: "date_sozdania", type: "timestamp without time zone", nullable: false),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    prim = table.Column<string>(type: "text", nullable: true),
                    shetid = table.Column<int>(name: "shet_id", type: "integer", nullable: true),
                    otgruzheno = table.Column<bool>(type: "boolean", nullable: false),
                    oplacheno = table.Column<bool>(type: "boolean", nullable: false),
                    phonecustomer = table.Column<string>(name: "phone_customer", type: "text", nullable: true),
                    namecustomer = table.Column<string>(name: "name_customer", type: "text", nullable: true),
                    typeoplatyid = table.Column<int>(name: "type_oplaty_id", type: "integer", nullable: false),
                    dateoplaty = table.Column<DateTime>(name: "date_oplaty", type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sklad_rashods", x => x.id);
                    table.ForeignKey(
                        name: "fk_sklad_rashods_shets_shet_id",
                        column: x => x.shetid,
                        principalTable: "shets",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_sklad_rashods_types_oplaty_type_oplaty_id",
                        column: x => x.typeoplatyid,
                        principalTable: "types_oplaty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sklad_rashods_users_user_id",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sklad_prihod_prods",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    prihodid = table.Column<int>(name: "prihod_id", type: "integer", nullable: false),
                    productid = table.Column<int>(name: "product_id", type: "integer", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    pricewithdeliv = table.Column<double>(name: "price_with_deliv", type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sklad_prihod_prods", x => x.id);
                    table.ForeignKey(
                        name: "fk_sklad_prihod_prods_products_product_id",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sklad_prihod_prods_sklad_prihods_prihod_id",
                        column: x => x.prihodid,
                        principalTable: "sklad_prihods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sklad_dostavki",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    skladrashodid = table.Column<int>(name: "sklad_rashod_id", type: "integer", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    summa = table.Column<double>(type: "double precision", nullable: false),
                    tipoplid = table.Column<int>(name: "tip_opl_id", type: "integer", nullable: false),
                    oplklientom = table.Column<bool>(name: "opl_klientom", type: "boolean", nullable: false),
                    dataoplklientom = table.Column<DateTime>(name: "data_opl_klientom", type: "timestamp without time zone", nullable: true),
                    oplvoditelu = table.Column<bool>(name: "opl_voditelu", type: "boolean", nullable: false),
                    prim = table.Column<string>(type: "text", nullable: true),
                    provereno = table.Column<bool>(type: "boolean", nullable: false),
                    kartaid = table.Column<int>(name: "karta_id", type: "integer", nullable: true),
                    perevozid = table.Column<int>(name: "perevoz_id", type: "integer", nullable: true),
                    voditelid = table.Column<int>(name: "voditel_id", type: "integer", nullable: true),
                    oplnavigruz = table.Column<bool>(name: "opl_na_vigruz", type: "boolean", nullable: true),
                    shet = table.Column<int>(type: "integer", nullable: true),
                    datarash = table.Column<DateTime>(name: "data_rash", type: "timestamp without time zone", nullable: true),
                    platel = table.Column<decimal>(type: "numeric", nullable: true),
                    otpustil = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sklad_dostavki", x => x.id);
                    table.ForeignKey(
                        name: "fk_sklad_dostavki_karta_karta_id",
                        column: x => x.kartaid,
                        principalTable: "karta",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_sklad_dostavki_shets_shet",
                        column: x => x.shet,
                        principalTable: "shets",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_sklad_dostavki_sklad_rashods_sklad_rashod_id",
                        column: x => x.skladrashodid,
                        principalTable: "sklad_rashods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sklad_dostavki_types_oplaty_tip_opl_id",
                        column: x => x.tipoplid,
                        principalTable: "types_oplaty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sklad_rashod_prods",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rashodid = table.Column<int>(name: "rashod_id", type: "integer", nullable: false),
                    productid = table.Column<int>(name: "product_id", type: "integer", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sklad_rashod_prods", x => x.id);
                    table.ForeignKey(
                        name: "fk_sklad_rashod_prods_products_product_id",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sklad_rashod_prods_sklad_rashods_rashod_id",
                        column: x => x.rashodid,
                        principalTable: "sklad_rashods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_categories_parent_id",
                table: "categories",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_prices_product_id",
                table: "prices",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_products_category_id",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_shet_prods_product_id",
                table: "shet_prods",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_shet_prods_shet_id",
                table: "shet_prods",
                column: "shet_id");

            migrationBuilder.CreateIndex(
                name: "ix_shets_contractor_id",
                table: "shets",
                column: "contractor_id");

            migrationBuilder.CreateIndex(
                name: "ix_shets_user_id",
                table: "shets",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_sklad_dostavki_karta_id",
                table: "sklad_dostavki",
                column: "karta_id");

            migrationBuilder.CreateIndex(
                name: "ix_sklad_dostavki_shet",
                table: "sklad_dostavki",
                column: "shet");

            migrationBuilder.CreateIndex(
                name: "ix_sklad_dostavki_sklad_rashod_id",
                table: "sklad_dostavki",
                column: "sklad_rashod_id");

            migrationBuilder.CreateIndex(
                name: "ix_sklad_dostavki_tip_opl_id",
                table: "sklad_dostavki",
                column: "tip_opl_id");

            migrationBuilder.CreateIndex(
                name: "ix_sklad_prihod_prods_prihod_id",
                table: "sklad_prihod_prods",
                column: "prihod_id");

            migrationBuilder.CreateIndex(
                name: "ix_sklad_prihod_prods_product_id",
                table: "sklad_prihod_prods",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_sklad_prihods_contractor_id",
                table: "sklad_prihods",
                column: "contractor_id");

            migrationBuilder.CreateIndex(
                name: "ix_sklad_prihods_user_id",
                table: "sklad_prihods",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_sklad_rashod_prods_product_id",
                table: "sklad_rashod_prods",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_sklad_rashod_prods_rashod_id",
                table: "sklad_rashod_prods",
                column: "rashod_id");

            migrationBuilder.CreateIndex(
                name: "ix_sklad_rashods_shet_id",
                table: "sklad_rashods",
                column: "shet_id");

            migrationBuilder.CreateIndex(
                name: "ix_sklad_rashods_type_oplaty_id",
                table: "sklad_rashods",
                column: "type_oplaty_id");

            migrationBuilder.CreateIndex(
                name: "ix_sklad_rashods_user_id",
                table: "sklad_rashods",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "manufactures");

            migrationBuilder.DropTable(
                name: "prices");

            migrationBuilder.DropTable(
                name: "shet_prods");

            migrationBuilder.DropTable(
                name: "sklad_dostavki");

            migrationBuilder.DropTable(
                name: "sklad_prihod_prods");

            migrationBuilder.DropTable(
                name: "sklad_rashod_prods");

            migrationBuilder.DropTable(
                name: "karta");

            migrationBuilder.DropTable(
                name: "sklad_prihods");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "sklad_rashods");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "shets");

            migrationBuilder.DropTable(
                name: "types_oplaty");

            migrationBuilder.DropTable(
                name: "contractors");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
