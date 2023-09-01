using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimelineManagement.Migrations
{
    public partial class AddIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "tb_m_projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("203b4a4b-e9f7-4419-e553-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 9, 1, 13, 34, 48, 823, DateTimeKind.Local).AddTicks(4333), new DateTime(2023, 9, 1, 13, 34, 48, 823, DateTimeKind.Local).AddTicks(4333) });

            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("c0a7e780-df61-420a-e552-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 9, 1, 13, 34, 48, 823, DateTimeKind.Local).AddTicks(4318), new DateTime(2023, 9, 1, 13, 34, 48, 823, DateTimeKind.Local).AddTicks(4330) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "tb_m_projects");

            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("203b4a4b-e9f7-4419-e553-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 8, 28, 14, 22, 5, 295, DateTimeKind.Local).AddTicks(6534), new DateTime(2023, 8, 28, 14, 22, 5, 295, DateTimeKind.Local).AddTicks(6534) });

            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("c0a7e780-df61-420a-e552-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 8, 28, 14, 22, 5, 295, DateTimeKind.Local).AddTicks(6521), new DateTime(2023, 8, 28, 14, 22, 5, 295, DateTimeKind.Local).AddTicks(6530) });
        }
    }
}
