namespace CustomerService.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CustomerService.Models.Users;
using CustomerService.Services;
using CustomerService.Models;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private IEmployeeService _employeeService;
    private IMapper _mapper;
    private ILogger<EmployeeController> _logger;

    public EmployeeController(
        IEmployeeService employeeService,
        IMapper mapper,
        ILogger<EmployeeController> logger )
    {
        _employeeService = employeeService;
        _mapper = mapper;
        _logger = logger;   
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var employee = _employeeService.GetAll();
        return Ok(employee);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var employee = _employeeService.GetById(id);
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Create(CreateEmployee model)
    {
        _employeeService.Create(model);
        return Ok(new { message = "User created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, CreateEmployee model)
    {
        _employeeService.Update(id, model);
        return Ok(new { message = "User updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _employeeService.Delete(id);
        return Ok(new { message = "User deleted" });
    }
}