﻿// <auto-generated />
using System;
using HaadEdu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HaadEdu.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HaadEdu.Domain.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_time");

                    b.HasKey("Id");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("HaadEdu.Domain.Entities.RolePermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<int>("Permission")
                        .HasColumnType("integer")
                        .HasColumnName("permission");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_time");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("role_permissions", (string)null);
                });

            modelBuilder.Entity("HaadEdu.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<long?>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_time");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("RoleId")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("HaadEdu.Domain.Entities.RolePermission", b =>
                {
                    b.HasOne("HaadEdu.Domain.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HaadEdu.Domain.Entities.User", b =>
                {
                    b.HasOne("HaadEdu.Domain.Entities.Role", "Role")
                        .WithOne()
                        .HasForeignKey("HaadEdu.Domain.Entities.User", "RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HaadEdu.Domain.Entities.Role", b =>
                {
                    b.Navigation("RolePermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
