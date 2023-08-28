using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimelineManagement.Migrations
{
    public partial class AddTableAddTableTaskHistoryWithRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_tr_task_histories",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descriptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    task_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    project_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employee_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_task_histories", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_tr_task_histories_tb_m_employees_employee_guid",
                        column: x => x.employee_guid,
                        principalTable: "tb_m_employees",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tr_task_histories_tb_m_projects_project_guid",
                        column: x => x.project_guid,
                        principalTable: "tb_m_projects",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_tr_task_histories_tb_m_tasks_task_guid",
                        column: x => x.task_guid,
                        principalTable: "tb_m_tasks",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_task_histories_employee_guid",
                table: "tb_tr_task_histories",
                column: "employee_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_task_histories_project_guid",
                table: "tb_tr_task_histories",
                column: "project_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_task_histories_task_guid",
                table: "tb_tr_task_histories",
                column: "task_guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_tr_task_histories");

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
        }
    }
}
