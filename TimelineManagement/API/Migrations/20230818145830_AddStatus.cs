using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimelineManagement.Migrations
{
    public partial class AddStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "tb_tr_project_collaborators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("203b4a4b-e9f7-4419-e553-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 8, 18, 21, 58, 30, 757, DateTimeKind.Local).AddTicks(305), new DateTime(2023, 8, 18, 21, 58, 30, 757, DateTimeKind.Local).AddTicks(305) });

            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("c0a7e780-df61-420a-e552-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 8, 18, 21, 58, 30, 757, DateTimeKind.Local).AddTicks(293), new DateTime(2023, 8, 18, 21, 58, 30, 757, DateTimeKind.Local).AddTicks(303) });

            migrationBuilder.UpdateData(
                table: "tb_m_sections",
                keyColumn: "guid",
                keyValue: new Guid("1c7324b5-2e88-4d33-811b-08db9fb220e4"),
                column: "name",
                value: "In Progress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "tb_tr_project_collaborators");

            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("203b4a4b-e9f7-4419-e553-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 8, 18, 16, 5, 44, 945, DateTimeKind.Local).AddTicks(794), new DateTime(2023, 8, 18, 16, 5, 44, 945, DateTimeKind.Local).AddTicks(795) });

            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("c0a7e780-df61-420a-e552-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 8, 18, 16, 5, 44, 945, DateTimeKind.Local).AddTicks(773), new DateTime(2023, 8, 18, 16, 5, 44, 945, DateTimeKind.Local).AddTicks(788) });

            migrationBuilder.UpdateData(
                table: "tb_m_sections",
                keyColumn: "guid",
                keyValue: new Guid("1c7324b5-2e88-4d33-811b-08db9fb220e4"),
                column: "name",
                value: "Doing");
        }
    }
}
