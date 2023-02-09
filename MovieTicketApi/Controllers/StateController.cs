using Microsoft.AspNetCore.Mvc;
using MovieTicketApi.Repository.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository stateRepository;

        public StateController(IStateRepository stateRepository)
        {
            this.stateRepository = stateRepository;
        }
        // GET: api/<StateController>
        [HttpGet]
        public IEnumerable<Model.State> Get()
        {
            var states = stateRepository.GetAll();
            return states;
        }

        // GET api/<StateController>/5
        [HttpGet("{id}")]
        public Model.State Get(int id)
        {
            var state = stateRepository.GetById(id);
            return state;
        }

        // POST api/<StateController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
