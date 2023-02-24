namespace CustomerService.Helpers;

using AutoMapper;
using CustomerService.Entities;
using CustomerService.Models.Users;
using CustomerService.Models;
using CustomerService.Models.ServiceSal;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateEmployee -> Employee
        CreateMap<CreateEmployee, Employee>();

        CreateMap<CreateServiceSal, ServiceSal>();

        CreateMap<CreateFilial, Filial>();
        // CreateRequest -> User
        CreateMap<CreateRequest, User>();

        // UpdateRequest -> User
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    // ignore null role
                    if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                    return true;
                }
            ));
    }
}