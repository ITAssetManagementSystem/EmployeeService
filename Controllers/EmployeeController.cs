using EmployeeService.Models;
using EmployeeService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers;

[ApiController]
[Route("employees")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeDomainService _service;

    public EmployeeController(EmployeeDomainService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        return Ok(_service.Create(employee));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{code}")]
    public IActionResult GetByCode(string code)
    {
        var emp = _service.GetByCode(code);
        if (emp == null) return NotFound();
        return Ok(emp);
    }
}
