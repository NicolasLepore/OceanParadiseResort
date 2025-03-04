using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OceanParadiseResort.Customers.Data.Dtos;
using OceanParadiseResort.Customers.Exceptions;
using OceanParadiseResort.Customers.Models;

namespace OceanParadiseResort.Customers.Services
{
    public class RegisterCustomer
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Customer> _userManager;

        public RegisterCustomer(IMapper mapper, UserManager<Customer> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task Register(CreateCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);

            var result = await _userManager.CreateAsync(customer, dto.Password!);

            if (!result.Succeeded) throw new CustomerManagementException("Erro ao cadastrar usuário", result.Errors);
        }
    }
}
