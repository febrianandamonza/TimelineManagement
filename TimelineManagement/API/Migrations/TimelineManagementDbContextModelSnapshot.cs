﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimelineManagement.Data;

#nullable disable

namespace TimelineManagement.Migrations
{
    [DbContext(typeof(TimelineManagementDbContext))]
    partial class TimelineManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TimelineManagement.Models.Account", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("expired_date");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit")
                        .HasColumnName("is_used");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<int>("Otp")
                        .HasColumnType("int")
                        .HasColumnName("otp");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("password");

                    b.HasKey("Guid");

                    b.ToTable("tb_m_accounts");
                });

            modelBuilder.Entity("TimelineManagement.Models.AccountRole", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<Guid>("AccountGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("account_guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<Guid>("RoleGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("role_guid");

                    b.HasKey("Guid");

                    b.HasIndex("AccountGuid");

                    b.HasIndex("RoleGuid");

                    b.ToTable("tb_tr_account_roles");
                });

            modelBuilder.Entity("TimelineManagement.Models.Employee", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("hiring_date");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Nik")
                        .IsRequired()
                        .HasColumnType("nchar(6)")
                        .HasColumnName("nik");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("phone_number");

                    b.HasKey("Guid");

                    b.HasIndex("Nik", "Email", "PhoneNumber")
                        .IsUnique();

                    b.ToTable("tb_m_employees");
                });

            modelBuilder.Entity("TimelineManagement.Models.Project", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid>("EmployeeGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("employee_guid");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("end_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_date");

                    b.HasKey("Guid");

                    b.HasIndex("EmployeeGuid");

                    b.ToTable("tb_m_projects");
                });

            modelBuilder.Entity("TimelineManagement.Models.ProjectCollaborator", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid>("EmployeeGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("employee_guid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<Guid>("ProjectGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("project_guid");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("Guid");

                    b.HasIndex("EmployeeGuid");

                    b.HasIndex("ProjectGuid");

                    b.ToTable("tb_tr_project_collaborators");
                });

            modelBuilder.Entity("TimelineManagement.Models.Role", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.ToTable("tb_m_roles");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("c0a7e780-df61-420a-e552-08db9fa3dda3"),
                            CreatedDate = new DateTime(2023, 8, 18, 23, 21, 3, 955, DateTimeKind.Local).AddTicks(7909),
                            ModifiedDate = new DateTime(2023, 8, 18, 23, 21, 3, 955, DateTimeKind.Local).AddTicks(7921),
                            Name = "Staff"
                        },
                        new
                        {
                            Guid = new Guid("203b4a4b-e9f7-4419-e553-08db9fa3dda3"),
                            CreatedDate = new DateTime(2023, 8, 18, 23, 21, 3, 955, DateTimeKind.Local).AddTicks(7927),
                            ModifiedDate = new DateTime(2023, 8, 18, 23, 21, 3, 955, DateTimeKind.Local).AddTicks(7928),
                            Name = "Project Manager"
                        });
                });

            modelBuilder.Entity("TimelineManagement.Models.Section", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.ToTable("tb_m_sections");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("fe4aa61c-329d-447f-811a-08db9fb220e4"),
                            Name = "To Do"
                        },
                        new
                        {
                            Guid = new Guid("1c7324b5-2e88-4d33-811b-08db9fb220e4"),
                            Name = "In Progress"
                        },
                        new
                        {
                            Guid = new Guid("196272df-788f-4894-811c-08db9fb220e4"),
                            Name = "Testing"
                        },
                        new
                        {
                            Guid = new Guid("ec87fdea-0a03-4ce2-811d-08db9fb220e4"),
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("TimelineManagement.Models.Task", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid>("EmployeeGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("employee_guid");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("end_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("Priority")
                        .HasColumnType("int")
                        .HasColumnName("priority");

                    b.Property<Guid>("ProjectGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("project_guid");

                    b.Property<Guid>("SectionGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("section_guid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_date");

                    b.Property<bool>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.HasKey("Guid");

                    b.HasIndex("EmployeeGuid");

                    b.HasIndex("ProjectGuid");

                    b.HasIndex("SectionGuid");

                    b.ToTable("tb_m_tasks");
                });

            modelBuilder.Entity("TimelineManagement.Models.TaskComment", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<Guid>("TaskGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("task_guid");

                    b.HasKey("Guid");

                    b.HasIndex("TaskGuid");

                    b.ToTable("tb_tr_task_comments");
                });

            modelBuilder.Entity("TimelineManagement.Models.Account", b =>
                {
                    b.HasOne("TimelineManagement.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("TimelineManagement.Models.Account", "Guid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TimelineManagement.Models.AccountRole", b =>
                {
                    b.HasOne("TimelineManagement.Models.Account", "Account")
                        .WithMany("AccountRole")
                        .HasForeignKey("AccountGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TimelineManagement.Models.Role", "Role")
                        .WithMany("AccountRole")
                        .HasForeignKey("RoleGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TimelineManagement.Models.Project", b =>
                {
                    b.HasOne("TimelineManagement.Models.Employee", "Employee")
                        .WithMany("Project")
                        .HasForeignKey("EmployeeGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TimelineManagement.Models.ProjectCollaborator", b =>
                {
                    b.HasOne("TimelineManagement.Models.Employee", "Employee")
                        .WithMany("ProjectCollaborator")
                        .HasForeignKey("EmployeeGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TimelineManagement.Models.Project", "Project")
                        .WithMany("ProjectCollaborator")
                        .HasForeignKey("ProjectGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("TimelineManagement.Models.Task", b =>
                {
                    b.HasOne("TimelineManagement.Models.Employee", "Employee")
                        .WithMany("Task")
                        .HasForeignKey("EmployeeGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TimelineManagement.Models.Project", "Project")
                        .WithMany("Task")
                        .HasForeignKey("ProjectGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TimelineManagement.Models.Section", "Section")
                        .WithMany("Task")
                        .HasForeignKey("SectionGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("TimelineManagement.Models.TaskComment", b =>
                {
                    b.HasOne("TimelineManagement.Models.Task", "Task")
                        .WithMany("TaskComment")
                        .HasForeignKey("TaskGuid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("TimelineManagement.Models.Account", b =>
                {
                    b.Navigation("AccountRole");
                });

            modelBuilder.Entity("TimelineManagement.Models.Employee", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("Project");

                    b.Navigation("ProjectCollaborator");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("TimelineManagement.Models.Project", b =>
                {
                    b.Navigation("ProjectCollaborator");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("TimelineManagement.Models.Role", b =>
                {
                    b.Navigation("AccountRole");
                });

            modelBuilder.Entity("TimelineManagement.Models.Section", b =>
                {
                    b.Navigation("Task");
                });

            modelBuilder.Entity("TimelineManagement.Models.Task", b =>
                {
                    b.Navigation("TaskComment");
                });
#pragma warning restore 612, 618
        }
    }
}
