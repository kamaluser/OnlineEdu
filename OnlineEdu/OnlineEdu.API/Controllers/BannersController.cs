using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.BannerDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> _bannerService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _bannerService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _bannerService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bannerService.TDelete(id);
            return Ok("Data Removed!");
        }

        [HttpPost]
        public IActionResult Create(CreateBannerDto createDto)
        {
            var newValue = _mapper.Map<Banner>(createDto);
            _bannerService.TCreate(newValue);
            return Ok("Data Created Succesfully.");
        }

        [HttpPut]
        public IActionResult Update(UpdateBannerDto updateDto)
        {
            var newValue = _mapper.Map<Banner>(updateDto);
            _bannerService.TUpdate(newValue);
            return Ok("Data Updated Successfully.");
        }
    }
}
