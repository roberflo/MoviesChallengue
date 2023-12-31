﻿// <auto-generated />
using System;
using Challengue.Movies.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Challenge.Movies.Persistence.Migrations
{
    [DbContext(typeof(ChallengeDbContext))]
    [Migration("20230412073535_seeds")]
    partial class seeds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Challenge.Movies.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("35222c2f-f7d3-42e6-9db6-f9aa199bb514"),
                            CreatedBy = "roberto@hireme.com",
                            CreatedDate = new DateTime(2023, 4, 12, 1, 35, 35, 567, DateTimeKind.Local).AddTicks(3991),
                            Name = "Terror"
                        });
                });

            modelBuilder.Entity("Challenge.Movies.Domain.Entities.Movie", b =>
                {
                    b.Property<Guid>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("ImagePoster")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("MovieId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = new Guid("70add475-5bfc-499d-817e-90a301378f22"),
                            CategoryId = new Guid("35222c2f-f7d3-42e6-9db6-f9aa199bb514"),
                            CreatedBy = "roberto@hireme.com",
                            CreatedDate = new DateTime(2023, 4, 12, 1, 35, 35, 567, DateTimeKind.Local).AddTicks(4088),
                            Name = "Sharks and Ghosts",
                            ReleaseDate = new DateTime(2023, 4, 12, 1, 35, 35, 567, DateTimeKind.Local).AddTicks(4087),
                            Synopsis = "Sharks that eat people so then becomes ghosts to guide other people to the sharks to continue the killing cycle"
                        });
                });

            modelBuilder.Entity("Challenge.Movies.Domain.Entities.Rating", b =>
                {
                    b.Property<Guid>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RateOption")
                        .HasColumnType("int");

                    b.Property<string>("RateUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RatingId");

                    b.HasIndex("MovieId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            RatingId = new Guid("b66bdfdb-f178-434e-bbc5-2d1b06d75b5c"),
                            CreatedBy = "roberto@hireme.com",
                            CreatedDate = new DateTime(2023, 4, 12, 1, 35, 35, 567, DateTimeKind.Local).AddTicks(4099),
                            MovieId = new Guid("70add475-5bfc-499d-817e-90a301378f22"),
                            RateOption = 5,
                            RateUser = "roberto@hireme.com"
                        });
                });

            modelBuilder.Entity("Challenge.Movies.Domain.Entities.Movie", b =>
                {
                    b.HasOne("Challenge.Movies.Domain.Entities.Category", "Category")
                        .WithMany("Movies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Challenge.Movies.Domain.Entities.Rating", b =>
                {
                    b.HasOne("Challenge.Movies.Domain.Entities.Movie", "Movie")
                        .WithMany("Ratings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Challenge.Movies.Domain.Entities.Category", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Challenge.Movies.Domain.Entities.Movie", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
