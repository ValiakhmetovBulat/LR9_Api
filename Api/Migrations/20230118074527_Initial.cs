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
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    shortname = table.Column<string>(name: "short_name", type: "text", nullable: true),
                    parentID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_parentID",
                        column: x => x.parentID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    shortname = table.Column<string>(name: "short_name", type: "text", nullable: false),
                    INN = table.Column<string>(type: "text", nullable: false),
                    KPP = table.Column<string>(type: "text", nullable: false),
                    OGRN = table.Column<string>(type: "text", nullable: false),
                    uradres = table.Column<string>(name: "ur_adres", type: "text", nullable: false),
                    rukovod = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: false),
                    rashetshet = table.Column<string>(name: "rashet_shet", type: "text", nullable: false),
                    korrshet = table.Column<string>(name: "korr_shet", type: "text", nullable: false),
                    BIK = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Karta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufactures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufactures", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Types_oplaty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    naim = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types_oplaty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
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
                    manufID = table.Column<int>(type: "integer", nullable: false),
                    veslista = table.Column<double>(name: "ves_lista", type: "double precision", nullable: false),
                    kollistvpachke = table.Column<int>(name: "kol_list_v_pachke", type: "integer", nullable: false),
                    categoryID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomshet = table.Column<int>(name: "nom_shet", type: "integer", nullable: false),
                    datesheta = table.Column<DateTime>(name: "date_sheta", type: "timestamp without time zone", nullable: false),
                    contractorID = table.Column<int>(type: "integer", nullable: true),
                    userID = table.Column<int>(type: "integer", nullable: false),
                    prim = table.Column<string>(type: "text", nullable: true),
                    iskorr = table.Column<bool>(name: "is_korr", type: "boolean", nullable: false),
                    oplachen = table.Column<bool>(type: "boolean", nullable: false),
                    dateoplaty = table.Column<DateTime>(name: "date_oplaty", type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Shets_Contractors_contractorID",
                        column: x => x.contractorID,
                        principalTable: "Contractors",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Shets_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sklad_prihods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomprih = table.Column<int>(name: "nom_prih", type: "integer", nullable: false),
                    dateprih = table.Column<DateTime>(name: "date_prih", type: "timestamp without time zone", nullable: false),
                    contractorID = table.Column<int>(type: "integer", nullable: true),
                    transportotpost = table.Column<bool>(name: "transport_ot_post", type: "boolean", nullable: true),
                    userID = table.Column<int>(type: "integer", nullable: false),
                    iskorr = table.Column<bool>(name: "is_korr", type: "boolean", nullable: true),
                    isinsklad = table.Column<bool>(name: "is_in_sklad", type: "boolean", nullable: false),
                    delivcost = table.Column<double>(name: "deliv_cost", type: "double precision", nullable: true),
                    doprash = table.Column<double>(name: "dop_rash", type: "double precision", nullable: true),
                    prim = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sklad_prihods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sklad_prihods_Contractors_contractorID",
                        column: x => x.contractorID,
                        principalTable: "Contractors",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Sklad_prihods_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productID = table.Column<int>(type: "integer", nullable: false),
                    pricenal = table.Column<double>(name: "price_nal", type: "double precision", nullable: false),
                    pricebeznal = table.Column<double>(name: "price_beznal", type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prices_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shet_prods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    shetID = table.Column<int>(type: "integer", nullable: false),
                    productID = table.Column<int>(type: "integer", nullable: false),
                    count = table.Column<double>(type: "double precision", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shet_prods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Shet_prods_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shet_prods_Shets_shetID",
                        column: x => x.shetID,
                        principalTable: "Shets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sklad_rashods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomrash = table.Column<int>(name: "nom_rash", type: "integer", nullable: false),
                    daterash = table.Column<DateTime>(name: "date_rash", type: "timestamp without time zone", nullable: false),
                    dateotgruzki = table.Column<DateTime>(name: "date_otgruzki", type: "timestamp without time zone", nullable: true),
                    datesozdania = table.Column<DateTime>(name: "date_sozdania", type: "timestamp without time zone", nullable: false),
                    userID = table.Column<int>(type: "integer", nullable: false),
                    prim = table.Column<string>(type: "text", nullable: true),
                    shetID = table.Column<int>(type: "integer", nullable: true),
                    otgruzheno = table.Column<bool>(type: "boolean", nullable: false),
                    oplacheno = table.Column<bool>(type: "boolean", nullable: false),
                    phonecustomer = table.Column<string>(name: "phone_customer", type: "text", nullable: true),
                    namecustomer = table.Column<string>(name: "name_customer", type: "text", nullable: true),
                    typeoplatyID = table.Column<int>(name: "type_oplatyID", type: "integer", nullable: false),
                    dateoplaty = table.Column<DateTime>(name: "date_oplaty", type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sklad_rashods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sklad_rashods_Shets_shetID",
                        column: x => x.shetID,
                        principalTable: "Shets",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Sklad_rashods_Types_oplaty_type_oplatyID",
                        column: x => x.typeoplatyID,
                        principalTable: "Types_oplaty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sklad_rashods_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sklad_prihod_prods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    prihodID = table.Column<int>(type: "integer", nullable: false),
                    productID = table.Column<int>(type: "integer", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    pricewithdeliv = table.Column<double>(name: "price_with_deliv", type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sklad_prihod_prods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sklad_prihod_prods_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sklad_prihod_prods_Sklad_prihods_prihodID",
                        column: x => x.prihodID,
                        principalTable: "Sklad_prihods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sklad_dostavki",
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
                    table.PrimaryKey("PK_Sklad_dostavki", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sklad_dostavki_Karta_karta_id",
                        column: x => x.kartaid,
                        principalTable: "Karta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sklad_dostavki_Shets_shet",
                        column: x => x.shet,
                        principalTable: "Shets",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Sklad_dostavki_Sklad_rashods_sklad_rashod_id",
                        column: x => x.skladrashodid,
                        principalTable: "Sklad_rashods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sklad_dostavki_Types_oplaty_tip_opl_id",
                        column: x => x.tipoplid,
                        principalTable: "Types_oplaty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sklad_rashod_prods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rashodID = table.Column<int>(type: "integer", nullable: false),
                    productID = table.Column<int>(type: "integer", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sklad_rashod_prods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sklad_rashod_prods_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sklad_rashod_prods_Sklad_rashods_rashodID",
                        column: x => x.rashodID,
                        principalTable: "Sklad_rashods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_parentID",
                table: "Categories",
                column: "parentID");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_productID",
                table: "Prices",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryID",
                table: "Products",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Shet_prods_productID",
                table: "Shet_prods",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_Shet_prods_shetID",
                table: "Shet_prods",
                column: "shetID");

            migrationBuilder.CreateIndex(
                name: "IX_Shets_contractorID",
                table: "Shets",
                column: "contractorID");

            migrationBuilder.CreateIndex(
                name: "IX_Shets_userID",
                table: "Shets",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_dostavki_karta_id",
                table: "Sklad_dostavki",
                column: "karta_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_dostavki_shet",
                table: "Sklad_dostavki",
                column: "shet");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_dostavki_sklad_rashod_id",
                table: "Sklad_dostavki",
                column: "sklad_rashod_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_dostavki_tip_opl_id",
                table: "Sklad_dostavki",
                column: "tip_opl_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_prihod_prods_prihodID",
                table: "Sklad_prihod_prods",
                column: "prihodID");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_prihod_prods_productID",
                table: "Sklad_prihod_prods",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_prihods_contractorID",
                table: "Sklad_prihods",
                column: "contractorID");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_prihods_userID",
                table: "Sklad_prihods",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_rashod_prods_productID",
                table: "Sklad_rashod_prods",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_rashod_prods_rashodID",
                table: "Sklad_rashod_prods",
                column: "rashodID");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_rashods_shetID",
                table: "Sklad_rashods",
                column: "shetID");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_rashods_type_oplatyID",
                table: "Sklad_rashods",
                column: "type_oplatyID");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_rashods_userID",
                table: "Sklad_rashods",
                column: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manufactures");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Shet_prods");

            migrationBuilder.DropTable(
                name: "Sklad_dostavki");

            migrationBuilder.DropTable(
                name: "Sklad_prihod_prods");

            migrationBuilder.DropTable(
                name: "Sklad_rashod_prods");

            migrationBuilder.DropTable(
                name: "Karta");

            migrationBuilder.DropTable(
                name: "Sklad_prihods");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sklad_rashods");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Shets");

            migrationBuilder.DropTable(
                name: "Types_oplaty");

            migrationBuilder.DropTable(
                name: "Contractors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
