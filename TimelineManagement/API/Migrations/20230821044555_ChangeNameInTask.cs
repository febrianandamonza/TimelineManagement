using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimelineManagement.Migrations
{
    public partial class ChangeNameInTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "tb_m_tasks",
                newName: "is_finished");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_finished",
                table: "tb_m_tasks",
                newName: "status");

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
    }
}
