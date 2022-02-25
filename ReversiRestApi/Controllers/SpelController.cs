using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReversiRestApi.Interfaces;
using ReversiRestApi.Models;
using ReversiRestApi.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReversiRestApi.Controllers
{
    [Route("api/Spel")]
    [ApiController]
    public class SpelController : ControllerBase
    {
        private readonly ISpelRepository iRepository;

        public SpelController(ISpelRepository repository)
        {
            this.iRepository = repository;
        }
        
        // GET api/spel
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetSpelOmschrijvingenVanSpellenMetWachtendeSpeler()
        {
            return this.iRepository.GetSpelDescriptionWithWaitingPlayers().ToList();
        }
        
        // // GET: api/values
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }
        //
        // // GET api/values/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        // }
        //
        // POST api/spel
        [HttpPost]
        public void Post([FromBody] SpelRequest spelRequest)
        {
            Spel spel = new Spel()
            {
                Token = new Guid().ToString(),
                Speler1Token = spelRequest.Speler1Token,
                Omschrijving = spelRequest.Omschrijving,
            };
            
            this.iRepository.AddSpel(spel);
        }
        //
        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
