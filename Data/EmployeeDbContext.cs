using Microsoft.EntityFrameworkCore;
using EmployeeService.Models;

namespace EmployeeService.Data;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options) { }

    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employees");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                  .HasColumnName("id");

            entity.Property(e => e.EmployeeCode)
                  .HasColumnName("employee_code");

            entity.Property(e => e.Name)
                  .HasColumnName("name");

            entity.Property(e => e.Email)
                  .HasColumnName("email");

            entity.Property(e => e.Department)
                  .HasColumnName("department");

            entity.Property(e => e.CreatedAt)
                  .HasColumnName("created_at");
        });
    }
}
