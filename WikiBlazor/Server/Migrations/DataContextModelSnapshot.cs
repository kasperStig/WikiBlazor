﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WikiBlazor.Server.Data;

namespace WikiBlazor.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArticleCategory", b =>
                {
                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("ArticleId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ArticleCategory");

                    b.HasData(
                        new
                        {
                            ArticleId = 1L,
                            CategoryId = 2L
                        },
                        new
                        {
                            ArticleId = 1L,
                            CategoryId = 3L
                        },
                        new
                        {
                            ArticleId = 2L,
                            CategoryId = 1L
                        },
                        new
                        {
                            ArticleId = 2L,
                            CategoryId = 3L
                        });
                });

            modelBuilder.Entity("WikiBlazor.Shared.Article", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Title = "Fish (singer)",
                            Url = "https://en.wikipedia.org/wiki/Fish_(singer)"
                        },
                        new
                        {
                            Id = 2L,
                            Title = "The Art of Unit Testing",
                            Url = "https://en.wikipedia.org/wiki/The_Art_of_Unit_Testing"
                        });
                });

            modelBuilder.Entity("WikiBlazor.Shared.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Test"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Fish"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Art"
                        });
                });

            modelBuilder.Entity("ArticleCategory", b =>
                {
                    b.HasOne("WikiBlazor.Shared.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WikiBlazor.Shared.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
