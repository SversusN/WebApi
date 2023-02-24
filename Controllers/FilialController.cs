namespace CustomerService.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CustomerService.Services;
using CustomerService.Models;
using CustomerService.Models.ServiceSal;

[ApiController]
[Route("[controller]")]
public class FilialController : ControllerBase
{
    private IFilialService _filialService;
    private IMapper _mapper;
    private ILogger<FilialController> _logger;

    public FilialController(
        IFilialService filialService,
        IMapper mapper,
        ILogger<FilialController> logger )
    {
        _filialService = filialService;
        _mapper = mapper;
        _logger = logger;   
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var employee = _filialService.GetAll();
        return Ok(employee);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var employee = _filialService.GetById(id);
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Create(CreateFilial model)
    {
        _filialService.Create(model);
        return Ok(new { message = "Service created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, CreateFilial model)
    {
        _filialService.Update(id, model);
        return Ok(new { message = "Service updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _filialService.Delete(id);
        return Ok(new { message = "Service deleted" });
    }
}