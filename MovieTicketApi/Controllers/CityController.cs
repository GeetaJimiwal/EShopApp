using Microsoft.AspNetCore.Mvc;
using MovieTicketApi.Repository.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        // GET: api/<CityController>
        [HttpGet]
        public IEnumerable<Model.City> Get()
        {
            var cityies = cityRepository.GetAll();
            return cityies;
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public Model.City Get(int id)
        {
            var city = cityRepository.GetById(id);
            return city;
        }

        // POST api/<CityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
