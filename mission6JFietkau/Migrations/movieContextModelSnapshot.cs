﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mission6JFietkau.Models;

#nullable disable

namespace mission6JFietkau.Migrations
{
    [DbContext(typeof(movieContext))]
    partial class movieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("mission6JFietkau.Models.Movie", b =>
                {
                    b.Property<string>("category")
                        .HasColumnType("TEXT");

                    b.Property<string>("director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("edited")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lent_to")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("year")
                        .HasColumnType("INTEGER");

                    b.HasKey("category");

                    b.ToTable("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
