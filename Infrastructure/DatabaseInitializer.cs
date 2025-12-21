using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace EmployeeService.Infrastructure;

[ApiController]
[Route("employees/init-db")]
public class DatabaseInitializer : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly ILogger<DatabaseInitializer> _logger;

    public DatabaseInitializer(IConfiguration config, ILogger<DatabaseInitializer> logger)
    {
        _config = config;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult InitDb()
    {
        var connString = _config.GetConnectionString("EmployeeDb");

        using var conn = new NpgsqlConnection(connString);
        conn.Open();

        using var cmd = new NpgsqlCommand(@"
            CREATE TABLE IF NOT EXISTS employees (
                id UUID PRIMARY KEY,
                employee_code VARCHAR(50) UNIQUE NOT NULL,
                name VARCHAR(255) NOT NULL,
                email VARCHAR(255) NOT NULL,
                department VARCHAR(100) NOT NULL,
                created_at TIMESTAMP NOT NULL
            );
        ", conn);

        cmd.ExecuteNonQuery();

        _logger.LogInformation("Employee DB schema initialized");

        return Ok("Employee DB schema initialized");
    }
}
