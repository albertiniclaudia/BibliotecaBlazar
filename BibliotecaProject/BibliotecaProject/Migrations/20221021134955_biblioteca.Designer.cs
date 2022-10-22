﻿// <auto-generated />
using System;
using BibliotecaProject.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotecaProject.Migrations
{
    [DbContext(typeof(BibliotecaDbContext))]
    [Migration("20221021134955_biblioteca")]
    partial class biblioteca
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BibliotecaProject.Models.Book", b =>
                {
                    b.Property<Guid>("Id_book")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublishingHouse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfBooks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_book");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BibliotecaProject.Models.IdentityCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Emissary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ID_user")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ID_user");

                    b.ToTable("IdentityCards");
                });

            modelBuilder.Entity("BibliotecaProject.Models.Loan", b =>
                {
                    b.Property<Guid>("Id_loan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_Book")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_user")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RentalEndData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentalStartData")
                        .HasColumnType("datetime2");

                    b.HasKey("Id_loan");

                    b.HasIndex("ID_Book");

                    b.HasIndex("ID_user");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("BibliotecaProject.Models.LoanQueue", b =>
                {
                    b.Property<Guid>("Id_loanQueue")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ID_book")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_user")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id_loanQueue");

                    b.HasIndex("ID_book");

                    b.HasIndex("ID_user");

                    b.ToTable("LoanQueues");
                });

            modelBuilder.Entity("BibliotecaProject.Models.Parent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_user")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ID_user");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("BibliotecaProject.Models.PositionBook", b =>
                {
                    b.Property<Guid>("Id_positionBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_book")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rack")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shelf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_positionBook");

                    b.HasIndex("ID_book");

                    b.ToTable("PositionBooks");
                });

            modelBuilder.Entity("BibliotecaProject.Models.PurchaseQueue", b =>
                {
                    b.Property<Guid>("Id_purchaseQueue")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ID_user")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublishingHouse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_purchaseQueue");

                    b.HasIndex("ID_user");

                    b.ToTable("PurchaseQueues");
                });

            modelBuilder.Entity("BibliotecaProject.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FiscalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentialAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BibliotecaProject.Models.IdentityCard", b =>
                {
                    b.HasOne("BibliotecaProject.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("ID_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BibliotecaProject.Models.Loan", b =>
                {
                    b.HasOne("BibliotecaProject.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("ID_Book")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaProject.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("ID_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BibliotecaProject.Models.LoanQueue", b =>
                {
                    b.HasOne("BibliotecaProject.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("ID_book")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaProject.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("ID_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BibliotecaProject.Models.Parent", b =>
                {
                    b.HasOne("BibliotecaProject.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("ID_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BibliotecaProject.Models.PositionBook", b =>
                {
                    b.HasOne("BibliotecaProject.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("ID_book")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BibliotecaProject.Models.PurchaseQueue", b =>
                {
                    b.HasOne("BibliotecaProject.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("ID_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
