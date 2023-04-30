﻿// <auto-generated />
using System;
using Ecom_API.DBHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EcomAPI.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230428041648_20230428-Init")]
    partial class _20230428Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ecom_API.DTO.Entities.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("created_user")
                        .HasColumnType("integer");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("updated_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("updated_user")
                        .HasColumnType("integer");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}