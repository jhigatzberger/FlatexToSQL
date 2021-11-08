﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using FlatexToSQL.DataModels;

namespace FlatexToSQL.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20211105192623_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("WPFSQLEntityFramwork.DataModels.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDateTime")
                        .HasColumnType("datetime");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Side")
                        .HasColumnType("int");

                    b.Property<float>("Volume")
                        .HasColumnType("float");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}