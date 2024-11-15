using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IGenericService<About> _aboutService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _aboutService.TDelete(id);
            return Ok("Data Removed!");
        }

        [HttpPost]
        public IActionResult Create(CreateAboutDto createDto)
        {
            var newValue = _mapper.Map<About>(createDto);
            _aboutService.TCreate(newValue);
            return Ok("Data Created Succesfully.");
        }

        [HttpPut]
        public IActionResult Update(UpdateAboutDto updateDto)
        {
            var newValue = _mapper.Map<About>(updateDto);
            _aboutService.TUpdate(newValue);
            return Ok("Data Updated Successfully.");
        }
    }
}
