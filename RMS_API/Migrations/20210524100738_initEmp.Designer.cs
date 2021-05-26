﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RMS_API.Data;

namespace RMS_API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210524100738_initEmp")]
    partial class initEmp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.1.21102.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RMS_API.Model.Employee", b =>
                {
                    b.Property<string>("EmpId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<bool?>("IsAssigned")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillSet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RMS_API.Model.EmployeeSkill", b =>
                {
                    b.Property<long>("TempId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmpId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SkillSet")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TempId");

                    b.HasIndex("EmpId");

                    b.HasIndex("SkillSet");

                    b.ToTable("EmployeeSkill");
                });

            modelBuilder.Entity("RMS_API.Model.Skill", b =>
                {
                    b.Property<string>("SkillSet")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SkillSet");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("RMS_API.Model.EmployeeSkill", b =>
                {
                    b.HasOne("RMS_API.Model.Employee", "Employee")
                        .WithMany("EmployeeSkill")
                        .HasForeignKey("EmpId");

                    b.HasOne("RMS_API.Model.Skill", "Skill")
                        .WithMany("EmployeeSkill")
                        .HasForeignKey("SkillSet");

                    b.Navigation("Employee");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("RMS_API.Model.Employee", b =>
                {
                    b.Navigation("EmployeeSkill");
                });

            modelBuilder.Entity("RMS_API.Model.Skill", b =>
                {
                    b.Navigation("EmployeeSkill");
                });
#pragma warning restore 612, 618
        }
    }
}
