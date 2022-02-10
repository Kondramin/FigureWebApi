﻿// <auto-generated />
using Figure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Figure.Database.Migrations
{
    [DbContext(typeof(FigureDb))]
    partial class FigureDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("Figure.Data.Entity.Entities.Circle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountOfAngles")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Radius")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Circles");
                });

            modelBuilder.Entity("Figure.Data.Entity.Entities.Triangle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountOfAngles")
                        .HasColumnType("INTEGER");

                    b.Property<double>("SideA")
                        .HasColumnType("REAL");

                    b.Property<double>("SideB")
                        .HasColumnType("REAL");

                    b.Property<double>("SideC")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Triangles");
                });
#pragma warning restore 612, 618
        }
    }
}
