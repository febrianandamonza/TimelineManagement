using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimelineManagement.DTOs.Roles;
using TimelineManagement.DTOs.Sections;
using TimelineManagement.Models;
using Task = TimelineManagement.Models.Task;

namespace TimelineManagement.Data;

public class TimelineManagementDbContext : DbContext
{
    public TimelineManagementDbContext(DbContextOptions<TimelineManagementDbContext> options) : base(options){ }
    
    //Pembuatan Table di Database pada Models
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountsRoles { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectCollaborator> ProjectCollaborators { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<TaskComment> TaskComments { get; set; }
    public DbSet<TaskHistory> TaskHistories { get; set; }
    
    //Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(new NewRoleDefaultDto
            {
                Guid = Guid.Parse("c0a7e780-df61-420a-e552-08db9fa3dda3"),
                Name = "Staff"
            },
            new NewRoleDefaultDto
            {
                Guid = Guid.Parse("203b4a4b-e9f7-4419-e553-08db9fa3dda3"),
                Name = "Project Manager"
            });
        
        modelBuilder.Entity<Section>().HasData(new NewSectionDefaultDto
            {
                Guid = Guid.Parse("fe4aa61c-329d-447f-811a-08db9fb220e4"),
                Name = "To Do"
            },
            new NewSectionDefaultDto
            {
                Guid = Guid.Parse("1c7324b5-2e88-4d33-811b-08db9fb220e4"),
                Name = "In Progress"
            },
            new NewSectionDefaultDto
            {
                Guid = Guid.Parse("196272df-788f-4894-811c-08db9fb220e4"),
                Name = "Testing"
            },
            new NewSectionDefaultDto
            {
                Guid = Guid.Parse("ec87fdea-0a03-4ce2-811d-08db9fb220e4"),
                Name = "Done"
            });
            
        
        modelBuilder.Entity<Employee>().HasIndex(e => new
        {
            e.Nik,
            e.Email,
            e.PhoneNumber
        }).IsUnique();
        
        //One Account with Many Account Roles
        modelBuilder.Entity<Account>()
            .HasMany(account => account.AccountRole)
            .WithOne(ar => ar.Account)
            .HasForeignKey(ar => ar.AccountGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        // One Role with Many Account Roles
        modelBuilder.Entity<Role>()
            .HasMany(r => r.AccountRole)
            .WithOne(ar => ar.Role)
            .HasForeignKey(ar => ar.RoleGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Employee with Many Project
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Project)
            .WithOne(p => p.Employee)
            .HasForeignKey(p => p.EmployeeGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Employee with Many Project Collaborator
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.ProjectCollaborator)
            .WithOne(pc => pc.Employee)
            .HasForeignKey(pc => pc.EmployeeGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Employee with Many Task Comment
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.TaskComment)
            .WithOne(tc => tc.Employee)
            .HasForeignKey(tc => tc.EmployeeGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Employee with Many Task Comment
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.TaskHistory)
            .WithOne(th => th.Employee)
            .HasForeignKey(th => th.EmployeeGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Employee with Many Task
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Task)
            .WithOne(t => t.Employee)
            .HasForeignKey(t => t.EmployeeGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Project with Many Task
        modelBuilder.Entity<Project>()
            .HasMany(p => p.Task)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Project with Many Task Comment
        modelBuilder.Entity<Project>()
            .HasMany(p => p.TaskComment)
            .WithOne(tc => tc.Project)
            .HasForeignKey(tc => tc.ProjectGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Project with Many Task Comment
        modelBuilder.Entity<Project>()
            .HasMany(p => p.TaskHistory)
            .WithOne(th => th.Project)
            .HasForeignKey(th => th.ProjectGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Project with Many Project Collaborator
        modelBuilder.Entity<Project>()
            .HasMany(p => p.ProjectCollaborator)
            .WithOne(pc => pc.Project)
            .HasForeignKey(pc => pc.ProjectGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Task with Many Task Comment
        modelBuilder.Entity<Task>()
            .HasMany(t => t.TaskComment)
            .WithOne(tc => tc.Task)
            .HasForeignKey(tc => tc.TaskGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Task with Many Task Histories
        modelBuilder.Entity<Task>()
            .HasMany(t => t.TaskHistory)
            .WithOne(th => th.Task)
            .HasForeignKey(th => th.TaskGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Section with Many Task
        modelBuilder.Entity<Section>()
            .HasMany(s => s.Task)
            .WithOne(t => t.Section)
            .HasForeignKey(t => t.SectionGuid)
            .OnDelete(DeleteBehavior.Restrict);
        
        //One Account with One Employee
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Employee)
            .WithOne(e => e.Account)
            .HasForeignKey<Account>(a => a.Guid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}