namespace CustomerService.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CustomerService.Services;
using CustomerService.Models;
using CustomerService.Models.ServiceSal;

[ApiController]
[Route("[controller]")]
public class ServiceSalController : ControllerBase
{
    private IServiceSalService _serviceService;
    private IMapper _mapper;
    private ILogger<ServiceSalController> _logger;

    public ServiceSalController(
        IServiceSalService serviceService,
        IMapper mapper,
        ILogger<ServiceSalController> logger )
    {
        _serviceService = serviceService;
        _mapper = mapper;
        _logger = logger;   
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var employee = _serviceService.GetAll();
        return Ok(employee);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var employee = _serviceService.GetById(id);
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Create(CreateServiceSal model)
    {
        _serviceService.Create(model);
        return Ok(new { message = "Service created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, CreateServiceSal model)
    {
        _serviceService.Update(id, model);
        return Ok(new { message = "Service updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _serviceService.Delete(id);
        return Ok(new { message = "Service deleted" });
    }
}