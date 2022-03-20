using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReversiRestApi.Interfaces;
using ReversiRestApi.Models;
using ReversiRestApi.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReversiRestApi.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository iRepository;

        public GameController(IGameRepository repository)
        {
            this.iRepository = repository;
        }
        
        // POST api/game/create
        [HttpPost("create")]
        public void CreateGame([FromBody] GameRequest gameRequest)
        {
            Game game = new Game()
            {
                Token = new Guid().ToString(),
                Player1Token = gameRequest.Player1Token,
                Description = gameRequest.Description,
            };
            
            this.iRepository.CreateGame(game);
        }
        
        // GET api/game/waitings
        [HttpGet("waiting")]
        public ActionResult<String> GetWaitingGames()
        {
            return JsonConvert.SerializeObject(
                this.iRepository.GetWaitingGames().ToList(), Formatting.Indented
            );
        }
        
        // GET api/game/{gameToken}
        [HttpGet("{gameToken}")]
        public ActionResult<String> GetGameFromToken(string gameToken)
        {
            return JsonConvert.SerializeObject(this.iRepository.GetGameFromToken(gameToken), Formatting.Indented);
        }
        
        // GET api/game/player/{playerToken}
        [HttpGet("player/{playerToken}")]
        public ActionResult<string> GetGameFromPlayerToken(string playerToken)
        {
            return JsonConvert.SerializeObject(this.iRepository.GetGameFromPlayerToken(playerToken), Formatting.Indented);
        }
        
        // GET api/game/turn/{gameToken}
        [HttpGet("turn/{gameToken}")]
        public ActionResult<Kleur> GetTurn(string gameToken)
        {
            return this.iRepository.GetTurn(gameToken);
        }
        
        // PUT /api/game/take-turn/
        // Token from game + token from player
        [HttpPut("take-turn")]
        public ActionResult<String> TakeTurn(string gameToken, string playerToken, string field)
        {
            return $"Token: {gameToken} player: {playerToken} field: {field}";
        }
        
        // PUT /api/game/give-up
        [HttpPut("give-up")]
        public ActionResult<string> GiveUp()
        {
            return "Give up";
        }
    }
}
