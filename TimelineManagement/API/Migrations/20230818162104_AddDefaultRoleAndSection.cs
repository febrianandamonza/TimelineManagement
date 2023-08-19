using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimelineManagement.Migrations
{
    public partial class AddDefaultRoleAndSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("203b4a4b-e9f7-4419-e553-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 8, 18, 23, 21, 3, 955, DateTimeKind.Local).AddTicks(7927), new DateTime(2023, 8, 18, 23, 21, 3, 955, DateTimeKind.Local).AddTicks(7928) });

            migrationBuilder.UpdateData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("c0a7e780-df61-420a-e552-08db9fa3dda3"),
                columns: new[] { "created_date", "modified_date" },
                values: new object[] { new DateTime(2023, 8, 18, 23, 21, 3, 955, DateTimeKind.Local).AddTicks(7909), new DateTime(2023, 8, 18, 23, 21, 3, 955, DateTimeKind.Local).AddTicks(7921) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
