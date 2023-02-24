namespace CustomerService.Services;

using AutoMapper;
using BCrypt.Net;
using CustomerService.Entities;
using CustomerService.Helpers;
using CustomerService.Models;
using CustomerService.Models.Users;

public interface IFilialService
{
    IEnumerable<Filial> GetAll();
    Filial GetById(int id);
    void Create(CreateFilial model);
    void Update(int id, CreateFilial model);
    void Delete(int id);
}

public class FilialService : IFilialService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public FilialService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Filial> GetAll()
    {
        return _context.Filials;
    }

    public Filial GetById(int id)
    {
        return getFilial(id);
    }

    public void Create(CreateFilial model)
    {
        // validate
        if (_context.Filials.Any(x => x.Name == model.Name))
            throw new AppException("Employee '" + model.Name + "' already exists");

        // map model to new user object
        var filial = _mapper.Map<Filial>(model);

        // hash password
     //   user.PasswordHash = BCrypt.HashPassword(model.Password);

        // save user
        _context.Filials.Add(filial);
        _context.SaveChanges();
    }

    public void Update(int id, CreateFilial model)
    {
        var filial = getFilial(id);

        // validate
        if (_context.Employees.Any(x => x.Name == model.Name))
            throw new AppException("Employee '" + model.Name + "' already exists");



        // copy model to user and save
        _mapper.Map(model, filial);
        _context.Filials.Update(filial);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var employee = getFilial(id);
        _context.Filials.Remove(employee);
        _context.SaveChanges();
    }

    // helper methods

    private Filial getFilial(int id)
    {
        var filial = _context.Filials.Find(id);
        if (filial == null) throw new KeyNotFoundException("User not found");
        return filial;
    }
}