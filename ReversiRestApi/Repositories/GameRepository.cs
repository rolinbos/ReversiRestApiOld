using System;
using System.Collections.Generic;
using System.Linq;
using ReversiRestApi.Interfaces;
using ReversiRestApi.Models;

namespace ReversiRestApi.Repositories
{
    public class GameRepository: IGameRepository
    {
        public List<Game> Games { get; set; }
        
        public GameRepository()
        {
            Game game1 = new Game();
            Game game2 = new Game();
            Game game3 = new Game();

            game1.Player1Token = "abcdef";
            game1.Description = "Potje snel reveri, dus niet lang nadenken";
            game1.Token = "4df3df30-3e9b-474c-b05e-ca7354291893";
            game2.Player1Token = "ghijkl";
            game2.Player2Token = "mnopqr";
            game2.Description = "Ik zoek een gevorderde tegenGameer!";
            game3.Player1Token = "stuvwx";
            game3.Description = "Na dit Game wil ik er nog een paar Gameen tegen zelfde tegenstander";
            
            this.Games = new List<Game> {game1, game2, game3};
        }

        public void CreateGame(Game game)
        {
            this.Games.Add(game);
        }

        public List<Game> GetWaitingGames()
        {
            return this.Games.Where(game => string.IsNullOrEmpty(game.Player2Token)).ToList();
        }

        public Game GetGameFromToken(string gameToken)
        {
            return this.Games.Where(game => game.Token == gameToken).First();
        }

        public Game GetGameFromPlayerToken(string playerToken)
        {
            return this.Games
                .First(game => 
                    (game.Player1Token == playerToken) || 
                    (game.Player2Token == playerToken)
                );
        }
        
        public Kleur GetTurn(string gameToken)
        {
            Game game = this.Games.Where(game => game.Token == gameToken).First();

            return game.AandeBeurt;
        }

        public void TakeTurn()
        {
            
        }

        public void GiveUp()
        {
            
        }
    }
}