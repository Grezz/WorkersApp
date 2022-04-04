﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WorkersApp.Infrastructure.PG;

namespace WorkersApp.Infrastructure.PG.Migrations
{
    [DbContext(typeof(PGContext))]
    [Migration("20220403183248_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ApplicationCore.Entities.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Childrens")
                        .HasColumnType("integer");

                    b.Property<string>("Firstname")
                        .HasColumnType("text");

                    b.Property<bool>("IsMan")
                        .HasColumnType("boolean");

                    b.Property<string>("Middlename")
                        .HasColumnType("text");

                    b.Property<string>("Secondname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}
