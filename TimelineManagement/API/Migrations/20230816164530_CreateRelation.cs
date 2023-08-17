using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimelineManagement.Migrations
{
    public partial class CreateRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tas_guid",
                table: "tb_tr_task_comments",
                newName: "task_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_task_comments_task_guid",
                table: "tb_tr_task_comments",
                column: "task_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_project_collaborators_employee_guid",
                table: "tb_tr_project_collaborators",
                column: "employee_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_project_collaborators_project_guid",
                table: "tb_tr_project_collaborators",
                column: "project_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_account_guid",
                table: "tb_tr_account_roles",
                column: "account_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_account_roles_role_guid",
                table: "tb_tr_account_roles",
                column: "role_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_tasks_employee_guid",
                table: "tb_m_tasks",
                column: "employee_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_tasks_project_guid",
                table: "tb_m_tasks",
                column: "project_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_tasks_section_guid",
                table: "tb_m_tasks",
                column: "section_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_projects_employee_guid",
                table: "tb_m_projects",
                column: "employee_guid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_accounts_tb_m_employees_guid",
                table: "tb_m_accounts",
                column: "guid",
                principalTable: "tb_m_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_projects_tb_m_employees_employee_guid",
                table: "tb_m_projects",
                column: "employee_guid",
                principalTable: "tb_m_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_tasks_tb_m_employees_employee_guid",
                table: "tb_m_tasks",
                column: "employee_guid",
                principalTable: "tb_m_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_tasks_tb_m_projects_project_guid",
                table: "tb_m_tasks",
                column: "project_guid",
                principalTable: "tb_m_projects",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_tasks_tb_m_sections_section_guid",
                table: "tb_m_tasks",
                column: "section_guid",
                principalTable: "tb_m_sections",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_accounts_account_guid",
                table: "tb_tr_account_roles",
                column: "account_guid",
                principalTable: "tb_m_accounts",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_roles_role_guid",
                table: "tb_tr_account_roles",
                column: "role_guid",
                principalTable: "tb_m_roles",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_project_collaborators_tb_m_employees_employee_guid",
                table: "tb_tr_project_collaborators",
                column: "employee_guid",
                principalTable: "tb_m_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_project_collaborators_tb_m_projects_project_guid",
                table: "tb_tr_project_collaborators",
                column: "project_guid",
                principalTable: "tb_m_projects",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_task_comments_tb_m_tasks_task_guid",
                table: "tb_tr_task_comments",
                column: "task_guid",
                principalTable: "tb_m_tasks",
                principalColumn: "guid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_accounts_tb_m_employees_guid",
                table: "tb_m_accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_projects_tb_m_employees_employee_guid",
                table: "tb_m_projects");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_tasks_tb_m_employees_employee_guid",
                table: "tb_m_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_tasks_tb_m_projects_project_guid",
                table: "tb_m_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_tasks_tb_m_sections_section_guid",
                table: "tb_m_tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_accounts_account_guid",
                table: "tb_tr_account_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_account_roles_tb_m_roles_role_guid",
                table: "tb_tr_account_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_project_collaborators_tb_m_employees_employee_guid",
                table: "tb_tr_project_collaborators");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_project_collaborators_tb_m_projects_project_guid",
                table: "tb_tr_project_collaborators");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_task_comments_tb_m_tasks_task_guid",
                table: "tb_tr_task_comments");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_task_comments_task_guid",
                table: "tb_tr_task_comments");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_project_collaborators_employee_guid",
                table: "tb_tr_project_collaborators");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_project_collaborators_project_guid",
                table: "tb_tr_project_collaborators");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_account_roles_account_guid",
                table: "tb_tr_account_roles");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_account_roles_role_guid",
                table: "tb_tr_account_roles");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_tasks_employee_guid",
                table: "tb_m_tasks");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_tasks_project_guid",
                table: "tb_m_tasks");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_tasks_section_guid",
                table: "tb_m_tasks");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_projects_employee_guid",
                table: "tb_m_projects");

            migrationBuilder.RenameColumn(
                name: "task_guid",
                table: "tb_tr_task_comments",
                newName: "tas_guid");
        }
    }
}
