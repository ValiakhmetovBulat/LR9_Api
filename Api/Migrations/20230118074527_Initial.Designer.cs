﻿// <auto-generated />
using System;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20230118074527_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int?>("parentID")
                        .HasColumnType("integer");

                    b.Property<string>("short_name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("parentID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Api.Models.Contractor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("BIK")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("INN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KPP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OGRN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("korr_shet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<string>("rashet_shet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("rukovod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("short_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ur_adres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("Api.Models.Karta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Karta");
                });

            modelBuilder.Entity("Api.Models.Manufacture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Manufactures");
                });

            modelBuilder.Entity("Api.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("categoryID")
                        .HasColumnType("integer");

                    b.Property<string>("dekor")
                        .HasColumnType("text");

                    b.Property<double>("dlina")
                        .HasColumnType("double precision");

                    b.Property<int>("kol_list_v_pachke")
                        .HasColumnType("integer");

                    b.Property<int>("manufID")
                        .HasColumnType("integer");

                    b.Property<string>("material")
                        .HasColumnType("text");

                    b.Property<string>("naim")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nazn")
                        .HasColumnType("text");

                    b.Property<double>("shir")
                        .HasColumnType("double precision");

                    b.Property<string>("sort")
                        .HasColumnType("text");

                    b.Property<double>("tol")
                        .HasColumnType("double precision");

                    b.Property<double>("ves_lista")
                        .HasColumnType("double precision");

                    b.Property<string>("zvet")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("categoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Api.Models.Shet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int?>("contractorID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("date_oplaty")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("date_sheta")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("is_korr")
                        .HasColumnType("boolean");

                    b.Property<int>("nom_shet")
                        .HasColumnType("integer");

                    b.Property<bool>("oplachen")
                        .HasColumnType("boolean");

                    b.Property<string>("prim")
                        .HasColumnType("text");

                    b.Property<int>("userID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("contractorID");

                    b.HasIndex("userID");

                    b.ToTable("Shets");
                });

            modelBuilder.Entity("Api.Models.Shet_prods", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<double>("count")
                        .HasColumnType("double precision");

                    b.Property<double>("price")
                        .HasColumnType("double precision");

                    b.Property<int>("productID")
                        .HasColumnType("integer");

                    b.Property<int>("shetID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("productID");

                    b.HasIndex("shetID");

                    b.ToTable("Shet_prods");
                });

            modelBuilder.Entity("Api.Models.Sklad.Price", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<double>("price_beznal")
                        .HasColumnType("double precision");

                    b.Property<double>("price_nal")
                        .HasColumnType("double precision");

                    b.Property<int>("productID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("productID");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("Api.Models.Sklad.Sklad_prihod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int?>("contractorID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("date_prih")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double?>("deliv_cost")
                        .HasColumnType("double precision");

                    b.Property<double?>("dop_rash")
                        .HasColumnType("double precision");

                    b.Property<bool>("is_in_sklad")
                        .HasColumnType("boolean");

                    b.Property<bool?>("is_korr")
                        .HasColumnType("boolean");

                    b.Property<int>("nom_prih")
                        .HasColumnType("integer");

                    b.Property<string>("prim")
                        .HasColumnType("text");

                    b.Property<bool?>("transport_ot_post")
                        .HasColumnType("boolean");

                    b.Property<int>("userID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("contractorID");

                    b.HasIndex("userID");

                    b.ToTable("Sklad_prihods");
                });

            modelBuilder.Entity("Api.Models.Sklad.Sklad_prihod_prods", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("count")
                        .HasColumnType("integer");

                    b.Property<double>("price")
                        .HasColumnType("double precision");

                    b.Property<double>("price_with_deliv")
                        .HasColumnType("double precision");

                    b.Property<int>("prihodID")
                        .HasColumnType("integer");

                    b.Property<int>("productID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("prihodID");

                    b.HasIndex("productID");

                    b.ToTable("Sklad_prihod_prods");
                });

            modelBuilder.Entity("Api.Models.Sklad_dostavki", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<DateTime?>("data_opl_klientom")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("data_rash")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("karta_id")
                        .HasColumnType("integer");

                    b.Property<bool>("opl_klientom")
                        .HasColumnType("boolean");

                    b.Property<bool?>("opl_na_vigruz")
                        .HasColumnType("boolean");

                    b.Property<bool>("opl_voditelu")
                        .HasColumnType("boolean");

                    b.Property<string>("otpustil")
                        .HasColumnType("text");

                    b.Property<int?>("perevoz_id")
                        .HasColumnType("integer");

                    b.Property<decimal?>("platel")
                        .HasColumnType("numeric");

                    b.Property<string>("prim")
                        .HasColumnType("text");

                    b.Property<bool>("provereno")
                        .HasColumnType("boolean");

                    b.Property<int?>("shet")
                        .HasColumnType("integer");

                    b.Property<int>("sklad_rashod_id")
                        .HasColumnType("integer");

                    b.Property<double>("summa")
                        .HasColumnType("double precision");

                    b.Property<int>("tip_opl_id")
                        .HasColumnType("integer");

                    b.Property<int?>("voditel_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("karta_id");

                    b.HasIndex("shet");

                    b.HasIndex("sklad_rashod_id");

                    b.HasIndex("tip_opl_id");

                    b.ToTable("Sklad_dostavki");
                });

            modelBuilder.Entity("Api.Models.Sklad_rashod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("date_oplaty")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("date_otgruzki")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("date_rash")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("date_sozdania")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("name_customer")
                        .HasColumnType("text");

                    b.Property<int>("nom_rash")
                        .HasColumnType("integer");

                    b.Property<bool>("oplacheno")
                        .HasColumnType("boolean");

                    b.Property<bool>("otgruzheno")
                        .HasColumnType("boolean");

                    b.Property<string>("phone_customer")
                        .HasColumnType("text");

                    b.Property<string>("prim")
                        .HasColumnType("text");

                    b.Property<int?>("shetID")
                        .HasColumnType("integer");

                    b.Property<int>("type_oplatyID")
                        .HasColumnType("integer");

                    b.Property<int>("userID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("shetID");

                    b.HasIndex("type_oplatyID");

                    b.HasIndex("userID");

                    b.ToTable("Sklad_rashods");
                });

            modelBuilder.Entity("Api.Models.Sklad_rashod_prods", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("count")
                        .HasColumnType("integer");

                    b.Property<double>("price")
                        .HasColumnType("double precision");

                    b.Property<int>("productID")
                        .HasColumnType("integer");

                    b.Property<int>("rashodID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("productID");

                    b.HasIndex("rashodID");

                    b.ToTable("Sklad_rashod_prods");
                });

            modelBuilder.Entity("Api.Models.Type_oplaty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("naim")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Types_oplaty");
                });

            modelBuilder.Entity("Api.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("papaname")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Api.Models.Category", b =>
                {
                    b.HasOne("Api.Models.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("parentID");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Api.Models.Product", b =>
                {
                    b.HasOne("Api.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Api.Models.Shet", b =>
                {
                    b.HasOne("Api.Models.Contractor", "Contractor")
                        .WithMany()
                        .HasForeignKey("contractorID");

                    b.HasOne("Api.Models.User", "Polz")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contractor");

                    b.Navigation("Polz");
                });

            modelBuilder.Entity("Api.Models.Shet_prods", b =>
                {
                    b.HasOne("Api.Models.Product", "Tovar")
                        .WithMany()
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Shet", "Sheta")
                        .WithMany("Sheta_tov")
                        .HasForeignKey("shetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sheta");

                    b.Navigation("Tovar");
                });

            modelBuilder.Entity("Api.Models.Sklad.Price", b =>
                {
                    b.HasOne("Api.Models.Product", "Tovar")
                        .WithMany()
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tovar");
                });

            modelBuilder.Entity("Api.Models.Sklad.Sklad_prihod", b =>
                {
                    b.HasOne("Api.Models.Contractor", "Contractor")
                        .WithMany()
                        .HasForeignKey("contractorID");

                    b.HasOne("Api.Models.User", "Polz")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contractor");

                    b.Navigation("Polz");
                });

            modelBuilder.Entity("Api.Models.Sklad.Sklad_prihod_prods", b =>
                {
                    b.HasOne("Api.Models.Sklad.Sklad_prihod", "Sklad_prihod")
                        .WithMany("Sklad_prihod_tov")
                        .HasForeignKey("prihodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Product", "Tovar")
                        .WithMany()
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sklad_prihod");

                    b.Navigation("Tovar");
                });

            modelBuilder.Entity("Api.Models.Sklad_dostavki", b =>
                {
                    b.HasOne("Api.Models.Karta", "Karta")
                        .WithMany()
                        .HasForeignKey("karta_id");

                    b.HasOne("Api.Models.Shet", "Sheta")
                        .WithMany()
                        .HasForeignKey("shet");

                    b.HasOne("Api.Models.Sklad_rashod", "Sklad_rashod")
                        .WithMany("Sklad_dostavki")
                        .HasForeignKey("sklad_rashod_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Type_oplaty", "Spr_oplat_sklad")
                        .WithMany()
                        .HasForeignKey("tip_opl_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Karta");

                    b.Navigation("Sheta");

                    b.Navigation("Sklad_rashod");

                    b.Navigation("Spr_oplat_sklad");
                });

            modelBuilder.Entity("Api.Models.Sklad_rashod", b =>
                {
                    b.HasOne("Api.Models.Shet", "Shet")
                        .WithMany()
                        .HasForeignKey("shetID");

                    b.HasOne("Api.Models.Type_oplaty", "Spr_oplat_sklad")
                        .WithMany()
                        .HasForeignKey("type_oplatyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.User", "Polz")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Polz");

                    b.Navigation("Shet");

                    b.Navigation("Spr_oplat_sklad");
                });

            modelBuilder.Entity("Api.Models.Sklad_rashod_prods", b =>
                {
                    b.HasOne("Api.Models.Product", "Tovar")
                        .WithMany()
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Sklad_rashod", "Sklad_rashod")
                        .WithMany("Sklad_rashod_tov")
                        .HasForeignKey("rashodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sklad_rashod");

                    b.Navigation("Tovar");
                });

            modelBuilder.Entity("Api.Models.Shet", b =>
                {
                    b.Navigation("Sheta_tov");
                });

            modelBuilder.Entity("Api.Models.Sklad.Sklad_prihod", b =>
                {
                    b.Navigation("Sklad_prihod_tov");
                });

            modelBuilder.Entity("Api.Models.Sklad_rashod", b =>
                {
                    b.Navigation("Sklad_dostavki");

                    b.Navigation("Sklad_rashod_tov");
                });
#pragma warning restore 612, 618
        }
    }
}
