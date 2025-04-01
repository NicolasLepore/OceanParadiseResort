using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OceanParadiseResort.Customers.Data.Dtos;
using OceanParadiseResort.Customers.Models;
using OceanParadiseResort.Customers.Services;

namespace OceanParadiseResort.Customers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly RegisterCustomer _registerManager;
        private readonly SignInCustomer _signInManager;


        public CustomerController(RegisterCustomer manager, SignInCustomer signInManager)
        {
            _registerManager = manager;
            _signInManager = signInManager;
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateCustomerDto dto)
        {
            await _registerManager.Register(dto);

            return Ok("Usuário cadastrado!");
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginCustomerDto dto)
        {
            var token = await _signInManager.SignInAsync(dto);
            return Ok(token);

        }

        [HttpGet]
        [Authorize]
        public IActionResult GetTest()
        {
            return Ok("Olá, acesso restrito");
        }


        // NAO BAIXEI A DEPENDENCIA DO IDENTITY STORES POIS QUERIA VER PARA QUE SERVIA
    }
}
