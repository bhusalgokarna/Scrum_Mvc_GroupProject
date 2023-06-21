﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scrum_Mvc_GroupProject.Data;

#nullable disable

namespace Scrum_Mvc_GroupProject.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    [Migration("20230620115135_CreatedDb")]
    partial class CreatedDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Scrum_Mvc_GroupProject.Models.DiscussieThread", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comentaar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ForumCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ForumCategoryId");

                    b.ToTable("DiscussieThreads");
                });

            modelBuilder.Entity("Scrum_Mvc_GroupProject.Models.ForumCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ForumCategories");
                });

            modelBuilder.Entity("Scrum_Mvc_GroupProject.Models.Reactie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comentaar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscussieThreadId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiscussieThreadId");

                    b.ToTable("Reacties");
                });

            modelBuilder.Entity("Scrum_Mvc_GroupProject.Models.DiscussieThread", b =>
                {
                    b.HasOne("Scrum_Mvc_GroupProject.Models.ForumCategory", "forumCategory")
                        .WithMany("discussies")
                        .HasForeignKey("ForumCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("forumCategory");
                });

            modelBuilder.Entity("Scrum_Mvc_GroupProject.Models.Reactie", b =>
                {
                    b.HasOne("Scrum_Mvc_GroupProject.Models.DiscussieThread", "discussieThread")
                        .WithMany("Reacties")
                        .HasForeignKey("DiscussieThreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("discussieThread");
                });

            modelBuilder.Entity("Scrum_Mvc_GroupProject.Models.DiscussieThread", b =>
                {
                    b.Navigation("Reacties");
                });

            modelBuilder.Entity("Scrum_Mvc_GroupProject.Models.ForumCategory", b =>
                {
                    b.Navigation("discussies");
                });
#pragma warning restore 612, 618
        }
    }
}