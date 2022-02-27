﻿// <auto-generated />
using System;
using ED.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ED.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220227174824_ModifyNameImage")]
    partial class ModifyNameImage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ED.domain.Category", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ED.domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateProd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("categoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("categoryId");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("ED.domain.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("ProductProvider", b =>
                {
                    b.Property<int>("productsProductId")
                        .HasColumnType("int");

                    b.Property<int>("providersId")
                        .HasColumnType("int");

                    b.HasKey("productsProductId", "providersId");

                    b.HasIndex("providersId");

                    b.ToTable("ProductProvider");
                });

            modelBuilder.Entity("ED.domain.Biological", b =>
                {
                    b.HasBaseType("ED.domain.Product");

                    b.Property<string>("Herbs")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Biological");
                });

            modelBuilder.Entity("ED.domain.Chemical", b =>
                {
                    b.HasBaseType("ED.domain.Product");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LabName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAdress")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Chemical");
                });

            modelBuilder.Entity("ED.domain.Product", b =>
                {
                    b.HasOne("ED.domain.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("categoryId");

                    b.Navigation("category");
                });

            modelBuilder.Entity("ProductProvider", b =>
                {
                    b.HasOne("ED.domain.Product", null)
                        .WithMany()
                        .HasForeignKey("productsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ED.domain.Provider", null)
                        .WithMany()
                        .HasForeignKey("providersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ED.domain.Category", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}
