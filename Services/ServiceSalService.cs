

using AutoMapper;
using CustomerService.Entities;
using CustomerService.Helpers;
using CustomerService.Models.ServiceSal;

namespace CustomerService.Services;
public interface IServiceSalService
{
    IEnumerable<ServiceSal> GetAll();
    ServiceSal GetById(int id);
    void Create(CreateServiceSal model);
    void Update(int id, CreateServiceSal model);
    void Delete(int id);
}

public class ServiceSalService : IServiceSalService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public ServiceSalService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<ServiceSal> GetAll()
    {
        return _context.ServiceSal;
    }

    public ServiceSal GetById(int id)
    {
        return getServiceSal(id);
    }

    public void Create(CreateServiceSal model)
    {
        // validate
        if (_context.ServiceSal.Any(x => x.Name == model.Name))
            throw new AppException("ServiceSal '" + model.Name + "' already exists");

        // map model to new user object
        var service= _mapper.Map<ServiceSal>(model);

        // hash password
     //   user.PasswordHash = BCrypt.HashPassword(model.Password);

        // save user
        _context.ServiceSal.Add(service);
        _context.SaveChanges();
    }

    public void Update(int id, CreateServiceSal model)
    {
        var service = getServiceSal(id);

        // validate
        if (_context.Employees.Any(x => x.Name == model.Name))
            throw new AppException("Employee '" + model.Name + "' already exists");
        // copy model to user and save
        _mapper.Map(model, service);
        _context.ServiceSal.Update(service);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var service = getServiceSal(id);
        _context.ServiceSal.Remove(service);
        _context.SaveChanges();
    }

    // helper methods

    private ServiceSal getServiceSal(int id)
    {
        var service = _context.ServiceSal.Find(id);
        if (service == null) throw new KeyNotFoundException("Service not found");
        return service;
    }
}