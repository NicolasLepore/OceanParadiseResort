using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OceanParadiseResort.Customers.Data.Dtos;
using OceanParadiseResort.Customers.Models;

namespace OceanParadiseResort.Customers.Services
{
    public class SignInCustomer
    {
        private readonly SignInManager<Customer> _signInManager;
        private readonly TokenService _tokenService;

        public SignInCustomer(SignInManager<Customer> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> SignIn(LoginCustomerDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Username!, dto.Password!, false, false);


            if (!result.Succeeded) throw new ArgumentException("Usuário ou senha incorretos!");
            
            var user = _signInManager.UserManager.Users
                .FirstOrDefault(u => u.UserName == dto.Username);

            var token = _tokenService.Generate(user!);

            return token;
        }
    }
}
