using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OceanParadiseResort.Bedrooms.Application.Dtos;
using OceanParadiseResort.Bedrooms.Domain.Models;
using OceanParadiseResort.Bedrooms.Infra.Data;

namespace OceanParadiseResort.Bedrooms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BedroomController : ControllerBase
    {
        private readonly AppBedroomContext _context;
        private readonly IMapper _mapper;

        public BedroomController(AppBedroomContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var bedrooms = _context.Bedrooms.AsNoTracking().ToList();
            var dto = _mapper.Map<IEnumerable<ReadBedroomDto>>(bedrooms);

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bedroom = _context.Bedrooms.AsNoTracking().FirstOrDefault(b => b.Id == id);
            if (bedroom is null) return NotFound();

            var dto = _mapper.Map<ReadBedroomDto>(bedroom);

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateBedroomDto dto)
        {
            var bedroom = _mapper.Map<Bedroom>(dto);

            _context.Bedrooms.Add(bedroom);
            _context.SaveChanges();

            return Created("", bedroom);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateBedroomDto dto)
        {
            var bedroom = _context.Bedrooms.FirstOrDefault(b => b.Id == id);
            if (bedroom is null) return NotFound();

            _mapper.Map(dto, bedroom);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bedroom = _context.Bedrooms.AsNoTracking().FirstOrDefault(b => b.Id == id);
            if (bedroom is null) return NotFound();

            _context.Bedrooms.Remove(bedroom);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
