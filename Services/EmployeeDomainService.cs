using EmployeeService.Data;
using EmployeeService.Models;

namespace EmployeeService.Services;

public class EmployeeDomainService
{
    private readonly EmployeeDbContext _db;
    private readonly ILogger<EmployeeDomainService> _logger;

    public EmployeeDomainService(EmployeeDbContext db, ILogger<EmployeeDomainService> logger)
    {
        _db = db;
        _logger = logger;
    }

    public Employee Create(Employee employee)
    {
        _logger.LogInformation("Creating employee {Code}", employee.EmployeeCode);
        _db.Employees.Add(employee);
        _db.SaveChanges();
        return employee;
    }

    public IEnumerable<Employee> GetAll()
    {
        _logger.LogInformation("Fetching all employees");
        return _db.Employees.ToList();
    }

    public Employee? GetByCode(string code)
    {
        _logger.LogInformation("Fetching employee {Code}", code);
        return _db.Employees.FirstOrDefault(e => e.EmployeeCode == code);
    }
}
