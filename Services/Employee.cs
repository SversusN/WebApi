namespace CustomerService.Services;

using AutoMapper;
using BCrypt.Net;
using CustomerService.Entities;
using CustomerService.Helpers;
using CustomerService.Models;
using CustomerService.Models.Users;

public interface IEmployeeService
{
    IEnumerable<Employee> GetAll();
    Employee GetById(int id);
    void Create(CreateEmployee model);
    void Update(int id, CreateEmployee model);
    void Delete(int id);
}

public class EmployeeService : IEmployeeService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Employee> GetAll()
    {
        return _context.Employees;
    }

    public Employee GetById(int id)
    {
        return getEmoloyee(id);
    }

    public void Create(CreateEmployee model)
    {
        // validate
        if (_context.Employees.Any(x => x.Name == model.Name))
            throw new AppException("Employee '" + model.Name + "' already exists");

        // map model to new user object
        var employee = _mapper.Map<Employee>(model);

        // hash password
     //   user.PasswordHash = BCrypt.HashPassword(model.Password);

        // save user
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public void Update(int id, CreateEmployee model)
    {
        var employee = getEmoloyee(id);

        // validate
        if (_context.Employees.Any(x => x.Name == model.Name))
            throw new AppException("Employee '" + model.Name + "' already exists");



        // copy model to user and save
        _mapper.Map(model, employee);
        _context.Employees.Update(employee);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var employee = getEmoloyee(id);
        _context.Employees.Remove(employee);
        _context.SaveChanges();
    }

    // helper methods

    private Employee getEmoloyee(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null) throw new KeyNotFoundException("User not found");
        return employee;
    }
}