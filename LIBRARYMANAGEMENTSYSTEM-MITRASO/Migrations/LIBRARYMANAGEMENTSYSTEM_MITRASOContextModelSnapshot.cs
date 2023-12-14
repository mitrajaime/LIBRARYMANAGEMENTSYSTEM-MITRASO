﻿// <auto-generated />
using System;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Migrations
{
    [DbContext(typeof(LIBRARYMANAGEMENTSYSTEM_MITRASOContext))]
    partial class LIBRARYMANAGEMENTSYSTEM_MITRASOContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.BookCategory", b =>
                {
                    b.Property<int>("BookCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookCategoryId"), 1L, 1);

                    b.Property<string>("BookCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookCategoryId");

                    b.ToTable("BookCategory");
                });

            modelBuilder.Entity("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.Books", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBorrowed")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("BookCategoryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.Borrower", b =>
                {
                    b.Property<int>("BorrowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BorrowerId"), 1L, 1);

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("StudentIdNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("BorrowerId");

                    b.ToTable("Borrower");
                });

            modelBuilder.Entity("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.BorrowingRecords", b =>
                {
                    b.Property<int>("BorrowingRecordsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BorrowingRecordsId"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("BorrowerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateBorrowed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasPenalty")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BorrowingRecordsId");

                    b.HasIndex("BookId");

                    b.HasIndex("BorrowerId");

                    b.HasIndex("UserId");

                    b.ToTable("BorrowingRecords");
                });

            modelBuilder.Entity("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.Penalty", b =>
                {
                    b.Property<int>("PenaltyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PenaltyId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("BorrowingRecordsId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSettled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PenaltyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PenaltyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PenaltyId");

                    b.HasIndex("BorrowingRecordsId");

                    b.ToTable("Penalty");
                });

            modelBuilder.Entity("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StayLoggedIn")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.Books", b =>
                {
                    b.HasOne("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.BookCategory", "BookCategory")
                        .WithMany()
                        .HasForeignKey("BookCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookCategory");
                });

            modelBuilder.Entity("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.BorrowingRecords", b =>
                {
                    b.HasOne("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.Books", "Books")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.Borrower", "Borrower")
                        .WithMany()
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("Borrower");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.Penalty", b =>
                {
                    b.HasOne("LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.BorrowingRecords", "BorrowingRecords")
                        .WithMany()
                        .HasForeignKey("BorrowingRecordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BorrowingRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
