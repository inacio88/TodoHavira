﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todo.Api.Data;

#nullable disable

namespace Todo.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241223001546_v1Fake")]
    partial class v1Fake
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Todo.Core.Models.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataConclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Tarefa", (string)null);
                });

            modelBuilder.Entity("Todo.Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Todo.Core.Models.User", b =>
                {
                    b.OwnsOne("Todo.Core.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.OwnsOne("Todo.Core.ValueObjects.Verification", "Verification", b2 =>
                                {
                                    b2.Property<Guid>("EmailUserId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Code")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)")
                                        .HasColumnName("EmailVerificationCode");

                                    b2.Property<DateTime?>("ExpiresAt")
                                        .HasColumnType("datetime2")
                                        .HasColumnName("EmailVerificationExpiresAt");

                                    b2.Property<DateTime?>("VerifiedAt")
                                        .HasColumnType("datetime2")
                                        .HasColumnName("EmailVerificationVerifiedAt");

                                    b2.HasKey("EmailUserId");

                                    b2.ToTable("User");

                                    b2.WithOwner()
                                        .HasForeignKey("EmailUserId");
                                });

                            b1.Navigation("Verification")
                                .IsRequired();
                        });

                    b.OwnsOne("Todo.Core.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Hash")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PasswordHash");

                            b1.Property<string>("ResetCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PasswordResetCode");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
