using AutoMapper;
using MyApiProject.Models;
using MyApiProject.Dtos;

namespace MyApiProject.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<CreateCustomerDto, Customer>();
        }
    }
}
