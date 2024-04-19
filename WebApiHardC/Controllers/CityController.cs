using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using WebApiP2.Data;
using WebApiP2.Domain.DTO;
using WebApiP2.Domain.Model;
using WebApiP2.Repositories;

namespace WebApiP2.Controllers
{
    [Route("Api/controller")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityDbContext _context;
        private readonly ICityRepository cityRepository;

        public CityController(CityDbContext context, ICityRepository cityRepository)
        {
            _context = context;
            this.cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var citiesdata = await cityRepository.GetAllAsync();

            var citiesdto = new List<CityDto>();

            foreach (var city in citiesdata)
            {
                citiesdto.Add(new CityDto()
                { 
                    Id = city.Id,
                    Name = city.Name,
                    Rank = city.Rank,
                    State = city.State
                });
            }

            return Ok(citiesdto);
        }


        [HttpGet("{id=Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var citiesdata = await cityRepository.GetByIDAsync(id);

            if (citiesdata == null)
            {
                return NotFound();
            }

            var citiesdto = new CityDto()
            {
                Id = citiesdata.Id,
                Name = citiesdata.Name,
                Rank = citiesdata.Rank,
                State = citiesdata.State

            };


            return Ok(citiesdto);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddCityDto addcitydto)
        {
            var citymodel = new City()
            {
                Name = addcitydto.Name,
                Rank = addcitydto.Rank,
                State = addcitydto.State
            };

            citymodel = await cityRepository.CreateAsync(citymodel);

            var citydto = new CityDto()
            {
                Id = citymodel.Id,
                Name = citymodel.Name,
                Rank = citymodel.Rank,
                State = citymodel.State

            };

            return CreatedAtAction(nameof(GetById), new {id = citydto.Id} , citydto);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCityDTO updateCitydto)
        {
            var citymodel = new City
            {
                Name = updateCitydto.Name,
                Rank = updateCitydto.Rank,
                State = updateCitydto.State
            };

            citymodel = await cityRepository.UpdateAsync(id, citymodel);


            var citydto = new CityDto
            {
                Id= citymodel.Id,   
                Name = updateCitydto.Name,
                Rank = updateCitydto.Rank,
                State = updateCitydto.State
            };

            return Ok(citydto);
            
         }

        [HttpDelete("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
           var citymodel = await cityRepository.DeleteAsync(id);

            if (citymodel == null)
            {
                return NotFound();
            }

            var citydto = new CityDto 
            { 
                Id = citymodel.Id,
                Name = citymodel.Name,
                Rank = citymodel.Rank,
                State = citymodel.State
            };


            return Ok();
        }
        

    }
}
