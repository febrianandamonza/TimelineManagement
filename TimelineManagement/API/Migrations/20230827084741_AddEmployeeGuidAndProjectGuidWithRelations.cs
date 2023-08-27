using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimelineManagement.Migrations
{
    public partial class AddEmployeeGuidAndProjectGuidWithRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "employee_guid",
                table: "tb_tr_task_comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "project_guid",
                table: "tb_tr_task_comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("203b4a4b-e9f7-4419-e553-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 8, 27, 15, 47, 41, 444, DateTimeKind.Local).AddTicks(8759), new DateTime(2023, 8, 27, 15, 47, 41, 444, DateTimeKind.Local).AddTicks(8759) });

            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("c0a7e780-df61-420a-e552-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 8, 27, 15, 47, 41, 444, DateTimeKind.Local).AddTicks(8741), new DateTime(2023, 8, 27, 15, 47, 41, 444, DateTimeKind.Local).AddTicks(8754) });

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_task_comments_employee_guid",
                table: "tb_tr_task_comments",
                column: "employee_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_task_comments_project_guid",
                table: "tb_tr_task_comments",
                column: "project_guid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_task_comments_tb_m_employees_employee_guid",
                table: "tb_tr_task_comments",
                column: "employee_guid",
                principalTable: "tb_m_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_task_comments_tb_m_projects_project_guid",
                table: "tb_tr_task_comments",
                column: "project_guid",
                principalTable: "tb_m_projects",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_task_comments_tb_m_employees_employee_guid",
                table: "tb_tr_task_comments");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_task_comments_tb_m_projects_project_guid",
                table: "tb_tr_task_comments");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_task_comments_employee_guid",
                table: "tb_tr_task_comments");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_task_comments_project_guid",
                table: "tb_tr_task_comments");

            migrationBuilder.DropColumn(
                name: "employee_guid",
                table: "tb_tr_task_comments");

            migrationBuilder.DropColumn(
                name: "project_guid",
                table: "tb_tr_task_comments");

            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("203b4a4b-e9f7-4419-e553-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 8, 21, 11, 45, 55, 399, DateTimeKind.Local).AddTicks(9496), new DateTime(2023, 8, 21, 11, 45, 55, 399, DateTimeKind.Local).AddTicks(9496) });

            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("c0a7e780-df61-420a-e552-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 8, 21, 11, 45, 55, 399, DateTimeKind.Local).AddTicks(9482), new DateTime(2023, 8, 21, 11, 45, 55, 399, DateTimeKind.Local).AddTicks(9493) });
        }
    }
}
