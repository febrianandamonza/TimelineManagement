using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimelineManagement.Migrations
{
    public partial class DefaultRoleSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("203b4a4b-e9f7-4419-e553-08db9fa3dda3"), new DateTime(2023, 8, 18, 16, 5, 44, 945, DateTimeKind.Local).AddTicks(794), new DateTime(2023, 8, 18, 16, 5, 44, 945, DateTimeKind.Local).AddTicks(795), "Project Manager" },
                    { new Guid("c0a7e780-df61-420a-e552-08db9fa3dda3"), new DateTime(2023, 8, 18, 16, 5, 44, 945, DateTimeKind.Local).AddTicks(773), new DateTime(2023, 8, 18, 16, 5, 44, 945, DateTimeKind.Local).AddTicks(788), "Staff" }
                });

            migrationBuilder.InsertData(
                table: "tb_m_sections",
                columns: new[] { "guid", "name" },
                values: new object[,]
                {
                    { new Guid("196272df-788f-4894-811c-08db9fb220e4"), "Testing" },
                    { new Guid("1c7324b5-2e88-4d33-811b-08db9fb220e4"), "Doing" },
                    { new Guid("ec87fdea-0a03-4ce2-811d-08db9fb220e4"), "Done" },
                    { new Guid("fe4aa61c-329d-447f-811a-08db9fb220e4"), "To Do" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("203b4a4b-e9f7-4419-e553-08db9fa3dda3"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("c0a7e780-df61-420a-e552-08db9fa3dda3"));

            migrationBuilder.DeleteData(
                table: "tb_m_sections",
                keyColumn: "guid",
                keyValue: new Guid("196272df-788f-4894-811c-08db9fb220e4"));

            migrationBuilder.DeleteData(
                table: "tb_m_sections",
                keyColumn: "guid",
                keyValue: new Guid("1c7324b5-2e88-4d33-811b-08db9fb220e4"));

            migrationBuilder.DeleteData(
                table: "tb_m_sections",
                keyColumn: "guid",
                keyValue: new Guid("ec87fdea-0a03-4ce2-811d-08db9fb220e4"));

            migrationBuilder.DeleteData(
                table: "tb_m_sections",
                keyColumn: "guid",
                keyValue: new Guid("fe4aa61c-329d-447f-811a-08db9fb220e4"));
        }
    }
}
